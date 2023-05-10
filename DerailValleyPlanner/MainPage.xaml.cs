using System.Windows.Input;

namespace DerailValleyPlanner;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        OnOpenCommandClick = new Command<string>(async (s) => await OpenFile(s));
    }
    
    public ICommand OnOpenCommandClick { get; private set; }

    public async Task OpenFile(string item)
    {
        Console.WriteLine(item);
    }
}