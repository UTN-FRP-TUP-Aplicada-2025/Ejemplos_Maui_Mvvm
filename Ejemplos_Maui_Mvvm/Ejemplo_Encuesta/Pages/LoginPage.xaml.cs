using Ejemplo_Encuesta.PageModels;

namespace Ejemplo_Encuesta.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageModel viewModel)
    {
		InitializeComponent();
        BindingContext = viewModel;
    }
}