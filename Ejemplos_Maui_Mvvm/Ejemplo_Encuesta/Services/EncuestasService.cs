using Ejemplo_Encuesta.Models;
using Ejemplo_Encuesta.Services.graphql;
using System.Net.Http.Json;
using System.Text.Json;

namespace Ejemplo_Encuesta.Services;

public class EncuestasService
{
    string url = "https://geometriafernando.somee.com/graphql/";

    async public Task RegistrarEncuesta(EncuestaModel model)
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

    public async Task<EstadisticaModel> ObtenerEstadisticasAsync()
    {
        using HttpClient client = new HttpClient();

        client.BaseAddress = new Uri(url);

        //formato de fecha "2000-02-02T00:00:00Z"

        var query = new
        {
            query = $@"
query 
{{
    estadistica 
    {{
        edadPromedio
        encuestados
        fecha
    }}
}}"
        };

        var response = await client.PostAsJsonAsync("", query);
        response.EnsureSuccessStatusCode();
        
        var option = new JsonSerializerOptions { PropertyNameCaseInsensitive =true, };
        //var data=await response.Content.ReadFromJsonAsync<Data?>(option);

        //{"data":{"estadistica":{"edadPromedio":0.002043319358171613,"encuestados":1,"fecha":"2026-02-10T17:53:58.119-06:00"}}}
        var responseBody = await response.Content.ReadAsStringAsync();

        var dataQuery = JsonSerializer.Deserialize<EstadisticaQueryType?>(responseBody, option);


        return new EstadisticaModel
        {
            Encuestados = dataQuery?.Data?.Estadistica?.Encuestados ?? 0,
            EdadPromedio = dataQuery?.Data?.Estadistica?.EdadPromedio ?? 0,
            Fecha = dataQuery?.Data?.Estadistica?.Fecha??DateTime.MinValue,
        };
        /*
        {
          "data": {
            "estadistica": {
              "edadPromedio": 0,
              "encuestados": 0,
              "fecha": "2026-02-10T16:57:50.029-06:00"
            }
          }
        }*/
    }
}
