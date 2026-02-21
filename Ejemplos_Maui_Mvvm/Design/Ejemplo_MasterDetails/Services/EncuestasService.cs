using Ejemplo_MasterDetails.Models;
using Ejemplo_MasterDetails.PageModels;

namespace Ejemplo_MasterDetails.Services;

public class EncuestasService
{
    async public Task<EstadisticaModel> ObtenerEstadisticasAsync()
    {
        EstadisticaModel estadistica = new() { Encuestados = 3, EdadPromedio=1.0, Fecha = DateTime.Now };
        return estadistica;
    }

    public async Task<IEnumerable<EncuestaModel>> ObtenerUltimosEncuestadosAsync()
    {
        var resultado = new List<EncuestaModel>()
        {
            new EncuestaModel() { Nombre = "Ana", FechaNacimiento = new DateTime(1990, 3, 10) },
            new EncuestaModel() { Nombre = "Valeria", FechaNacimiento = new DateTime(1995, 2, 15) },
            new EncuestaModel() { Nombre = "Leo", FechaNacimiento = new DateTime(1991, 10, 7) },
        };
        return resultado;
    }
}
