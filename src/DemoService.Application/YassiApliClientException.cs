namespace DemoService.Application
{
    /// <summary>
    /// Represents an exception thrown by a service agent.
    /// </summary>
    public class YassiApiClientException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YassiApiClientException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public YassiApiClientException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YassiApiClientException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
        /// if no inner exception is specified.</param>
        public YassiApiClientException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
