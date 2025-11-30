using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Windows.Input;


namespace Ejemplo_Views.PageModels;

public partial class HolaMundoButtonPageModel:ObservableObject
{
    readonly ILogger<HolaMundoButtonPageModel> _logger=default!;

    [ObservableProperty]
    string textLabel = default!;

    public HolaMundoButtonPageModel(ILogger<HolaMundoButtonPageModel> logger)
    {
        this._logger = logger;
    }

    [RelayCommand]
    public void Clicked()
    {
        TextLabel = "Hola mundo";
    }
}
