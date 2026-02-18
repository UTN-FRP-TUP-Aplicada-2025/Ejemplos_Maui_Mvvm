using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejemplo_Login.Pages;

namespace Ejemplo_Login.PageModels;

public partial class DetailPageModel: ObservableObject
{
    public DetailPageModel()
    { }

    [RelayCommand]
    async private Task VerDialogNavigation()
    {        
        var dialog =new DialogNavigationPage();
        await Shell.Current.Navigation.PushAsync(dialog);
    }

    [RelayCommand]
    async private Task VerDialogShell()
    {
        await Shell.Current.GoToAsync(nameof(DialogShellPage));
    }
}
