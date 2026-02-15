using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejemplo_Login.Models;
using Ejemplo_Login.Pages;


using Ejemplo_Login.Services;

namespace Ejemplo_Login.PageModels;

public partial class LoginPageModel : ObservableObject
{
    LoginService _loginService;

    [ObservableProperty]
    private string usuario;

    [ObservableProperty]
    private string clave;

    [ObservableProperty]
    private bool recordarUsuario;

    public LoginPageModel(LoginService loginService)
    {
        _loginService = loginService;
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

        if (Usuario != "admin" || Clave != "1234")
        {
            await Toast.Make("Usuario o Clave incorrecto", ToastDuration.Long).Show();
            return;
        }

        _loginService.SetSession(new LoginModel
        {
            Usuario = Usuario,
            Clave = Clave,
            RecordarUsuario = RecordarUsuario
        });

        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}
