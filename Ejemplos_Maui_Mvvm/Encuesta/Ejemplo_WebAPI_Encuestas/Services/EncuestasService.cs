using Ejemplo_WebAPI_Encuestas.Data;
using Ejemplo_WebAPI_Encuestas.DTOs;
using Ejemplo_WebAPI_Encuestas.Models;

namespace Ejemplo_WebAPI_Encuestas.Services;

public class EncuestasService
{
    public IEnumerable<EncuestaModel> GetByAll()
    {
        return BancoDeDatos.Encuestas;
    }


    public EncuestaModel Create(EncuestaModel EncuestaModel)
    {
        BancoDeDatos.Encuestas.Add(EncuestaModel);
        return EncuestaModel;
    }

    public EncuestaModel Update(EncuestaModel EncuestaModel)
    {
        //EncuestaModel p = GetByDNI(EncuestaModel.DNI);
        //if (p != null)
        //{
        //    p.Nombre = EncuestaModel.Nombre;
        //    return EncuestaModel;
        //}
        return null;
    }

    public bool Delete(int dni)
    {
        //EncuestaModel p = GetByDNI(dni);
        //BancoDeDatos.EncuestaModels.Remove(p);
        return true;
    }

    public EstadisticaDTO GetEstadistica()
    {
        var encuestas = GetByAll();


        var estadistica = new EstadisticaDTO
        {
            Encuestados = encuestas?.Count()??0,
            EdadPromedio = (from e in encuestas
                            let edad = (DateTime.Now - e.FechaNacimiento).TotalDays / 365.0
                                select edad into edad
                                where edad > 0
                            select edad
                            ).DefaultIfEmpty(0).Average(),
            Fecha = DateTime.Now,
            //Encuestas = encuestas
        };
        return estadistica;
    }
}
