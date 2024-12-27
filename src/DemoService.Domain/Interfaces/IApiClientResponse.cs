using System.Net;

namespace DemoService.Domain.Interfaces
{
    /// <summary>
    /// Represents a service agent response with a specific response type.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public interface IApiClientResponse<TResponse> : IResponse<TResponse>
    {
        /// <summary>
        /// Gets or sets the status code of the HTTP response.
        /// </summary>
        HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Gets or Sets Rest API Response Content - JSON/TEXT Content. It will be populated only when IsSuccess is false
        /// </summary>
        string ErrorContent { get; set; }
    }

    /// <summary>
    /// Represents a service agent response.
    /// </summary>
    public interface IApiClientResponse : IResponse
    {
        /// <summary>
        /// Gets or sets the status code of the HTTP response.
        /// </summary>
        HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Gets or Sets Rest API Response Content - JSON/TEXT Content. It will be populated only when IsSuccess is false
        /// </summary>
        string ErrorContent { get; set; }
    }
}
