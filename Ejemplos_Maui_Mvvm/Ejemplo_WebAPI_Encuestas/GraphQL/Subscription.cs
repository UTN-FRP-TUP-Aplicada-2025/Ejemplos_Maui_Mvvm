using Ejemplo_WebAPI_Encuestas.GraphQL.Events;

namespace Ejemplo_WebAPI_Encuestas.GraphQL;

public class Subscription
{
    [Subscribe]
    [Topic]
    public EncuestaActualizadoEvent OnPersonaActualizado([EventMessage] EncuestaActualizadoEvent input) => input;
}
