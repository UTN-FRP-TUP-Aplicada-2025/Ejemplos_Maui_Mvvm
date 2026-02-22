using Ejemplo_MasterDetails.PageModels;

namespace Ejemplo_MasterDetails.Pages;

public partial class DetalleEncuestaPage : ContentPage
{
	public DetalleEncuestaPage(DetalleEncuestaPageModel model)
	{
		InitializeComponent();

        this.BindingContext = model;
	}
}