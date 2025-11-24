using BarcodeScanner.Mobile;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Ejemplo_QR_BarcodeScanner;

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

        builder.ConfigureMauiHandlers(handlers =>
        {
            handlers.AddBarcodeScannerHandler();
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<MainPageModel>();
        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
    }
}
