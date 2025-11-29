namespace Ejemplo_Views;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        //registrar las rutas
        Routing.RegisterRoute(nameof(HolaMundoButtonPage), typeof(HolaMundoButtonPage));

    }
}
