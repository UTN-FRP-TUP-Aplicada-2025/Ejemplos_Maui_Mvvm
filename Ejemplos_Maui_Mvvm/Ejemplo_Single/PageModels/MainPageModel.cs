
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;

namespace Ejemplo_Single.PageModels;

public partial class MainPageModel: ObservableObject
{
    readonly ILogger<MainPageModel> _logger = default!;

    public MainPageModel(ILogger<MainPageModel> logger )
    {
        _logger = logger;
    }
}
