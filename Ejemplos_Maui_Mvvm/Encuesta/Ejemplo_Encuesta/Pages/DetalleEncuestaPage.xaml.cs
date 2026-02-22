using Ejemplo_Encuesta.PageModels;

namespace Ejemplo_Encuesta.Pages;

public partial class DetalleEncuestaPage : ContentPage
{
	public DetalleEncuestaPage(DetalleEncuestaPageModel model)
	{
		InitializeComponent();

        this.BindingContext = model;
	}
}