using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Ejemplo_Views;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddLogging();

        #region models
        builder.Services.AddSingleton<MainPageModel>();        
        builder.Services.AddSingleton<HolaMundoButtonPageModel>();
        builder.Services.AddSingleton<EjemplosViewPageModel>();
        #endregion

        #region registrar el page en el DI
        builder.Services.AddTransient<HolaMundoButtonPage>();
        builder.Services.AddTransient<EjemplosViewPage>();
        #endregion

        return builder.Build();
    }
}
