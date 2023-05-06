using Microsoft.Extensions.Logging;
using DerailValleyPlanner.Data;
using Microsoft.EntityFrameworkCore;


namespace DerailValleyPlanner;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();

        builder.Services.AddDbContext<JobContext>(options =>
            options.UseSqlite("Data Source=Dvp.db;"));

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<WeatherForecastService>();

        var app = builder.Build();

        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<JobContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        return app;
    }
}