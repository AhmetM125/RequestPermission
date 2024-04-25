using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using RequestPermission.ViewModels.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RequestPermission.Base;

public class AuthorizationProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private string TokenKey = "RandomTokenName";
    private AuthenticationState Anonymous => new(new(new ClaimsIdentity()));
    public AuthorizationProvider(HttpClient httpClient, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _localStorage = localStorageService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var savedToken = await _localStorage.GetItemAsync<TokenVM>(TokenKey);
            if (savedToken == null)
                return Anonymous;
            return BuildAuthenticatedState(savedToken);

        }
        catch
        {
            return new(new(new ClaimsIdentity()));
        }
    }
    private AuthenticationState BuildAuthenticatedState(TokenVM savedToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new("bearer", savedToken.Token);
        return new(new(new ClaimsIdentity(ParseClaimsFromJwt(savedToken.Token), "apiauth")));
    }
    public async Task<bool> MarkUserAsAuthenticated(TokenVM token, bool writeToStorage = true)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token.Token);
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token.Token), "apiauth"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
            if (writeToStorage)
                await _localStorage.SetItemAsync(TokenKey, token.Token);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        if (handler.ReadToken(jwt) is not JwtSecurityToken tokenS) return null;

        var username = tokenS.Claims.FirstOrDefault(claim => claim.Type == "username");
        return new Claim[]
         {
            new("username", username?.Value),
         };
    }
}
