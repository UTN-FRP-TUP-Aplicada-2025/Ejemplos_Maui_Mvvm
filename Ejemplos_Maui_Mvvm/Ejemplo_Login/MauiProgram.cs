using CommunityToolkit.Maui;
using Ejemplo_Login.PageModels;
using Microsoft.Extensions.Logging;

namespace Ejemplo_Login;

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
        builder.Services.AddTransient<LoginPageModel>();
        builder.Services.AddTransient<MainPageModel>();
        builder.Services.AddTransient<DetailPageModel>();
        

        return builder;
    }
}