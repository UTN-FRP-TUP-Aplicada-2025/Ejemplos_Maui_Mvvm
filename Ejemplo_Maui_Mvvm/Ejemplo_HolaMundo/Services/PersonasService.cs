using Ejemplo_HolaMundo.Models;

namespace Ejemplo_HolaMundo.Services;

public class PersonasService
{
    List<PersonaModel> personas=new List<PersonaModel>()
    {
        new PersonaModel(){ Nombre="Juan"},
        new PersonaModel(){ Nombre="María"},
        new PersonaModel(){ Nombre="Pedro"},
        new PersonaModel(){ Nombre="Ana"},
        new PersonaModel(){ Nombre="Luis"},
    };

    public List<PersonaModel> List()
    {
        return personas;
    }
}
