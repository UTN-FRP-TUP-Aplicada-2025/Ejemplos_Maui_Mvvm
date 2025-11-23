using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Ejemplo_HolaMundo.Services;

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

        // Registrar solo los servicios necesarios
        builder.Services.AddSingleton<PersonasService>();

        return builder.Build();
    }
}
