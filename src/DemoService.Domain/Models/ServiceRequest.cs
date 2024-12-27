using DemoService.Domain.Interfaces;

namespace DemoService.Domain.Models
{
    /// <summary>
    /// Represents a service request with specific data of type <typeparamref name="TRequest"/>.
    /// </summary>
    /// <typeparam name="TRequest">The type of data associated with the request.</typeparam>
    public class ServiceRequest<TRequest> : IRequest<TRequest>
    {
        /// <summary>
        /// Gets or sets the unique tracking ID for the request.
        /// </summary>
        public Guid TrackingId { get; set; }

        /// <summary>
        /// Gets or sets additional properties associated with the request.
        /// </summary>
        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the data associated with the request.
        /// </summary>
        public TRequest Data { get; set; }
    }

    /// <summary>
    /// Represents a service request without specific data.
    /// </summary>
    public class ServiceRequest : IRequest
    {
        /// <summary>
        /// Gets or sets the unique tracking ID for the request.
        /// </summary>
        public Guid TrackingId { get; set; }

        /// <summary>
        /// Gets or sets additional properties associated with the request.
        /// </summary>
        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
    }
}
