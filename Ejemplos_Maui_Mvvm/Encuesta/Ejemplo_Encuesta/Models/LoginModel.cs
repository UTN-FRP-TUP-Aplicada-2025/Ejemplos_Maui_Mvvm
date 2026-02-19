namespace Ejemplo_Encuesta.Models;

public class LoginModel
{
    public string Usuario { get; set; }
    public string Clave { get; set; }
    public bool RecordarUsuario { get; set; }
    public bool EsSessionActiva { get; set; }
}
