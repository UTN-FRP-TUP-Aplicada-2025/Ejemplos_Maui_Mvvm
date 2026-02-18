using Ejemplo_WebAPI_Encuestas.GraphQL.Events;

namespace Ejemplo_WebAPI_Encuestas.GraphQL.Subscriptions;

public class EncuestasSubscription
{
    [Subscribe]
    [Topic]
    public EncuestaActualizadoEvent OnEncuestaActualizada([EventMessage] EncuestaActualizadoEvent input) => input;
}