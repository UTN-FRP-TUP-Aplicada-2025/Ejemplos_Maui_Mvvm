using Ejemplo_Tabs.PageModels;

namespace Ejemplo_Tabs.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }

}
