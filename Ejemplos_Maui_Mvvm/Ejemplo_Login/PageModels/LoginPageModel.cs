using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace Ejemplo_Login.PageModels;

public partial class LoginPageModel : ObservableObject
{

    public LoginPageModel( )
    {
    }


    [RelayCommand]
    private async Task Login()
    {
    }
}
