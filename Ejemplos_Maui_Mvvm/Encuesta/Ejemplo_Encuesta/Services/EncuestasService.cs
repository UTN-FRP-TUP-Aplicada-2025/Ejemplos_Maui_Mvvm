using Ejemplo_Encuesta.Models;
using Ejemplo_Encuesta.Services.Auth;
using Ejemplo_Encuesta.Services.graphql;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Ejemplo_Encuesta.Services;

public class EncuestasService
{
   // string url = "https://geometriafernando.somee.com/graphql/";

    readonly AuthService _authService;
    readonly TokenStorageService _tokenStorage;

    readonly HttpClient _http;


    public EncuestasService(HttpClient http,  AuthService authService, TokenStorageService tokenStorage)
    {
        _authService = authService;
        _tokenStorage = tokenStorage;
        _http = http;
    }

    async public Task RegistrarEncuesta(EncuestaModel model)
    {
        //using HttpClient client = new HttpClient();

        //client.BaseAddress = new Uri(url);

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

        var response = await _http.PostAsJsonAsync("graphql/", query);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

    }

    public async Task<EstadisticasModel> ObtenerEstadisticasAsync()
    {
        var accessToken = await _tokenStorage.GetAccessTokenAsync();

        if (string.IsNullOrEmpty(accessToken)) throw new Exception("Usuario no autenticado.");

        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        //client.BaseAddress = new Uri(url);

        //formato de fecha "2000-02-02T00:00:00Z"

        var query = new
        {
//            query = $@"
//query 
//{{
//    estadistica 
//    {{
//        edadPromedio
//        encuestados
//        fecha
//    }}
//}}"

           query = $@"
query {{
  encuestas(ultimos: 5, ordenarPorFechaAlta: null) {{
    fechaNacimiento
    nombre
  }}
  estadistica {{
    edadPromedio
    encuestados
    fecha
  }}
}}
"      };

        var response = await _http.PostAsJsonAsync("graphql/", query);
        response.EnsureSuccessStatusCode();
        
        var option = new JsonSerializerOptions { PropertyNameCaseInsensitive =true, };
        //var data=await response.Content.ReadFromJsonAsync<Data?>(option);

        //{"data":{"estadistica":{"edadPromedio":0.002043319358171613,"encuestados":1,"fecha":"2026-02-10T17:53:58.119-06:00"}}}
        var responseBody = await response.Content.ReadAsStringAsync();

        var dataQuery = JsonSerializer.Deserialize<EstadisticaQueryType?>(responseBody, option);

        //Mapeo
        return new EstadisticasModel
        {
            Encuestados = dataQuery?.Data?.Estadistica?.Encuestados ?? 0,
            EdadPromedio = dataQuery?.Data?.Estadistica?.EdadPromedio ?? 0,
            Fecha = dataQuery?.Data?.Estadistica?.Fecha??DateTime.MinValue,
            Encuestas = (
                            from e in dataQuery?.Data?.Encuestas
                            select new EncuestaModel
                            {
                                Nombre = e.Nombre,
                                FechaNacimiento = e.FechaNacimiento??DateTime.MinValue
                            }
                        ).ToList()
        };
        /* antes con una sola query
        {
          "data": {
            "estadistica": {
              "edadPromedio": 0,
              "encuestados": 0,
              "fecha": "2026-02-10T16:57:50.029-06:00"
            }
          }
        }*/

        /* lo esperado ahora con dos queries en una
        {
          "data": {
            "encuestas": [
              {
                "fechaNacimiento": "2026-02-22T00:00:00.000Z",
                "nombre": "Ana"
              },
              {
                "fechaNacimiento": "2020-02-22T00:00:00.000Z",
                "nombre": "Valeria"
              },
              {
                "fechaNacimiento": "2021-02-22T00:00:00.000Z",
                "nombre": "Gustavo"
              }
            ],
            "estadistica": {
              "edadPromedio": 0.0009156593583565872,
              "encuestados": 3,
              "fecha": "2026-02-22T08:01:16.233-06:00"
            }
          }
        }         
         */
    }


}
