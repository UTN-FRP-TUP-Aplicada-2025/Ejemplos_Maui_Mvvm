namespace Ejemplo_WebAPI_Encuestas.Identity;

public interface IUserService
{
    InMemoryUser Validate(string username, string password);
}
