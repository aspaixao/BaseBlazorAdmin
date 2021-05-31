using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BaseBlazorAdmin
{
    public class JwtAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _storage;

        public JwtAuthenticationStateProvider(ILocalStorageService storage)
        {
            _storage = storage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if(await _storage.ContainKeyAsync("token"))
            {
                var tokenAsString = await _storage.GetItemAsStringAsync("token");
                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.ReadJwtToken(tokenAsString);
                var identity = new ClaimsIdentity(token.Claims, "Bearer");
                var user = new ClaimsPrincipal(identity);
                var authState = new AuthenticationState(user);

                NotifyAuthenticationStateChanged(Task.FromResult(authState));

                return authState;

            }

            return new AuthenticationState(new ClaimsPrincipal()); //Empty Claims
        }
    }
}
