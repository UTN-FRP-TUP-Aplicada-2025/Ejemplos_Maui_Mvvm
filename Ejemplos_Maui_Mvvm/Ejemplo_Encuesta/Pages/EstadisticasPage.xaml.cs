using Ejemplo_Encuesta.PageModels;

namespace Ejemplo_Encuesta.Pages;

public partial class EstadisticasPage : ContentPage
{
	public EstadisticasPage(EstadisticaPageModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is EstadisticaPageModel viewModel)
        {
            if (viewModel.AppearingCommand.CanExecute(null))
            {
                await viewModel.AppearingCommand.ExecuteAsync(null);
            }
        }
    }
}