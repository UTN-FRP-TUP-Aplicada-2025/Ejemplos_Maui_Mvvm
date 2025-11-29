using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using System.Windows.Input;


namespace Ejemplo_Views.PageModels;

public partial class HolaMundoButtonPageModel:ObservableObject
{
    ILogger<MainPageModel> _logger;

    [ObservableProperty]
    string mensaje = default!;

    public HolaMundoButtonPageModel(ILogger<MainPageModel> logger)
    {
        this._logger = logger;
        ClickCommand = new Command(OnClick);
    }

    public ICommand ClickCommand { get; }

    public void OnClick()
    {
        Mensaje="Hola mundo";
    }
}
