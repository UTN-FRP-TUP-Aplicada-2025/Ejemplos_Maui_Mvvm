
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Ejemplo_Login.PageModels;

public partial class DialogShellPageModel:ObservableObject
{

    [RelayCommand]
    async private Task Volver()
    {
        await Shell.Current.GoToAsync("..");
    }
}
