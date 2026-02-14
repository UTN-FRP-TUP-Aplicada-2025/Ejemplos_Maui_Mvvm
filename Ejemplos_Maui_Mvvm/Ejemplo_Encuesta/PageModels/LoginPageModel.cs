using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Ejemplo_Encuesta.PageModels;

public partial class LoginPageModel : ObservableObject
{
    //private readonly LoginService _loginService=default!;

    [ObservableProperty]
    private string usuario = string.Empty;

    [ObservableProperty]
    private string clave = string.Empty;

    [ObservableProperty]
    private bool recordarUsuario;
     
    [RelayCommand]
    async Task RecuperarPassword()
    {
        //await _alertService.ShowAlertAsync("Recuperar Contraseña", "Funcionalidad en desarrollo");
    }
      
    [RelayCommand]
    async Task LoginCommand()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Usuario))
            {
                await Toast.Make("Por favor ingrese su usuario", ToastDuration.Long).Show();
                return;
            }

            if (string.IsNullOrWhiteSpace(Clave))
            {
                await Toast.Make("Por favor ingrese su contraseña", ToastDuration.Long).Show();               
                return;
            }

            if (Usuario == "admin" && Clave == "1234")
                {
                    await Toast.Make("Inicio de sesión exitoso", ToastDuration.Long).Show();
                    
                    await Shell.Current.GoToAsync("//EncuestaPage");
                }
                else
                {
                    await Toast.Make("Usuario o contraseña incorrectos", ToastDuration.Long).Show();
            }
        }
        catch (Exception ex)
        {
            await Toast.Make("Ocurrió un error", ToastDuration.Long).Show();
        }
    }
}