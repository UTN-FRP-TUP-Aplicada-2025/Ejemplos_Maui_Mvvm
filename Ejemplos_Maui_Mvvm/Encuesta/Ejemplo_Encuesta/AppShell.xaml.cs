using CommunityToolkit.Mvvm.Input;
using Ejemplo_Encuesta.Pages;
using Ejemplo_Encuesta.Services;
using System.Windows.Input;

namespace Ejemplo_Encuesta;

public partial class AppShell : Shell
{
    public AppShell()
    { 
        InitializeComponent();

        BindingContext = this;
    }

    [RelayCommand]
    private async Task Politica(string url)
    {
        if (!string.IsNullOrEmpty(url))
        {
            await Browser.Default.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
        }
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
}
