using DemoService.Infrastructure.Constants;

namespace DemoService.Infrastructure.Models
{
    /// <summary>
    /// Rest Request
    /// </summary>
    public class RestRequest
    {
        /// <summary>
        /// Gets or Sets Rest API Endpoint
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// Gets or Sets Http Headers
        /// </summary>
        public Dictionary<string, string>? Headers { get; set; }

        /// <summary>
        /// Gets or Sets Content Type. Default - application/json
        /// </summary>
        public string? ContentType { get; set; } = ContentTypes.Json;

        /// <summary>
        /// Gets or Sets Timeout in Milliseconds. Default is 20 sec (20000 milliseconds)
        /// </summary>
        public int TimeoutInMilliseconds { get; set; } = 20000;

        /// <summary>
        /// Gets or Sets Masked Fields. These fields will be masked in logging. Optional.
        /// </summary>
        public List<string>? MaskedFields { get; set; }

        /// <summary>
        /// Gets or Sets RequestAndResponseLoggingEnabled. By default true logging is enabled.
        /// </summary>
        public bool RequestAndResponseLoggingEnabled { get; set; } = true;

        /// <summary>
        /// Start time before make a rest call
        /// </summary>
        public DateTime StartTime { get; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or Sets Tracking Id
        /// </summary>
        public Guid TrackingId { get; set; }
    }

    /// <summary>
    /// Rest Request
    /// </summary>
    /// <typeparam name="TData">Request Data</typeparam>
    public class RestRequest<TData> : RestRequest
    {
        /// <summary>
        /// Gets or Sets Rest API Request Body
        /// </summary>
        public TData? Data { get; set; }
    }
}
