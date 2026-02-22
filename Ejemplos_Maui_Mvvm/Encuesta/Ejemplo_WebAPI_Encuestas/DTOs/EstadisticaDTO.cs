using Ejemplo_WebAPI_Encuestas.Models;

namespace Ejemplo_WebAPI_Encuestas.DTOs;

public class EstadisticaDTO
{
    public int Encuestados { get; set; }
    public double EdadPromedio { get; set; }
    public DateTime Fecha { get; set; }

    //no lo necesito - porque voy a incluir dos consultas en el query
    //public IEnumerable<EncuestaModel> Encuestas { get; set; }
}
