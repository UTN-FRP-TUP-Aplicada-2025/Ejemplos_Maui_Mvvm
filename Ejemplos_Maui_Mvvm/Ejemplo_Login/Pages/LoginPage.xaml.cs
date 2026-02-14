using Ejemplo_Login.PageModels;

namespace Ejemplo_Login.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageModel loginPageModel)
	{
		InitializeComponent();
        this.BindingContext= loginPageModel;
	}
}