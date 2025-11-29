using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Ejemplo_HolaMundo;

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

        #region page models
        builder.Services.AddSingleton<MainPageModel>();
        #endregion

        #region servicios 
        builder.Services.AddSingleton<PersonasService>();
        #endregion

        return builder.Build();
    }
}
