namespace Ejemplo_HolaMundo.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageModel model)
    {
        InitializeComponent();

        BindingContext = model;

        //// Resolver dependencias desde DI
        //var app = IPlatformApplication.Current;
        //if (app != null)
        //{
        //    var personasService = app.Services.GetService<PersonasService>();
        //    var loggerFactory = app.Services.GetService<ILoggerFactory>();
            
        //    if (personasService != null && loggerFactory != null)
        //    {
        //        var logger = loggerFactory.CreateLogger<MainPageModel>();
        //        var model = new MainPageModel(personasService, logger);
        //        BindingContext = model;
        //    }
        //    else
        //    {
        //        System.Diagnostics.Debug.WriteLine("ERROR: No se pudieron resolver las dependencias");
        //        System.Diagnostics.Debug.WriteLine($"PersonasService: {personasService?.GetType().Name ?? "null"}");
        //        System.Diagnostics.Debug.WriteLine($"LoggerFactory: {loggerFactory?.GetType().Name ?? "null"}");
        //    }
        //}
    }
}
