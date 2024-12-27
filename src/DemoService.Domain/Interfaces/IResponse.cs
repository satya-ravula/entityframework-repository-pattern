using DemoService.Domain.Enums;
using DemoService.Domain.Models;

namespace DemoService.Domain.Interfaces
{
    /// <summary>
    /// Represents a generic response with status and messages.
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        /// Gets or sets the status of the response.
        /// </summary>
        Status Status { get; set; }

        /// <summary>
        /// Gets or sets the list of messages associated with the response.
        /// </summary>
        List<Message> Messages { get; set; }
    }

    /// <summary>
    /// Represents a generic response with status, messages, and specific data.
    /// </summary>
    /// <typeparam name="TResponse">The type of data associated with the response.</typeparam>
    public interface IResponse<TResponse> : IResponse
    {
        /// <summary>
        /// Gets or sets the data associated with the response.
        /// </summary>
        TResponse Data { get; set; }
    }
}
