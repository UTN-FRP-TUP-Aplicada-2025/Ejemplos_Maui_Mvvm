
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejemplo_Encuesta.Pages;
using Ejemplo_Encuesta.Services;
using Ejemplo_Encuesta.Services.graphql;
using System.Collections.ObjectModel;

namespace Ejemplo_Encuesta.PageModels;

public partial class EstadisticasPageModel : ObservableObject
{
    readonly EncuestasService _encuestasServices = default!;

    [ObservableProperty]
    private bool isBusy = false;

    [ObservableProperty]
    int  encuestados;

    [ObservableProperty]
    double edadPromedio;

    [ObservableProperty]
    DateTime fecha;

    [ObservableProperty]
    ObservableCollection<DetalleEncuestaPageModel> ultimosEncuestados = new();

    public EstadisticasPageModel(EncuestasService encuestasServices)
    {
        _encuestasServices = encuestasServices;
    }

    [RelayCommand]
    private async Task Appearing(object? obj)
    {        
        if (IsBusy) return;
        IsBusy = true;

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

    [RelayCommand]
    private async Task VerEncuestado(DetalleEncuestaPageModel encuesta)
    {
        if (IsBusy) return;
        IsBusy = true;

        try
        {
            if (encuesta is null) return;

            //await Shell.Current.GoToAsync($"{nameof(DetalleEncuestaPage)}");
            var page = new DetalleEncuestaPage(encuesta);
            await Shell.Current.Navigation.PushAsync(page);


            // otra alternativa
            // await Application.Current!.MainPage!.DisplayAlertAsync( encuestado.Nombre,$"Fecha: {encuestado.Fecha:d/M/yyyy HH:mm}", "Cerrar");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlertAsync("Error",$"{ex.Message}", "Cerrar");
        }
        finally 
        { 
            IsBusy = false; 
        }
    }

}
