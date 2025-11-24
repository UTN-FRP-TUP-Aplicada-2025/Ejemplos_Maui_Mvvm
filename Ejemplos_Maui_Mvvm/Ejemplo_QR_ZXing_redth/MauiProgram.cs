using CommunityToolkit.Maui;

using Microsoft.Extensions.Logging;
using ZXing.Net.Maui.Controls;

namespace Ejemplo_QR_ZXing_redth;

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

        builder.UseBarcodeReader();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<MainPageModel>();
        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
    }
}
