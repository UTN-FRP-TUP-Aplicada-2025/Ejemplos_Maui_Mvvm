using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejemplo_Encuesta.Pages;
using Ejemplo_Encuesta.Services.Auth;


namespace Ejemplo_Encuesta.PageModels;

public partial class LoginPageModel : ObservableObject
{

    readonly AuthService _authService = default!;
    readonly TokenStorageService _storage = default!;

    [ObservableProperty]
    private bool isBusy = false;

    [ObservableProperty]
    private string usuario;

    [ObservableProperty]
    private string clave;

    [ObservableProperty]
    private string errorMessage;

    public LoginPageModel(AuthService authService, TokenStorageService storage)
    {
        _authService = authService;
        _storage = storage;
    }

    [RelayCommand]
    private async Task LoginAsync()
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

        //login simulado
        //if (Usuario != "admin" || Clave != "1234")
        //{
        //    await Toast.Make("Usuario o Clave incorrecto", ToastDuration.Long).Show();
        //    return;
        //}

        if (IsBusy)
            return;

        ErrorMessage = string.Empty;

        try
        {
            IsBusy = true;

            var token = await _authService.getTokenAsync(Usuario, Clave);

            if (token == null)
            {
                ErrorMessage = "Usuario o contraseña inválidos";
                return;
            }

            await _storage.SaveAsync(token);

            await Shell.Current.GoToAsync($"//{nameof(EncuestaPage)}");
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Error: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }
}