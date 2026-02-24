using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejemplo_Encuesta.Services;

namespace Ejemplo_Encuesta.PageModels;

public partial class EncuestaPageModel : ObservableObject
{
    readonly EncuestasService _encuestasServices = default!;

    [ObservableProperty]
    private bool isBusy = false;

    [ObservableProperty]
    private string nombre = string.Empty;

    [ObservableProperty]
    private DateTime fechaNacimiento = DateTime.Today;
       
    public EncuestaPageModel(EncuestasService encuestasServices)
    {
        _encuestasServices=encuestasServices ;
    }

    [RelayCommand]
    async private void Guardar()
    {
        if (IsBusy) return; // evita doble tap
        IsBusy = true;

        try
        {
            await _encuestasServices.RegistrarEncuesta(new Models.EncuestaModel
            {
                Nombre = nombre,
                FechaNacimiento = fechaNacimiento
            });

            // clean
            Nombre = string.Empty;
            FechaNacimiento = DateTime.Today;

            //await Toast.Make($"Registrado", ToastDuration.Long).Show();
            //exito!
            await Shell.Current.DisplayAlertAsync("¡Listo!", "Encuesta registrada correctamente.", "OK");
        }
        catch (Exception ex)
        {
            //await Toast.Make($"Error: {ex.Message}", ToastDuration.Long).Show();
            await Shell.Current.DisplayAlertAsync("Sin conexión", "No se pudo conectar al servidor. Revisá tu conexión.", "OK");
        }
        finally
        {
            IsBusy = false; 
        }
    }

    [RelayCommand]
    private async Task Help(string url)
    {
        try
        {
            if (!string.IsNullOrEmpty(url))
            {
                await Browser.Default.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
            }
        }
        catch (Exception ex)
        {
            await Toast.Make($"Error: {ex.Message}", ToastDuration.Long).Show();
        }
    }
}
