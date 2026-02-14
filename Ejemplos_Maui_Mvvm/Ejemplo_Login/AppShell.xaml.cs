using CommunityToolkit.Mvvm.Input;
using Ejemplo_Login.Pages;

namespace Ejemplo_Login;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        
        BindingContext = this;
    }

    [RelayCommand]
    async private void Logout()
    { 
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

}
