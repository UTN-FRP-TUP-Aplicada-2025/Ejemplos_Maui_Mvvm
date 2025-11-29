using Ejemplo_Single.PageModels;

namespace Ejemplo_Single.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }
}
