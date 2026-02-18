using Ejemplo_Login.PageModels;

namespace Ejemplo_Login.Pages;

public partial class DialogShellPage : ContentPage
{
	public DialogShellPage()
	{
		InitializeComponent();

        this.BindingContext = new DialogShellPageModel();
    }
}