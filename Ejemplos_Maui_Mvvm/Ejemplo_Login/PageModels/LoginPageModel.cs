using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejemplo_Login.Pages;
namespace Ejemplo_Login.PageModels;

public partial class LoginPageModel : ObservableObject
{
    [ObservableProperty]
    private string usuario;

    [ObservableProperty]
    private string clave;

    public LoginPageModel( )
    {
    }

    [RelayCommand]
    async private Task Login()
    {
        if (string.IsNullOrEmpty(Usuario))
        {
            await Toast.Make("Complete el campo usuario", ToastDuration.Long).Show();
            return;
        }

        if (string.IsNullOrEmpty(Clave))
        {
            await Toast.Make("Complete el campo clave", ToastDuration.Long).Show();
            return;
        }

        if (Usuario != "admin" || clave != "1234")
        {
            await Toast.Make("Usuario o Clave incorrecto", ToastDuration.Long).Show();
            return;
        }
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}
