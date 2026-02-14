using Ejemplo_Login.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejemplo_Login.Services;

public class NavigationService : INavigationService
{
    readonly IServiceProvider _services;

    public NavigationService(IServiceProvider services)
    {
        _services = services;
    }

    //public void ShowShell()
    //{
    //    Application.Current.Windows[0].Page = _services.GetRequiredService<AppShell>();
    //}

    //public async void ShowLogin()
    //{
    //    if (Shell.Current != null)
    //        await Shell.Current.Navigation.PopToRootAsync(false);

    //    Application.Current.Windows[0].Page = _services.GetRequiredService<LoginPage>();
    //}

    public Task ShowLogin() => Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

    public Task ShowShell()=> Shell.Current.GoToAsync($"//MainPage");
}
