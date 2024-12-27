namespace DemoService.Domain.Enums
{
    /// <summary>
    /// Enumeration representing the type of a message.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// Unknown message type.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Informational message.
        /// </summary>
        Info = 1,

        /// <summary>
        /// Error message.
        /// </summary>
        Error = 2
    }
}
