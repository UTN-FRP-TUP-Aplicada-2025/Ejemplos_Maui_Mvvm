using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Windows.Input;

namespace Ejemplo_Views.PageModels;

public partial class MainPageModel : ObservableObject
{
    readonly ILogger<MainPageModel> _logger=default!;

    public MainPageModel(ILogger<MainPageModel> logger)
    {
        this._logger = logger;
        HolaMundoClickedCommand = new Command(HolaMundoClicked);
    }

    #region comamnds ejemplo
    public ICommand HolaMundoClickedCommand { get; }

    async public void HolaMundoClicked()
    {
        await Shell.Current.GoToAsync(nameof(HolaMundoButtonPage));
    }
    #endregion

    [RelayCommand]
    public async Task EjemplosViewClicked()
    {
        _logger.LogInformation("Navegando a EjemplosViewPage");
        await Shell.Current.GoToAsync(nameof(EjemplosViewPage));
    }
}