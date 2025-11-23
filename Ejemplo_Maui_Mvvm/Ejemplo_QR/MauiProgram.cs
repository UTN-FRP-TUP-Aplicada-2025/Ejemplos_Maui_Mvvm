using Microsoft.Extensions.Logging;
using BarcodeScanner.Mobile;
using Ejemplo_QR.Pages;
using CommunityToolkit.Maui;

namespace Ejemplo_QR;

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

        builder.Services.AddSingleton<PageModels.MainPageModel>();
        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
    }
}
