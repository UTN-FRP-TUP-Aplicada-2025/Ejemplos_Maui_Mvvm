using Ejemplo_WebAPI_Encuestas.DTOs;
using Ejemplo_WebAPI_Encuestas.Models;
using Ejemplo_WebAPI_Encuestas.Services;

namespace Ejemplo_WebAPI_Encuestas.GraphQL.Queries;


[ExtendObjectType(typeof(Query))]
public class EstadisticaQuery
{
    public EstadisticaDTO GetEstadistica([Service] EncuestasService service)
    {
        return service.GetEstadistica();
    }
}
