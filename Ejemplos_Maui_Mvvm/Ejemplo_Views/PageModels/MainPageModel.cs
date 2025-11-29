using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;

using Microsoft.Extensions.Logging;


namespace Ejemplo_Views.PageModels;

public partial class MainPageModel : ObservableObject
{
    readonly ILogger<MainPageModel> _logger=default!;

    public MainPageModel(ILogger<MainPageModel> logger)
    {
        this._logger = logger;
        ClickCommand = new Command(OnClick);
    }

    public ICommand ClickCommand { get; }

    async public void OnClick()
    {
        //vieja navegación navigation page
        //no recomendada en MAUI
        //await Navigation.PushAsync(new HolaMundoButtonPageModel());

        //navegación a traves de Shell
        await Shell.Current.GoToAsync(nameof(HolaMundoButtonPage));
    }
}