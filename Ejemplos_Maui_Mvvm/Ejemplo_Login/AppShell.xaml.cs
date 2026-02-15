using CommunityToolkit.Mvvm.Input;
using Ejemplo_Login.Pages;

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

}
