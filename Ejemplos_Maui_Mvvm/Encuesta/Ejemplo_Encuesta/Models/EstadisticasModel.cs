namespace Ejemplo_Encuesta.Models;

public class EstadisticasModel
{
    public int Encuestados { get; set; }
    public double EdadPromedio { get; set; }
    public DateTime Fecha { get; set; }

    public IEnumerable<EncuestaModel> Encuestas { get; set; }
}
