using DemoService.Domain.Enums;

namespace DemoService.Domain.Models
{
    /// <summary>
    /// Represents a message with a code, description, and type.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Gets or sets the code associated with the message.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Gets or sets the description of the message.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        public MessageType MessageType { get; set; }
    }
}
