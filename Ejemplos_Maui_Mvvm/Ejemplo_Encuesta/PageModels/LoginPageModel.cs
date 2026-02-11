using CommunityToolkit.Mvvm.ComponentModel;


namespace Ejemplo_Encuesta.PageModels;

public partial class LoginPageModel : ObservableObject
{
    [ObservableProperty]
    string usuario;

    [ObservableProperty]
    string clave;
}
