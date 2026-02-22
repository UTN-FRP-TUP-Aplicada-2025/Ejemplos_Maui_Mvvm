using Ejemplo_WebAPI_Encuestas.GraphQL.Events;
using Ejemplo_WebAPI_Encuestas.GraphQL.Inputs;
using Ejemplo_WebAPI_Encuestas.GraphQL.Subscriptions;
using Ejemplo_WebAPI_Encuestas.Models;
using Ejemplo_WebAPI_Encuestas.Services;
using HotChocolate.Subscriptions;

namespace Ejemplo_WebAPI_Encuestas.GraphQL.Mutations;

public class EncuestasMutation
{
    EncuestasService _encuestasService = default!;

    private readonly ITopicEventSender _eventSender;
    public EncuestasMutation(EncuestasService encuestasService, ITopicEventSender eventSender)
    {
        _encuestasService = encuestasService;
        _eventSender = eventSender;
    }

    public EncuestaModel CrearEncuesta(CrearEncuestaInput input)
    {
        var persona = new EncuestaModel
        {
            Nombre = input.Nombre,
            FechaNacimiento = input.FechaNacimiento,
            FechaAlta = DateTime.Now
        };

        return _encuestasService.Create(persona);
    }

    public async Task<EncuestaModel> ActualizarEncuesta(ActualizarEncuestaInput input)
    {
        var encuesta = _encuestasService.Update(
            new EncuestaModel
            {
                Nombre = input.Nombre, 
                FechaNacimiento = input.FechaNacimiento
            }
        );

        await _eventSender.SendAsync(
            nameof(EncuestasSubscription.OnEncuestaActualizada),
            new EncuestaActualizadoEvent
            {
                Nombre = encuesta.Nombre,
                FechaNacimiento = input.FechaNacimiento
            });


        return encuesta;
    }

    public bool EliminarEncuesta(int dni)
    {
        return _encuestasService.Delete(dni);
    }
}
