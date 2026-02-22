
using Ejemplo_MasterDetails.PageModels;

namespace Ejemplo_MasterDetails.Pages;

public partial class EstadisticasPage : ContentPage
{
    public EstadisticasPage(EstadisticasPageModel model)
    {
        InitializeComponent();
        this.BindingContext = model;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is EstadisticasPageModel vm)
        {
            vm.AppearingCommand.Execute(null);
        }
    }
}
