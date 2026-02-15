using Ejemplo_Login.PageModels;

namespace Ejemplo_Login.Pages;

public partial class MainPage : ContentPage
{
  
    public MainPage(MainPageModel model)
    {
        InitializeComponent();
        this.BindingContext = model;
    }

}
