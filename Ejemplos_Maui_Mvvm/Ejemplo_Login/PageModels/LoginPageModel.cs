using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejemplo_Login.Pages;
namespace Ejemplo_Login.PageModels;

public partial class LoginPageModel : ObservableObject
{
    public LoginPageModel( )
    {
    }

    [RelayCommand]
    async private Task Login()
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}
