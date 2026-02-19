using CommunityToolkit.Maui;
using Ejemplo_Encuesta.PageModels;
using Ejemplo_Encuesta.Pages;
using Ejemplo_Encuesta.Services;
using Microsoft.Extensions.Logging;

namespace Ejemplo_Encuesta;

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
        // Servicios
        builder.Services.AddSingleton<LoginService>();
        builder.Services.AddSingleton<EncuestasService>();

        builder.Services.AddTransient<EncuestaPageModel>();
        builder.Services.AddTransient<EstadisticaPageModel>();
        builder.Services.AddTransient<LoginPage>();

        builder.Services.AddTransient<EncuestaPage>();
        builder.Services.AddTransient<EstadisticasPage>();
        builder.Services.AddTransient<LoginPageModel>();
        
        return builder;
    }
}
