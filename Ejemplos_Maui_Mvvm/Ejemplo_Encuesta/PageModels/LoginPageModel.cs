using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Ejemplo_Encuesta.PageModels;

public partial class LoginPageModel : ObservableObject
{
   // private readonly IAlertService _alertService;

    [ObservableProperty]
    private string usuario = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;

    [ObservableProperty]
    private bool recordarUsuario;

    // public LoginPageModel(IAlertService alertService)
    public LoginPageModel( )
    {
      //  _alertService = alertService;
    }

    [RelayCommand]
    async Task Login()
    {
        //try
        //{
        //    // Validaciones
        //    if (string.IsNullOrWhiteSpace(Usuario))
        //    {
        //        await _alertService.ShowAlertAsync("Validación", "Por favor ingrese su usuario");
        //        return;
        //    }

        //    if (string.IsNullOrWhiteSpace(Password))
        //    {
        //        await _alertService.ShowAlertAsync("Validación", "Por favor ingrese su contraseña");
        //        return;
        //    }

        //    // Aquí iría tu lógica de autenticación
        //    // Por ejemplo:
        //    // var loginExitoso = await _authService.LoginAsync(Usuario, Password);

        //    // Simulación
        //    if (Usuario == "admin" && Password == "1234")
        //    {
        //        await _alertService.ShowAlertAsync("Éxito", "Inicio de sesión exitoso");
        //        // Navegar a la página principal
        //        // await Shell.Current.GoToAsync("//MainPage");
        //    }
        //    else
        //    {
        //        await _alertService.ShowAlertAsync("Error", "Usuario o contraseña incorrectos");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    await _alertService.ShowAlertAsync("Error", $"Ocurrió un error: {ex.Message}");
        //}
    }

    [RelayCommand]
    async Task RecuperarPassword()
    {
        //await _alertService.ShowAlertAsync("Recuperar Contraseña", "Funcionalidad en desarrollo");
    }
}
