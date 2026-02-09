using Ejemplo_WebAPI_Encuestas.GraphQL.Queries;

namespace Ejemplo_WebAPI_Encuestas.GraphQL;

public class Query
{
    public EncuestasQuery Encuestas([Service] EncuestasQuery query) => query;
}
