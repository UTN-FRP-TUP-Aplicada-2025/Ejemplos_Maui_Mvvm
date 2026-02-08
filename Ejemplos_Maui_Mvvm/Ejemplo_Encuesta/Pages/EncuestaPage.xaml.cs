using Ejemplo_Encuesta.PageModels;

namespace Ejemplo_Encuesta.Pages;

public partial class EncuestaPage : ContentPage
{
    public EncuestaPage(EncuestaPageModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;   
    }
}