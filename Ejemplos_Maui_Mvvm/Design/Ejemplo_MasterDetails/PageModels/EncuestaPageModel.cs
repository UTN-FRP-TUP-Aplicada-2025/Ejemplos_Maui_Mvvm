
using CommunityToolkit.Mvvm.ComponentModel;

namespace Ejemplo_MasterDetails.PageModels;

public partial class EncuestaPageModel : ObservableObject
{
    [ObservableProperty]
    public string nombre = string.Empty;

    [ObservableProperty]
    public DateTime fechaNacimiento = DateTime.MinValue;
}
