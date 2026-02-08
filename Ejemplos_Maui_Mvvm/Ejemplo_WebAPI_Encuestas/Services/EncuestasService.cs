using Ejemplo_WebAPI_Encuestas.Data;
using Ejemplo_WebAPI_Encuestas.Models;

namespace Ejemplo_WebAPI_Encuestas.Services;

public class EncuestasService
{
    public List<EncuestaModel> GetByAll()
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
}
