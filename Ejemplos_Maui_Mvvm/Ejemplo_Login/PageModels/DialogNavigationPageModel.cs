using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Ejemplo_Login.PageModels;

public partial class DialogNavigationPageModel:ObservableObject
{

    public DialogNavigationPageModel()
    { }

    [RelayCommand]
    async private Task Volver()
    {
        await Shell.Current.Navigation.PopAsync();
    }

}
