using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace Ejemplo_Encuesta;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public ICommand PoliticaCommand => new RelayCommand<string>( async url =>
    {
        if (!string.IsNullOrEmpty(url))
        {
            await Browser.Default.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
        }
    });
}
