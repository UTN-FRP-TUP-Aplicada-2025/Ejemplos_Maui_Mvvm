namespace Ejemplo_WebAPI_Encuestas.Identity
{
    public class InMemoryUserService : IUserService
    {
        private static List<InMemoryUser> _users = new()
    {
        new InMemoryUser
        {
            Id = "1",
            Username = "fernando",
            Password = "1234",
            Role = "Admin"
        }
    };

        public InMemoryUser Validate(string username, string password)
        {
            return _users.FirstOrDefault(x =>
                x.Username == username &&
                x.Password == password);
        }
    }

}
