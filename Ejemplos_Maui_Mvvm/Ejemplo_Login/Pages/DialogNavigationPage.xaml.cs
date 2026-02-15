using Ejemplo_Login.PageModels;

namespace Ejemplo_Login.Pages;

public partial class DialogNavigationPage : ContentPage
{
	public DialogNavigationPage()
	{
		InitializeComponent();
        
        this.BindingContext = new DialogNavigationPageModel();
	}
}