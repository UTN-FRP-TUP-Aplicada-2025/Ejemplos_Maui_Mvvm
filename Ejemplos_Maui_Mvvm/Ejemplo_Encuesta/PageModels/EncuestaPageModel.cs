using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejemplo_Encuesta.Services;

namespace Ejemplo_Encuesta.PageModels;

public partial class EncuestaPageModel : ObservableObject
{
    EncuestasServices _encuestasServices = default!;

    [ObservableProperty]
    private string nombre = string.Empty;

    [ObservableProperty]
    private DateTime fechaNacimiento = DateTime.Today;

   
    public EncuestaPageModel(EncuestasServices encuestasServices)
    {
        _encuestasServices=encuestasServices ;
    }


    [RelayCommand]
    async private void Guardar()
    {
        await _encuestasServices.RegistrarEncuesta(new Models.EncuestaModel 
        {
            Nombre = nombre,
            FechaNacimiento = fechaNacimiento
        });
    }
}
