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

        builder.Services.AddSingleton<MainPageModel>();
        builder.Services.AddSingleton<HolaMundoButtonPageModel>();


        //registrar el page en el DI
        builder.Services.AddTransient<HolaMundoButtonPage>();

        return builder.Build();
    }
}
