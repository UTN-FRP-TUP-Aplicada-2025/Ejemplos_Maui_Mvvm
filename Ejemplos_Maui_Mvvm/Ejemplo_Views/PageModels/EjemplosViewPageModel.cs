using CommunityToolkit.Mvvm.ComponentModel;
using Ejemplo_Views.Models;
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

    [ObservableProperty]
    List<Chapter> chapters = new();

    [ObservableProperty]
    List<SettingItem> settings = new();

    public EjemplosViewPageModel(ILogger<EjemplosViewPageModel> logger)
    {
        this._logger = logger;

        Localidades = new List<LocalidadModel>
        {
            new LocalidadModel{ Id=1, Descripcion="Paraná"},
            new LocalidadModel{ Id=2, Descripcion="Buenos Aires"},
        };

        Chapters = new List<Chapter>()
        {
            new Chapter { Title="El gato con botas", Detail="El gato con botas es un cuento popular europeo, recopilado en 1697",Image="email.png"},
            new Chapter { Title="El gato con botas", Detail="El gato con botas es un cuento popular europeo, recopilado en 1697",Image="email.png"},
        };

        Settings = new List<SettingItem>()
        {
            new SettingItem { Name="Color",IsOn="True"},
            new SettingItem { Name="Otra Propiedad",IsOn="True"},
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

