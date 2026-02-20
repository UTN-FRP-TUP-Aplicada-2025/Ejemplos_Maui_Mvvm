using Ejemplo_Encuesta.Models;
using Ejemplo_Encuesta.Services.Auth;
namespace Ejemplo_Encuesta.Services;

public class LoginService
{
    string url = "https://geometriafernando.somee.com/graphql/";
    
    private readonly AuthService _authService;
    private readonly TokenStorageService _tokenStorage;

    public LoginService(AuthService authService, TokenStorageService tokenStorage)
    {
        _authService = authService;
        _tokenStorage = tokenStorage;
    }

    public LoginModel GetSession()
    {
        string usuario = Preferences.Default.Get<string>("Usuario", "");
        string clave = Preferences.Default.Get<string>("Clave", "");
        bool recordarUsuario = Preferences.Default.Get<bool>("RecordarUsuario", false);
        bool esActiva = Preferences.Default.Get<bool>("EsActiva", false);

        return new LoginModel()
        {
            Usuario = usuario,
            Clave = clave,
            RecordarUsuario = recordarUsuario,
            EsSessionActiva = esActiva
        };
    }

    public void SetSession(LoginModel session)
    {
        Preferences.Default.Set<string>("Usuario", session.Usuario);
        Preferences.Default.Set<string>("Clave", session.Clave);
        Preferences.Default.Set<bool>("RecordarUsuario", session.RecordarUsuario);
        Preferences.Default.Set<bool>("EsActiva", session.EsSessionActiva);
    }

    public async Task<bool> LoginAsync(string user, string pass)
    {
        var token = await _authService.getTokenAsync(user, pass);

        if (token == null || string.IsNullOrEmpty(token.AccessToken))
            return false;

        await _tokenStorage.SaveAsync(token);

        return true;
    }
}
