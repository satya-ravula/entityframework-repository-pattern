using System.Net;

namespace DemoService.Infrastructure.Models
{
    /// <summary>
    /// RestResponse
    /// </summary>
    public class RestResponse
    {
        /// <summary>
        /// Gets or Sets Http StatusCode
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or Sets IsSuccess - it will be true only if Http StatusCode between 200 and 299
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or Sets Rest API Response Content - JSON/TEXT Content
        /// </summary>
        public string? Content { get; set; }
    }

    /// <summary>
    /// RestResponse
    /// </summary>
    /// <typeparam name="TData">Response Data</typeparam>
    public class RestResponse<TData> : RestResponse
    {
        /// <summary>
        /// Gets or Sets Rest API Response Body
        /// </summary>
        public TData? Data { get; set; }
    }
}
