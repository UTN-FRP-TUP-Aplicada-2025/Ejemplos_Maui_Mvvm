using Ejemplo_Login.Models;

namespace Ejemplo_Login.Services;

public class LoginService
{
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
            RecordarUsuario= recordarUsuario,
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
}
