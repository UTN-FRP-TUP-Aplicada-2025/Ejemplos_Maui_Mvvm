
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejemplo_Encuesta.Services;
using Java.Net;

namespace Ejemplo_Encuesta.PageModels;

public partial class EstadisticaPageModel : ObservableObject
{
    [ObservableProperty]
    int  encuestados;

    [ObservableProperty]
    double edadPromedio;

    [ObservableProperty]
    DateTime fecha;

    EncuestasService _encuestasServices=default!;

    public EstadisticaPageModel(EncuestasService encuestasServices)
    {
        _encuestasServices = encuestasServices;
    }
       
    [RelayCommand]
    private async Task Appearing(object? obj)
    {
        try
        {
            var estadistica = await _encuestasServices.ObtenerEstadisticasAsync();

            Encuestados = estadistica.Encuestados;
            EdadPromedio = estadistica.EdadPromedio;
            Fecha = estadistica.Fecha;
        }
        catch (Exception ex)
        {
            await Toast.Make($"Error: {ex.Message}", ToastDuration.Long).Show();
        }
    }

    [RelayCommand]
    private async Task Help(string? url)
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

    /*
    [RelayCommand]
    private async Task Back()
    {

    }
    */
}
