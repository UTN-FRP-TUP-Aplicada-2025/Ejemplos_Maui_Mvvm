using Ejemplo_Encuesta.PageModels;

namespace Ejemplo_Encuesta.Pages;

public partial class EstadisticasPage : ContentPage
{
	public EstadisticasPage(EstadisticasPageModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is EstadisticasPageModel viewModel)
        {
            if (viewModel.AppearingCommand.CanExecute(null))
            {
                await viewModel.AppearingCommand.ExecuteAsync(null);
            }
        }
    }
}