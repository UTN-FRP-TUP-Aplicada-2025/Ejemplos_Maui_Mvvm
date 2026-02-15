using Ejemplo_Login.Models;

namespace Ejemplo_Login.Services;

public class LoginService
{
    public LoginModel GetSession()
    {
        string usuario = Preferences.Default.Get<string>("Usuario", "");
        string clave = Preferences.Default.Get<string>("Clave", "");
        bool esActiva = Preferences.Default.Get<bool>("EsActiva", false);

        return new LoginModel()
        {
            Usuario = usuario,
            Clave = clave,
            EsSessionActiva = esActiva
        };
    }

    public void SetSession(LoginModel session)
    {
       Preferences.Default.Set<string>("Usuario", session.Usuario);
       Preferences.Default.Set<string>("Clave", session.Clave);
       Preferences.Default.Set<bool>("EsActiva", session.EsSessionActiva);
    }
}
