using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejemplo.Models;
using Microsoft.Extensions.Logging;

namespace Ejemplo_Views.PageModels;

public partial class EjemplosViewPageModel : ObservableObject
{
    readonly ILogger<EjemplosViewPageModel> _logger=default!;

    [ObservableProperty]
    string entryTextChangedValue = default!;

    [ObservableProperty]
    string entryTextValue = default!;

    [ObservableProperty]
    List<LocalidadModel> localidades = new List<LocalidadModel>();

    [ObservableProperty]
    LocalidadModel selectedLocalidad;

    [ObservableProperty]
    string name;

    public EjemplosViewPageModel(ILogger<EjemplosViewPageModel> logger)
    {
        this._logger = logger;

        localidades = new List<LocalidadModel>
        {
            new LocalidadModel{ Id=1, Descripcion="Paraná"},
            new LocalidadModel{ Id=2, Descripcion="Buenos Aires"},
        };
    }

    partial void OnEntryTextValueChanged(string? oldValue, string newValue)
    {
        EntryTextChangedValue = $"De '{oldValue}' a '{newValue}'";

        _logger.LogInformation($"Texto cambiado a: {newValue}");
    }

    [ObservableProperty]
    private bool isToggled;

    //[RelayCommand]
    //public void OnToggled(ToggledEventArgs args)
    //{
    //    IsToggled = args.Value;
    //    _logger.LogInformation($"Switch toggled: {isToggled}");
    //}
}

