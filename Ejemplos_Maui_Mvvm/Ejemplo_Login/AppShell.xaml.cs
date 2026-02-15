using CommunityToolkit.Mvvm.Input;
using Ejemplo_Login.Pages;
using Ejemplo_Login.Services;

namespace Ejemplo_Login;

public partial class AppShell : Shell
{

    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(DialogShellPage), typeof(DialogShellPage));

        BindingContext = this;
    }

    [RelayCommand]
    async private void Logout()
    { 
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    async protected override void OnAppearing()
    {
        base.OnAppearing();

        LoginService sessionSevices=new LoginService();

        var session=sessionSevices.GetSession();

        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}
