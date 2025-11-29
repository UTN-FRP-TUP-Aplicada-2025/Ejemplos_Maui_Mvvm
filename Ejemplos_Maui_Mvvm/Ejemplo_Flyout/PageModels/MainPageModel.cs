using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejemplo_Flyout.PageModels;

public partial class MainPageModel:ObservableObject
{
    readonly ILogger<MainPageModel> _logger = default!;

    public MainPageModel(ILogger<MainPageModel> logger)
    {
        _logger = logger;
    }
}
