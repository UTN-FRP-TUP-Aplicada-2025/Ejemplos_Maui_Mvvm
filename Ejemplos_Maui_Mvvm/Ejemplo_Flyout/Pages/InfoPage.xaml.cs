namespace Ejemplo_Flyout.Pages;

public partial class InfoPage : ContentPage
{
    
    public InfoPage(MainPageModel model)
    {
        InitializeComponent();

        BindingContext = model;
    }

}
