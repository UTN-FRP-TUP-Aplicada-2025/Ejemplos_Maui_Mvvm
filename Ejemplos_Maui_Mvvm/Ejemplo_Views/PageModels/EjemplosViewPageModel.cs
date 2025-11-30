using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;

using Microsoft.Maui.Controls;

namespace Ejemplo_Views.PageModels;

public partial class EjemplosViewPageModel : ObservableObject
{
    readonly ILogger<EjemplosViewPageModel> _logger=default!;

    [ObservableProperty]
    string entryTextChangedValue = default!;

    [ObservableProperty]
    string entryTextValue = default!;

    [ObservableProperty]
    List<Monkey> monkeys = new List<Monkey>();

    [ObservableProperty]
    Monkey selectedMonkey;

    [ObservableProperty]
    string name;

    public EjemplosViewPageModel(ILogger<EjemplosViewPageModel> logger)
    {
        this._logger = logger;

        monkeys = new List<Monkey>
        {
            new Monkey{ Name="Baboon", Location="Paraná", Details=".", ImageUrl="" },
            new Monkey{ Name="Capuchin Monkey", Location="Buenos Aires", Details=".", ImageUrl="" },
        };
    }

    partial void OnEntryTextValueChanged(string? oldValue, string newValue)
    {
        EntryTextChangedValue = $"De '{oldValue}' a '{newValue}'";

        _logger.LogInformation($"Texto cambiado a: {newValue}");
    }
}

public class Monkey
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string Details { get; set; }
    public string ImageUrl { get; set; }
}
