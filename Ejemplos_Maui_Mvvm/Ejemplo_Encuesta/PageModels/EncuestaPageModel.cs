using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejemplo_Encuesta.Services;

namespace Ejemplo_Encuesta.PageModels;

public partial class EncuestaPageModel : ObservableObject
{
    EncuestasService _encuestasServices = default!;

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
        try
        {
            await _encuestasServices.RegistrarEncuesta(new Models.EncuestaModel
            {
                Nombre = nombre,
                FechaNacimiento = fechaNacimiento
            });

            await Toast.Make($"Registrado", ToastDuration.Long).Show();
        }
        catch (Exception ex)
        {
            await Toast.Make($"Error: {ex.Message}", ToastDuration.Long).Show();
        }
    }
}
