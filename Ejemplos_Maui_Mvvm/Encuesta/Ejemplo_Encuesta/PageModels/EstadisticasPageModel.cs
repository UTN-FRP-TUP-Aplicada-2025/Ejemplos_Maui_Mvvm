
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System.Collections.ObjectModel;

using Ejemplo_Encuesta.Services;
using Ejemplo_Encuesta.Pages;

namespace Ejemplo_Encuesta.PageModels;

public partial class EstadisticasPageModel : ObservableObject
{
    [ObservableProperty]
    int  encuestados;

    [ObservableProperty]
    double edadPromedio;

    [ObservableProperty]
    DateTime fecha;

    [ObservableProperty]
    ObservableCollection<DetalleEncuestaPageModel> ultimosEncuestados = new();

    EncuestasService _encuestasServices=default!;

    public EstadisticasPageModel(EncuestasService encuestasServices)
    {
        _encuestasServices = encuestasServices;
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

            var listaModels = (from e in estadistica.Encuestas
                               select new DetalleEncuestaPageModel()
                               {
                                   Nombre = e.Nombre,
                                   FechaNacimiento = e.FechaNacimiento
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

    [RelayCommand]
    private async Task VerEncuestado(DetalleEncuestaPageModel encuesta)
    {
        if (encuesta is null) return;

        //await Shell.Current.GoToAsync($"{nameof(DetalleEncuestaPage)}");
        await Shell.Current.Navigation.PushAsync(new DetalleEncuestaPage(encuesta));

        // otra alternativa
        // await Application.Current!.MainPage!.DisplayAlertAsync( encuestado.Nombre,$"Fecha: {encuestado.Fecha:d/M/yyyy HH:mm}", "Cerrar");
    }

}
