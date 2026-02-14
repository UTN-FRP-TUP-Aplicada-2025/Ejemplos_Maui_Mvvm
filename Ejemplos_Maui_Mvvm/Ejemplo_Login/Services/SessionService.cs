
namespace Ejemplo_Login.Services;

public class SessionService
{
    const string KEY = "logged";

    public bool IsLogged => Preferences.Default.Get(KEY, false);

    public void Login() => Preferences.Default.Set(KEY, true);

    public void Logout()  => Preferences.Default.Remove(KEY);
}