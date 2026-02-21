using Ejemplo_MasterDetails.Pages;

namespace Ejemplo_MasterDetails;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(DetalleEncuestaPage), typeof(DetalleEncuestaPage));
    }
}
