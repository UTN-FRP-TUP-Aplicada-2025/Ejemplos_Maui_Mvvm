
using Ejemplo_Login.Pages;
using Ejemplo_Login.Services;

namespace Ejemplo_Login;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }

    protected override async void OnStart()
    {
        base.OnStart();
        var session = IPlatformApplication.Current.Services.GetRequiredService<LoginService>();
        if (session == null)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}