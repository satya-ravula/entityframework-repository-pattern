using DemoService.Infrastructure.Constants;
using DemoService.Infrastructure.Extensions;
using DemoService.Infrastructure.Interfaces;
using DemoService.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoService.Infrastructure.ApiClients
{
    /// <summary>
    /// Represents a REST client that provides methods for sending HTTP requests and receiving responses.
    /// </summary>
    public class RestClient : IRestClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<RestClient> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClient"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The factory for creating HttpClient instances.</param>
        /// <param name="logger">The Logger instances.</param>
        public RestClient(IHttpClientFactory httpClientFactory, ILogger<RestClient> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        /// <summary>
        /// Sends an HTTP GET request and returns the response.
        /// </summary>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response.</returns>
        public async Task<RestResponse> Get(RestRequest request)
        {
            return await SendRequestAsync(HttpMethod.Get, request);
        }

        /// <summary>
        /// Sends an HTTP GET request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response with deserialized content.</returns>
        public async Task<RestResponse<TResponse>> Get<TResponse>(RestRequest request)
        {
            return await SendRequestAsync<TResponse>(HttpMethod.Get, request);
        }

        /// <summary>
        /// Sends an HTTP POST request and returns the response.
        /// </summary>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response.</returns>
        public async Task<RestResponse> Post(RestRequest request)
        {
            return await SendRequestAsync(HttpMethod.Post, request);
        }

        /// <summary>
        /// Sends an HTTP POST request and returns the response.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data.</typeparam>
        /// <param name="request">The REST request configuration with request data.</param>
        /// <returns>The REST response.</returns>
        public async Task<RestResponse> Post<TRequest>(RestRequest<TRequest> request)
        {
            return await SendRequestAsync(HttpMethod.Post, request, request.Data);
        }

        /// <summary>
        /// Sends an HTTP POST request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data.</typeparam>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration with request data.</param>
        /// <returns>The REST response with deserialized content.</returns>
        public async Task<RestResponse<TResponse>> Post<TRequest, TResponse>(RestRequest<TRequest> request)
        {
            return await SendRequestAsync<TResponse>(HttpMethod.Post, request, request.Data);
        }

        /// <summary>
        /// Sends an HTTP POST request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response with deserialized content.</returns>
        public async Task<RestResponse<TResponse>> Post<TResponse>(RestRequest request)
        {
            return await SendRequestAsync<TResponse>(HttpMethod.Post, request);
        }

        /// <summary>
        /// Sends an HTTP PUT request and returns the response.
        /// </summary>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response.</returns>
        public async Task<RestResponse> Put(RestRequest request)
        {
            return await SendRequestAsync(HttpMethod.Put, request);
        }

        /// <summary>
        /// Sends an HTTP PUT request and returns the response.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data.</typeparam>
        /// <param name="request">The REST request configuration with request data.</param>
        /// <returns>The REST response.</returns>
        public async Task<RestResponse> Put<TRequest>(RestRequest<TRequest> request)
        {
            return await SendRequestAsync(HttpMethod.Put, request, request.Data);
        }

        /// <summary>
        /// Sends an HTTP PUT request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data.</typeparam>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration with request data.</param>
        /// <returns>The REST response with deserialized content.</returns>
        public async Task<RestResponse<TResponse>> Put<TRequest, TResponse>(RestRequest<TRequest> request)
        {
            return await SendRequestAsync<TResponse>(HttpMethod.Put, request, request.Data);
        }

        /// <summary>
        /// Sends an HTTP PUT request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response with deserialized content.</returns>
        public async Task<RestResponse<TResponse>> Put<TResponse>(RestRequest request)
        {
            return await SendRequestAsync<TResponse>(HttpMethod.Put, request);
        }

        /// <summary>
        /// Sends an HTTP PATCH request and returns the response.
        /// </summary>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response.</returns>
        public async Task<RestResponse> Patch(RestRequest request)
        {
            return await SendRequestAsync(HttpMethod.Patch, request);
        }

        /// <summary>
        /// Sends an HTTP PATCH request and returns the response.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data.</typeparam>
        /// <param name="request">The REST request configuration with request data.</param>
        /// <returns>The REST response.</returns>
        public async Task<RestResponse> Patch<TRequest>(RestRequest<TRequest> request)
        {
            return await SendRequestAsync(HttpMethod.Patch, request, request.Data);
        }

        /// <summary>
        /// Sends an HTTP PATCH request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data.</typeparam>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration with request data.</param>
        /// <returns>The REST response with deserialized content.</returns>
        public async Task<RestResponse<TResponse>> Patch<TRequest, TResponse>(RestRequest<TRequest> request)
        {
            return await SendRequestAsync<TResponse>(HttpMethod.Patch, request, request.Data);
        }

        /// <summary>
        /// Sends an HTTP PATCH request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response with deserialized content.</returns>
        public async Task<RestResponse<TResponse>> Patch<TResponse>(RestRequest request)
        {
            return await SendRequestAsync<TResponse>(HttpMethod.Patch, request);
        }

        /// <summary>
        /// Sends an HTTP DELETE request and returns the response.
        /// </summary>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response.</returns>
        public async Task<RestResponse> Delete(RestRequest request)
        {
            return await SendRequestAsync(HttpMethod.Delete, request);
        }

        /// <summary>
        /// Sends an HTTP DELETE request and returns the response.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data.</typeparam>
        /// <param name="request">The REST request configuration with request data.</param>
        /// <returns>The REST response.</returns>
        public async Task<RestResponse> Delete<TRequest>(RestRequest<TRequest> request)
        {
            return await SendRequestAsync(HttpMethod.Delete, request, request.Data);
        }

        /// <summary>
        /// Sends an HTTP DELETE request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data.</typeparam>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration with request data.</param>
        /// <returns>The REST response with deserialized content.</returns>
        public async Task<RestResponse<TResponse>> Delete<TRequest, TResponse>(RestRequest<TRequest> request)
        {
            return await SendRequestAsync<TResponse>(HttpMethod.Delete, request, request.Data);
        }

        /// <summary>
        /// Sends an HTTP DELETE request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response with deserialized content.</returns>
        public async Task<RestResponse<TResponse>> Delete<TResponse>(RestRequest request)
        {
            return await SendRequestAsync<TResponse>(HttpMethod.Delete, request);
        }

        #region Private Methods

        private async Task<RestResponse<TResponse>> SendRequestAsync<TResponse>(HttpMethod method, RestRequest request, object data = null)
        {
            var cancellationToken = new CancellationTokenSource(TimeSpan.FromMilliseconds(request.TimeoutInMilliseconds)).Token;
            RestResponse<TResponse> response;
            string requestJson = null;
            try
            {
                request.IsValid();

                var httpRequest = new HttpRequestMessage(method, request.Url);
                AddHeaders(httpRequest, request.Headers);

                if (data != null)
                {
                    if (request.ContentType == ContentTypes.Json)
                    {
                        var options = new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                        };
                        requestJson = JsonSerializer.Serialize(data, options);
                        var content = new StringContent(requestJson, Encoding.UTF8, request.ContentType);
                        httpRequest.Content = content;
                    }
                    else
                    {
                        httpRequest.Content = data as HttpContent;
                    }
                }

                var httpResponse = await _httpClientFactory.CreateClient().SendAsync(httpRequest, cancellationToken);
                response = await HandleResponse<TResponse>(httpResponse);
            }
            catch (TaskCanceledException tex)
            {
                if (tex.CancellationToken.IsCancellationRequested)
                {
                    // Handle timeout
                    response = CreateErrorResponse<TResponse>("Request timed out.", tex, HttpStatusCode.RequestTimeout);
                }
                else
                {
                    // Handle other task cancellation (e.g., external cancellation)
                    response = CreateErrorResponse<TResponse>("Request cancelled.", tex, HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                response = CreateErrorResponse<TResponse>(ex.Message, ex);
            }
            LogRequestResponse(request, response, requestJson);
            return response;
        }

        private async Task<RestResponse> SendRequestAsync(HttpMethod method, RestRequest request, object data = null)
        {
            var cancellationToken = new CancellationTokenSource(TimeSpan.FromMilliseconds(request.TimeoutInMilliseconds)).Token;
            RestResponse response;
            string requestJson = null;
            try
            {
                request.IsValid();

                var httpRequest = new HttpRequestMessage(method, request.Url);

                AddHeaders(httpRequest, request.Headers);

                if (data != null)
                {
                    if (request.ContentType == ContentTypes.Json)
                    {
                        var options = new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                        };
                        requestJson = JsonSerializer.Serialize(data, options);
                        var content = new StringContent(requestJson, Encoding.UTF8, request.ContentType);
                        httpRequest.Content = content;
                    }
                    else
                    {
                        httpRequest.Content = data as HttpContent;
                    }
                }

                var httpResponse = await _httpClientFactory.CreateClient().SendAsync(httpRequest, cancellationToken);
                response = await HandleResponse(httpResponse);
            }
            catch (TaskCanceledException tex)
            {
                if (tex.CancellationToken.IsCancellationRequested)
                {
                    // Handle timeout
                    response = CreateErrorResponse("Request timed out.", tex, HttpStatusCode.RequestTimeout);
                }
                else
                {
                    // Handle other task cancellation (e.g., external cancellation)
                    response = CreateErrorResponse("Request cancelled.", tex, HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                response = CreateErrorResponse(ex.Message, ex);
            }
            LogRequestResponse(request, response, requestJson);
            return response;
        }

        private void AddHeaders(HttpRequestMessage request, Dictionary<string, string> headers)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
        }

        private async Task<RestResponse<TResponse>> HandleResponse<TResponse>(HttpResponseMessage response)
        {
            var restResponse = new RestResponse<TResponse>
            {
                IsSuccess = response.IsSuccessStatusCode,
                StatusCode = response.StatusCode,
                Content = await response.Content.ReadAsStringAsync()
            };

            if (restResponse.IsSuccess && !string.IsNullOrWhiteSpace(restResponse.Content))
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                restResponse.Data = JsonSerializer.Deserialize<TResponse>(restResponse.Content, options);
            }

            return restResponse;
        }

        private async Task<RestResponse> HandleResponse(HttpResponseMessage response)
        {
            var restResponse = new RestResponse
            {
                IsSuccess = response.IsSuccessStatusCode,
                StatusCode = response.StatusCode,
                Content = await response.Content.ReadAsStringAsync()
            };

            return restResponse;
        }

        private RestResponse<TResponse> CreateErrorResponse<TResponse>(string errorMessage, Exception ex, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
        {
            return new RestResponse<TResponse>
            {
                IsSuccess = false,
                StatusCode = httpStatusCode,
                Content = errorMessage
            };
        }

        private RestResponse CreateErrorResponse(string errorMessage, Exception ex, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
        {
            return new RestResponse
            {
                IsSuccess = false,
                StatusCode = httpStatusCode,
                Content = errorMessage
            };
        }

        private void LogRequestResponse(RestRequest request, RestResponse response, string requestData)
        {
            TimeSpan duration = DateTime.Now - request.StartTime;
            double durationInMilliseconds = duration.TotalMilliseconds;
            if (request.RequestAndResponseLoggingEnabled)
            {
                _logger.LogInformation($"REST API CALL - Tracking ID: {request.TrackingId}, URL: {request.Url}, HttpStatusCode: {response.StatusCode}, Duration: {durationInMilliseconds}, Request: {requestData}, Response: {response.Content}");
            }
            else
            {
                _logger.LogInformation($"REST API CALL - Tracking ID: {request.TrackingId}, URL: {request.Url}, HttpStatusCode: {response.StatusCode}, Duration: {durationInMilliseconds}");

            }
        }

        #endregion
    }
}
