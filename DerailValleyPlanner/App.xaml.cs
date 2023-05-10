namespace DerailValleyPlanner;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // MainPage = new MainPage();
        MainPage = new AppShell();
    }
    }
}