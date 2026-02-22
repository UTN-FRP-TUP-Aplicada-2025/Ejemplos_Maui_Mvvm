using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejemplo_MasterDetails.Pages;
using Ejemplo_MasterDetails.Services;
using System.Collections.ObjectModel;

namespace Ejemplo_MasterDetails.PageModels;

public partial class EstadisticaPageModel:ObservableObject
{
    // Dentro de la clase:

    readonly EncuestasService _encuestasServices;

    [ObservableProperty]
    int encuestados;

    [ObservableProperty]
    double edadPromedio;

    [ObservableProperty]
    DateTime? fecha;

    [ObservableProperty]
    ObservableCollection<DetalleEncuestaPageModel> ultimosEncuestados = new();

    public EstadisticaPageModel(EncuestasService encuestasServices)
    {
        _encuestasServices = encuestasServices;
    }

    [RelayCommand]
    private async Task VerEncuestado(DetalleEncuestaPageModel encuesta)
    {
        if (encuesta is null) return;

        //await Shell.Current.GoToAsync($"{nameof(DetalleEncuestaPage)}");
        await Shell.Current.Navigation.PushAsync(new DetalleEncuestaPage(encuesta));

        // otra alternativa
        // await Application.Current!.MainPage!.DisplayAlertAsync( encuestado.Nombre,$"Fecha: {encuestado.Fecha:d/M/yyyy HH:mm}", "Cerrar");
    }

    bool _loaded;

    [RelayCommand]
    private async Task Appearing(object? obj)
    {
        if (_loaded) return;
        _loaded = true;

        try
        {
            var estadistica = await _encuestasServices.ObtenerEstadisticasAsync();

            Encuestados = estadistica.Encuestados;
            EdadPromedio = estadistica.EdadPromedio;
            Fecha = estadistica.Fecha;

            var ultimos = await _encuestasServices.ObtenerUltimosEncuestadosAsync();
            
            var listaModels=(from e in ultimos
                             select new DetalleEncuestaPageModel(){
                                        Nombre = e.Nombre, FechaNacimiento = e.FechaNacimiento 
                             }).ToList();

            UltimosEncuestados = new ObservableCollection<DetalleEncuestaPageModel>(listaModels);
        }
        catch (Exception ex)
        {
            await Toast.Make($"Error: {ex.Message}", ToastDuration.Long).Show();
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
