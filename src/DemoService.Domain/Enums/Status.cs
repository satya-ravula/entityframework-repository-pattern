namespace DemoService.Domain.Enums
{
    /// <summary>
    /// Enumeration representing the status of an operation.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The operation was successful.
        /// </summary>
        Success = 1,

        /// <summary>
        /// The operation failed.
        /// </summary>
        Failed = 2
    }
}
