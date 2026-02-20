using Ejemplo_Encuesta.Models.Auth;

namespace Ejemplo_Encuesta.Services.Auth;

public class TokenStorageService
{
    


    public async Task SaveAsync(TokenResponse token)
    {
        await SecureStorage.SetAsync("access_token", token.AccessToken);

        if (!string.IsNullOrEmpty(token.RefreshToken))                                          
            await SecureStorage.SetAsync("refresh_token", token.RefreshToken);
    }

    public async Task<string?> GetAccessTokenAsync()
    {
        return await SecureStorage.GetAsync("access_token");
    }

    public void Clear()
    {
        SecureStorage.RemoveAll();
    }
}
