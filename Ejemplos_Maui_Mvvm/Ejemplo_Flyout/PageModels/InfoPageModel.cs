using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;

namespace Ejemplo_Flyout.PageModels;

public partial class InfoPageModel:ObservableObject
{
    readonly ILogger<MainPageModel> _logger = default!;

    public InfoPageModel(ILogger<MainPageModel> logger)
    {
        _logger = logger;
    }
}
