using CommunityToolkit.Mvvm.Input;
using Ejemplo_Login.Pages;
using Ejemplo_Login.Services;

namespace Ejemplo_Login;

public partial class AppShell : Shell
{
    private readonly LoginService _loginService;

    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(DialogShellPage), typeof(DialogShellPage));
        //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

        BindingContext = this;
    }

    async protected override void OnAppearing()
    {
        base.OnAppearing();

        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    [RelayCommand]
    async private Task Logout()
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    [RelayCommand]
    private async Task Politica(string url)
    {
        if (!string.IsNullOrEmpty(url))
        {
            await Browser.Default.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
        }
    }
}
