using Ejemplo_WebAPI_Encuestas.GraphQL.Mutations;

namespace Ejemplo_WebAPI_Encuestas.GraphQL;

public class Mutation
{
    public EncuestasMutation Encuestas([Service] EncuestasMutation mutation) => mutation;
}
