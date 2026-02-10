
using CommunityToolkit.Mvvm.ComponentModel;

namespace Ejemplo_Encuesta.PageModels;

public partial class EstadisticaPageModel : ObservableObject
{
    [ObservableProperty]
    int  encuestados;

    [ObservableProperty]
    int edadPromedio;

    [ObservableProperty]
    DateTime fecha;

}
