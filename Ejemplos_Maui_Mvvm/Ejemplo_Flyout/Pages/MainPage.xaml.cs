using Ejemplo_Flyout.PageModels;

namespace Ejemplo_Flyout.Pages;

public partial class MainPage : ContentPage
{
    
    public MainPage(MainPageModel model)
    {
        InitializeComponent();

        BindingContext = model;
    }

}
