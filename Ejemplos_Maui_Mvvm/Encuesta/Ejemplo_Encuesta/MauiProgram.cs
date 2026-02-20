using CommunityToolkit.Maui;
using Ejemplo_Encuesta.PageModels;
using Ejemplo_Encuesta.Pages;
using Ejemplo_Encuesta.Services;
using Ejemplo_Encuesta.Services.Auth;
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
        builder.Services.AddHttpClient<AuthService>(client =>
                        {
                            client.BaseAddress = new Uri("https://geometriafernando.somee.com/");
                        });
        builder.Services.AddSingleton<TokenStorageService>()

        // Servicios
                        .AddSingleton<LoginService>();
        builder.Services.AddHttpClient<EncuestasService>(client =>
                        {
                            client.BaseAddress = new Uri("https://geometriafernando.somee.com/");
                        });

        builder.Services.AddTransient<EncuestaPageModel>()
                        .AddTransient<EstadisticaPageModel>()
                        .AddTransient<LoginPage>()

                        .AddTransient<EncuestaPage>()
                        .AddTransient<EstadisticasPage>()
                        .AddTransient<LoginPageModel>();
        
        return builder;
    }
}
