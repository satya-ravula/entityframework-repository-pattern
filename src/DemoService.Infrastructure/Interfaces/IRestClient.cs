using DemoService.Infrastructure.Models;

namespace DemoService.Infrastructure.Interfaces
{
    /// <summary>
    /// Represents a REST client interface for sending HTTP requests and receiving responses.
    /// </summary>
    public interface IRestClient
    {
        /// <summary>
        /// Sends an HTTP GET request and returns the response.
        /// </summary>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response.</returns>
        Task<RestResponse> Get(RestRequest request);

        /// <summary>
        /// Sends an HTTP GET request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response with deserialized content.</returns>
        Task<RestResponse<TResponse>> Get<TResponse>(RestRequest request);

        /// <summary>
        /// Sends an HTTP POST request and returns the response.
        /// </summary>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response.</returns>
        Task<RestResponse> Post(RestRequest request);

        /// <summary>
        /// Sends an HTTP POST request and returns the response.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data.</typeparam>
        /// <param name="request">The REST request configuration with request data.</param>
        /// <returns>The REST response.</returns>
        Task<RestResponse> Post<TRequest>(RestRequest<TRequest> request);

        /// <summary>
        /// Sends an HTTP POST request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data.</typeparam>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration with request data.</param>
        /// <returns>The REST response with deserialized content.</returns>
        Task<RestResponse<TResponse>> Post<TRequest, TResponse>(RestRequest<TRequest> request);

        /// <summary>
        /// Sends an HTTP POST request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response with deserialized content.</returns>
        Task<RestResponse<TResponse>> Post<TResponse>(RestRequest request);

        /// <summary>
        /// Sends an HTTP PUT request and returns the response.
        /// </summary>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response.</returns>
        Task<RestResponse> Put(RestRequest request);

        /// <summary>
        /// Sends an HTTP PUT request and returns the response.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data.</typeparam>
        /// <param name="request">The REST request configuration with request data.</param>
        /// <returns>The REST response.</returns>
        Task<RestResponse> Put<TRequest>(RestRequest<TRequest> request);

        /// <summary>
        /// Sends an HTTP PUT request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data.</typeparam>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration with request data.</param>
        /// <returns>The REST response with deserialized content.</returns>
        Task<RestResponse<TResponse>> Put<TRequest, TResponse>(RestRequest<TRequest> request);

        /// <summary>
        /// Sends an HTTP PUT request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response with deserialized content.</returns>
        Task<RestResponse<TResponse>> Put<TResponse>(RestRequest request);

        /// <summary>
        /// Sends an HTTP PATCH request and returns the response.
        /// </summary>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response.</returns>
        Task<RestResponse> Patch(RestRequest request);

        /// <summary>
        /// Sends an HTTP PATCH request and returns the response.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data.</typeparam>
        /// <param name="request">The REST request configuration with request data.</param>
        /// <returns>The REST response.</returns>
        Task<RestResponse> Patch<TRequest>(RestRequest<TRequest> request);

        /// <summary>
        /// Sends an HTTP PATCH request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data.</typeparam>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration with request data.</param>
        /// <returns>The REST response with deserialized content.</returns>
        Task<RestResponse<TResponse>> Patch<TRequest, TResponse>(RestRequest<TRequest> request);

        /// <summary>
        /// Sends an HTTP PATCH request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response with deserialized content.</returns>
        Task<RestResponse<TResponse>> Patch<TResponse>(RestRequest request);

        /// <summary>
        /// Sends an HTTP DELETE request and returns the response.
        /// </summary>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response.</returns>
        Task<RestResponse> Delete(RestRequest request);

        /// <summary>
        /// Sends an HTTP DELETE request and returns the response.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data.</typeparam>
        /// <param name="request">The REST request configuration with request data.</param>
        /// <returns>The REST response.</returns>
        Task<RestResponse> Delete<TRequest>(RestRequest<TRequest> request);

        /// <summary>
        /// Sends an HTTP DELETE request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request data.</typeparam>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration with request data.</param>
        /// <returns>The REST response with deserialized content.</returns>
        Task<RestResponse<TResponse>> Delete<TRequest, TResponse>(RestRequest<TRequest> request);

        /// <summary>
        /// Sends an HTTP DELETE request and returns the response with deserialized content.
        /// </summary>
        /// <typeparam name="TResponse">The type to deserialize the response content to.</typeparam>
        /// <param name="request">The REST request configuration.</param>
        /// <returns>The REST response with deserialized content.</returns>
        Task<RestResponse<TResponse>> Delete<TResponse>(RestRequest request);
    }
}
