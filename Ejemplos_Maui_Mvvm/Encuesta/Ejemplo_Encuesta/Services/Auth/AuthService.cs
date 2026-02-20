using Ejemplo_Encuesta.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Ejemplo_Encuesta.Services.Auth;

public class AuthService
{
    private readonly HttpClient _http;

    //string url= "https://geometriafernando.somee.com/connect/token";

    public AuthService(HttpClient http)
    {
        _http = http;
    }

    public async Task<TokenResponse?> getTokenAsync(string user, string pass)
    {
        var form = new Dictionary<string, string>
        {
            ["grant_type"] = "password",
            ["username"] = user,
            ["password"] = pass,
            ["client_id"] = "client_id",
            ["client_secret"] = "secret", // si aplica
            ["scope"] = "api1 offline_access"
        };

        var response = await _http.PostAsync(//url
                                             "connect/token"
                                             , new FormUrlEncodedContent(form));

        if (!response.IsSuccessStatusCode)
            return null;

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TokenResponse>(json);
    }
}