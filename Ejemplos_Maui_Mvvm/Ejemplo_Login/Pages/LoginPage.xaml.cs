using Ejemplo_Login.PageModels;

namespace Ejemplo_Login.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageModel loginPageModel)
	{
		InitializeComponent();
        this.BindingContext = loginPageModel;
	}

    protected override bool OnBackButtonPressed()
    {
        //evita el boton de forward 
        return true;
    }
}