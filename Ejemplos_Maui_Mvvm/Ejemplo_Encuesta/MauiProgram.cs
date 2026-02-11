using CommunityToolkit.Maui;
using Ejemplo_Encuesta.PageModels;
using Ejemplo_Encuesta.Pages;
using Ejemplo_Encuesta.Services;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

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
        builder.Services.AddTransient<EncuestasServices>();

        builder.Services.AddTransient<EncuestaPageModel>();
        builder.Services.AddTransient<EstadisticaPageModel>();

        builder.Services.AddTransient<EncuestaPage>();
        builder.Services.AddTransient<EstadisticasPage>();

        builder.Services.AddTransient<LoginPageModel>();
        builder.Services.AddTransient<LoginPage>();

        return builder;
    }
}
