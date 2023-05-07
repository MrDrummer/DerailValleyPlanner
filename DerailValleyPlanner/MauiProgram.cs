using Microsoft.Extensions.Logging;
using DerailValleyPlanner.Data;
using DerailValleyPlanner.Services;
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
        
        // const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        // var path = Environment.GetFolderPath(folder);
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var dbPath = Path.Join(path, "dvp.db");
        
        Console.WriteLine($"dbPath : {dbPath}");

        builder.Services.AddDbContext<PlannerContext>((_, options) =>
        {
            options.UseSqlite($"Data Source={dbPath};");
            // options.UseSqlite($"Data Source=dvp.db"));
            options
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
        });

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<WeatherForecastService>();

        var app = builder.Build();

        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<PlannerContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        return app;
    }
}