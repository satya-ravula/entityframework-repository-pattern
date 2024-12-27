using DemoService.Domain.Enums;
using DemoService.Domain.Interfaces;

namespace DemoService.Domain.Models
{
    /// <summary>
    /// Represents a service response with specific data of type <typeparamref name="TResponse"/>.
    /// </summary>
    /// <typeparam name="TResponse">The type of data associated with the response.</typeparam>
    public class ServiceResponse<TResponse> : IResponse<TResponse>
    {
        /// <summary>
        /// Gets or sets the status of the response.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets the list of messages associated with the response.
        /// </summary>
        public List<Message> Messages { get; set; } = new List<Message>();

        /// <summary>
        /// Gets or sets the data associated with the response.
        /// </summary>
        public TResponse Data { get; set; }
    }

    /// <summary>
    /// Represents a service response without specific data.
    /// </summary>
    public class ServiceResponse : IResponse
    {
        /// <summary>
        /// Gets or sets the status of the response.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets the list of messages associated with the response.
        /// </summary>
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
