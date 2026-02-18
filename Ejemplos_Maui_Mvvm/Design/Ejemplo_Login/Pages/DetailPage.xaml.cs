using Ejemplo_Login.PageModels;

namespace Ejemplo_Login.Pages;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailPageModel model)
	{
		InitializeComponent();

        this.BindingContext = model;
	}
}