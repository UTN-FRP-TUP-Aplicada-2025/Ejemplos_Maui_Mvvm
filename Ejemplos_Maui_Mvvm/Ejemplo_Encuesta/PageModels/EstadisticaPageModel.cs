
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejemplo_Encuesta.Services;

namespace Ejemplo_Encuesta.PageModels;

public partial class EstadisticaPageModel : ObservableObject
{
    [ObservableProperty]
    int  encuestados;

    [ObservableProperty]
    double edadPromedio;

    [ObservableProperty]
    DateTime fecha;

    EncuestasServices _encuestasServices=default!;

    public EstadisticaPageModel(EncuestasServices encuestasServices)
    {
        _encuestasServices = encuestasServices;
    }

    [RelayCommand]
    private async Task Appearing(object? obj)
    {
        var estadistica = await _encuestasServices.ObtenerEstadisticasAsync();
        Encuestados = estadistica.Encuestados;
        EdadPromedio = estadistica.EdadPromedio;
        Fecha = estadistica.Fecha;
    }

}
