namespace DemoService.Domain.Interfaces
{
    /// <summary>
    /// Represents a generic request with a tracking ID and additional properties.
    /// </summary>
    public interface IRequest
    {
        /// <summary>
        /// Gets or sets the unique tracking ID for the request.
        /// </summary>
        Guid TrackingId { get; set; }

        /// <summary>
        /// Gets or sets additional properties associated with the request.
        /// </summary>
        Dictionary<string, string> Properties { get; set; }
    }

    /// <summary>
    /// Represents a generic request with a tracking ID, additional properties, and specific data.
    /// </summary>
    /// <typeparam name="TRequest">The type of data associated with the request.</typeparam>
    public interface IRequest<TRequest> : IRequest
    {
        /// <summary>
        /// Gets or sets the data associated with the request.
        /// </summary>
        TRequest Data { get; set; }
    }
}
