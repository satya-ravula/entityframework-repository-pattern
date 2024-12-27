using DemoService.Domain.Models;
using DemoService.Infrastructure.Helpers;
using DemoService.Infrastructure.Interfaces;
using DemoService.Infrastructure.Models;
using System.Collections.Concurrent;
using System.Text.Json;

namespace DemoService.Infrastructure.ApiClients
{
    /// <summary>
    /// Provides token retrieval for API requests.
    /// </summary>
    public class YassiTokenProvider : IYassiTokenProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly YassiApiSettings _apiSettings;
        private readonly ConcurrentDictionary<string, TokenResponse> _tokenCache;
        private readonly AsyncLock _mutex;
        private const int TokenExpirationOffsetSeconds = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="YassiTokenProvider"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HttpClient factory.</param>
        /// <param name="apiSettings">The client token settings.</param>
        public YassiTokenProvider(IHttpClientFactory httpClientFactory, YassiApiSettings apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings;
            _tokenCache = new ConcurrentDictionary<string, TokenResponse>();
            _mutex = new AsyncLock();
        }

        /// <summary>
        /// Retrieves the client credentials token asynchronously.
        /// </summary>
        /// <param name="parameters">Token parameters containing client ID, secret, and other optional fields.</param>
        /// <returns>The client credentials token as a string.</returns>
        public async Task<string> GetToken(TokenParameters parameters)
        {
            var cancellationToken =
                new CancellationTokenSource(
                    TimeSpan.FromMilliseconds(_apiSettings.TimeoutInMilliseconds)).Token;

            string clientId = parameters.ClientId;

            using (await _mutex.LockAsync())
            {
                try
                {
                    // Check if a cached token exists and is still valid for the given client ID
                    if (_tokenCache.TryGetValue(clientId, out var cachedToken) && !cachedToken.IsExpired())
                    {
                        return FormattedAuthorizationHeader(cachedToken);
                    }

                    // Prepare the token request payload
                    List<KeyValuePair<string, string>> requestDataList = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("grant_type", _apiSettings.GrantType),
                        new KeyValuePair<string, string>("client_id", parameters.ClientId),
                        new KeyValuePair<string, string>("client_secret", parameters.ClientSecret)
                    };

                    if (!string.IsNullOrWhiteSpace(parameters.Scope))
                    {
                        requestDataList.Add(new KeyValuePair<string, string>("scope", parameters.Scope));
                    }

                    if (!string.IsNullOrWhiteSpace(parameters.Subject))
                    {
                        requestDataList.Add(new KeyValuePair<string, string>("subject", parameters.Subject));
                    }

                    var requestData = new FormUrlEncodedContent(requestDataList);

                    // Make the token request
                    var response = await _httpClientFactory.CreateClient().PostAsync(
                        new Uri(_apiSettings.TokenUrl), requestData, cancellationToken);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseContent);
                        if (tokenResponse != null)
                        {
                            SetTokenCache(clientId, tokenResponse);

                            return FormattedAuthorizationHeader(tokenResponse);
                        }
                    }
                    else
                    {
                        // TODO: logging
                    }
                }
                catch (TaskCanceledException)
                {
                    // TODO: logging
                }
                catch (Exception)
                {
                    // TODO: logging
                }

                return string.Empty;
            }
        }

        #region Private Methods

        private string FormattedAuthorizationHeader(TokenResponse tokenResponse)
        {
            return $"Bearer {tokenResponse.AccessToken}";
        }

        private void SetTokenCache(string clientId, TokenResponse tokenResponse)
        {
            tokenResponse.ExpiryUtc = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn - TokenExpirationOffsetSeconds);
            _tokenCache[clientId] = tokenResponse;
        }

        #endregion
    }

}
