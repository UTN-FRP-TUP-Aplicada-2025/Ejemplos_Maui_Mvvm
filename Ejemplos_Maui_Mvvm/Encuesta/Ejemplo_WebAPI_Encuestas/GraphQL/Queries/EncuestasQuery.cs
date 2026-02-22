using Ejemplo_WebAPI_Encuestas.Models;
using Ejemplo_WebAPI_Encuestas.Services;
using Ejemplo_WebAPI_Encuestas.GraphQL.Types;

namespace Ejemplo_WebAPI_Encuestas.GraphQL.Queries;

[ExtendObjectType(typeof(Query))]
public class EncuestasQuery
{
    //public IEnumerable<EncuestaModel> GetEncuestas([Service] EncuestasService service)
    //{
    //    return service.GetByAll();
    //}
    //
    public IEnumerable<EncuestaModel> GetEncuestas(
                            [Service] EncuestasService service,
                            bool? ordenarPorFechaAlta,   // opcional: ordena DESC por fechaAlta
                            int? ultimos)                // opcional: trae los últimos X registros
    {
        var encuestas = service.GetByAll();

        if (ordenarPorFechaAlta == true)
            encuestas = encuestas.OrderBy(e => e.FechaAlta);

        if (ultimos.HasValue)
            encuestas = encuestas.OrderByDescending(e => e.FechaAlta)
                                 .Take(ultimos.Value)
                                 .OrderByDescending(e => e.FechaAlta); 

        return encuestas;
    }
}
