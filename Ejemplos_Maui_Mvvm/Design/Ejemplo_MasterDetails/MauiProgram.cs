using CommunityToolkit.Maui;
using Ejemplo_MasterDetails.PageModels;
using Ejemplo_MasterDetails.Services;
using Microsoft.Extensions.Logging;

namespace Ejemplo_MasterDetails;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .AddServices()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("MaterialIconsOutlined-Regular.otf", "MaterialIconsOutlined");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    static public MauiAppBuilder AddServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<EncuestasService>();

        builder.Services.AddTransient<EstadisticasPageModel>();
        builder.Services.AddTransient<DetalleEncuestaPageModel>();


        return builder;
    }
}
