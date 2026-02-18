using System;
using System.Collections.Generic;
using System.Text;

namespace Ejemplo_Encuesta.Services.graphql;

public class EstadisticaQueryType
{
    public Data? Data { get; set; }
}

public class Data
{
   public Estadistica? Estadistica { get; set; }
}

public class Estadistica
{
    public int? Encuestados { get; set; }
    public double? EdadPromedio { get; set; }
    public DateTime? Fecha { get; set; }
}