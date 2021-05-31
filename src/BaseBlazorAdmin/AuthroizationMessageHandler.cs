using Blazored.LocalStorage;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BaseBlazorAdmin
{
    public class AuthroizationMessageHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _storage;

        public AuthroizationMessageHandler(ILocalStorageService storage)
        {
            _storage = storage;
        }

        protected  async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (await _storage.ContainKeyAsync("token"))
            {
                var token = await _storage.GetItemAsStringAsync("token");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

#if DEBUG
            Console.WriteLine("Authorization Message Handler Called");
#endif

            return await base.SendAsync(request, cancellationToken);

        }
    }
}
