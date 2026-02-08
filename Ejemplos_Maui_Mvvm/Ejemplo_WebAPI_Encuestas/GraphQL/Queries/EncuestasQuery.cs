using Ejemplo_WebAPI_Encuestas.Models;
using Ejemplo_WebAPI_Encuestas.Services;

namespace Ejemplo_WebAPI_Encuestas.GraphQL.Queries;

public class EncuestasQuery
{
    EncuestasService _encuestasService = default!;

    public EncuestasQuery(EncuestasService encuestasService)
    {
        _encuestasService = encuestasService;
    }

    public IEnumerable<EncuestaModel> GetEncuestas()
    {
        return _encuestasService.GetByAll();
    }
}
