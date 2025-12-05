using Ejemplo.Pages;

namespace Ejemplo_Views;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        //registrar las rutas
        Routing.RegisterRoute(nameof(HolaMundoButtonPage), typeof(HolaMundoButtonPage));
        Routing.RegisterRoute(nameof(EjemplosViewPage), typeof(EjemplosViewPage));
        Routing.RegisterRoute(nameof(CardViewXamlPage), typeof(CardViewXamlPage));
        Routing.RegisterRoute(nameof(GridPage), typeof(GridPage));        
    }
}
