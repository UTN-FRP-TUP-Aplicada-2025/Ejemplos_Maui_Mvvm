namespace Ejemplo_Views.Pages;

public partial class EjemplosViewPage : ContentPage
{
	public EjemplosViewPage(EjemplosViewPageModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}

