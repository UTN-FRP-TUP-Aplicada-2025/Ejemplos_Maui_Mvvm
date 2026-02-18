using Ejemplo_WebAPI_Encuestas.GraphQL.Queries;
using HotChocolate.Authorization;

namespace Ejemplo_WebAPI_Encuestas.GraphQL;

[Authorize]
public class Query
{
    //public EncuestasQuery Encuestas([Service] EncuestasQuery query) => query;
}
