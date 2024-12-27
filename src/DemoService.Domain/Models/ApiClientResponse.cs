using DemoService.Domain.Interfaces;
using System.Net;

namespace DemoService.Domain.Models
{
    /// <summary>
    /// Represents a service agent response with specific data of type <typeparamref name="TResponse"/>.
    /// </summary>
    /// <typeparam name="TResponse">The type of data associated with the response.</typeparam>
    public class ApiClientResponse<TResponse> : ServiceResponse<TResponse>, IApiClientResponse<TResponse>
    {
        /// <summary>
        /// Gets or sets the status code of the HTTP response.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Gets or Sets Rest API Response Content - JSON/TEXT Content. It will be populated only when IsSuccess is false
        /// </summary>
        public string ErrorContent { get; set; }
    }

    /// <summary>
    /// Represents a service agent response without specific data.
    /// </summary>
    public class ServiceAgentResponse : ServiceResponse, IApiClientResponse
    {
        /// <summary>
        /// Gets or sets the status code of the HTTP response.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Gets or Sets Rest API Response Content - JSON/TEXT Content. It will be populated only when IsSuccess is false
        /// </summary>
        public string ErrorContent { get; set; }
    }
}
