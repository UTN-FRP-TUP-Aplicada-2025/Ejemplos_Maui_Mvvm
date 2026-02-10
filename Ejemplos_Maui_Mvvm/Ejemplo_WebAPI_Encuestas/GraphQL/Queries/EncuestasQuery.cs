using Ejemplo_WebAPI_Encuestas.Models;
using Ejemplo_WebAPI_Encuestas.Services;
using Ejemplo_WebAPI_Encuestas.GraphQL.Types;

namespace Ejemplo_WebAPI_Encuestas.GraphQL.Queries;

[ExtendObjectType(typeof(Query))]
public class EncuestasQuery
{
    public IEnumerable<EncuestaModel> GetEncuestas([Service] EncuestasService service)
    {
        return service.GetByAll();
    }                
}
