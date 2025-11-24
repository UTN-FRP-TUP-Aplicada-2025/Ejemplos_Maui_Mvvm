using CommunityToolkit.Mvvm.ComponentModel;

using Microsoft.Extensions.Logging;


namespace Ejemplo_Views.PageModels;

public partial class MainPageModel : ObservableObject
{
    ILogger<MainPageModel> _logger;
  
    public MainPageModel(ILogger<MainPageModel> logger)
    {
        this._logger = logger;
        
        
    }

}
