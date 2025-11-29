namespace Ejemplo_Views.Pages;

public partial class HolaMundoButtonPage : ContentPage
{
	public HolaMundoButtonPage(HolaMundoButtonPageModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}