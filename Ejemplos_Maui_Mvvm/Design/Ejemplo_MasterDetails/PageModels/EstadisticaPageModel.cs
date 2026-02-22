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
    ObservableCollection<EncuestaPageModel> ultimosEncuestados = new();

    public EstadisticaPageModel(EncuestasService encuestasServices)
    {
        _encuestasServices = encuestasServices;
    }

    [RelayCommand]
    private async Task VerEncuestado(EncuestaPageModel encuestado)
    {
        if (encuestado is null) return;

        // Navega o muestra detalle - ajusta según tu navegación
        await Shell.Current.GoToAsync($"{nameof(DetalleEncuestaPage)}");
                
        await Shell.Current.Navigation.PushAsync(new DetalleEncuestaPage(encuestado.Nombre, encuestado.FechaNacimiento));

        // Alternativa simple con alert mientras no tengas la página:
        // await Application.Current!.MainPage!.DisplayAlert(
        //     encuestado.Nombre,
        //     $"Fecha: {encuestado.Fecha:d/M/yyyy HH:mm}",
        //     "Cerrar");
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
                             select new EncuestaPageModel(){
                                        Nombre = e.Nombre, FechaNacimiento = e.FechaNacimiento 
                             }).ToList();

            UltimosEncuestados = new ObservableCollection<EncuestaPageModel>(listaModels);
        }
        catch (Exception ex)
        {
            await Toast.Make($"Error: {ex.Message}", ToastDuration.Long).Show();
        }
    }

}
