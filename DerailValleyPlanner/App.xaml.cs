﻿namespace DerailValleyPlanner;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // MainPage = new MainPage();
        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        if (window != null)
        {
            window.Title = "Derail Valley Planner";
        }

        return window;
    }
}