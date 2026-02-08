using Ejemplo_WebAPI_Encuestas.GraphQL.Mutations;

namespace Ejemplo_WebAPI_Encuestas.GraphQL;

public class Mutation
{
    public EncuestasMutation Personas([Service] EncuestasMutation mutation) => mutation;
}
