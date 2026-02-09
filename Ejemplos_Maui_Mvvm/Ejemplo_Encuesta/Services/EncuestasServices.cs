using Ejemplo_Encuesta.PageModels;
using System.Net.Http.Json;

namespace Ejemplo_Encuesta.Services;

public class EncuestasServices
{
    string url = "https://geometriafernando.somee.com/graphql/";

    async public Task RegistrarEncuesta(EncuestaPageModel model)
    {
        using HttpClient client = new HttpClient();

        client.BaseAddress = new Uri(url);

        //formato de fecha "2000-02-02T00:00:00Z"

        var query = new
        {
            query = $@"
    mutation {{
      encuestas {{
        crearEncuesta(input: {{ nombre: ""{model.Nombre}"", fechaNacimiento: ""{model.FechaNacimiento:yyyy-MM-ddTHH:mm:ssZ}"" }}) {{
          nombre
          fechaNacimiento
        }}
      }}
    }}"
        };

        var response = await client.PostAsJsonAsync("", query);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

    }
  
}
