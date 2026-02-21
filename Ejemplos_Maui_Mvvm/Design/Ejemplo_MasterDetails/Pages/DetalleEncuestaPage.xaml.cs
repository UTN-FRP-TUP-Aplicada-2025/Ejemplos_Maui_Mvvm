using Ejemplo_MasterDetails.PageModels;

namespace Ejemplo_MasterDetails.Pages;

public partial class DetalleEncuestaPage : ContentPage
{
	public DetalleEncuestaPage(EstadisticaPageModel model)
	{
		InitializeComponent();

        this.BindingContext = model;
	}
}