
using Ejemplo_MasterDetails.PageModels;

namespace Ejemplo_MasterDetails.Pages;

public partial class EstadisticaPage : ContentPage
{
    public EstadisticaPage(EstadisticaPageModel model)
    {
        InitializeComponent();
        this.BindingContext = model;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is EstadisticaPageModel vm)
        {
            vm.AppearingCommand.Execute(null);
        }
    }
}
