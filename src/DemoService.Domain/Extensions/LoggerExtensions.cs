using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace DemoService.Domain.Extensions
{
    /// <summary>
    /// Provides extension methods for logging with additional context.
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        /// Logs an informational message with the specified tracking ID, message, and optional data.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="trackingId">The tracking ID associated with the log message.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="data">Optional data to include in the log message.</param>
        public static void LogInfo(this ILogger logger, Guid trackingId, string message, object data = null)
        {
            if (data != null)
            {
                var jsonData = JsonSerializer.Serialize(data);
                logger.LogInformation("Info - Tracking ID: {TrackingId}, Message: {Message}, Data: {Data}", trackingId, message, jsonData);
            }
            else
            {
                logger.LogInformation("Info - Tracking ID: {TrackingId}, Message: {Message}", trackingId, message);
            }
        }

        /// <summary>
        /// Logs a debug message with the specified tracking ID, message, and optional data.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="trackingId">The tracking ID associated with the log message.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="data">Optional data to include in the log message.</param>
        public static void LogDebug(this ILogger logger, Guid trackingId, string message, object data = null)
        {
            if (data != null)
            {
                var jsonData = JsonSerializer.Serialize(data);
                logger.LogDebug("Debug - Tracking ID: {TrackingId}, Message: {Message}, Data: {Data}", trackingId, message, jsonData);
            }
            else
            {
                logger.LogDebug("Debug - Tracking ID: {TrackingId}, Message: {Message}", trackingId, message);
            }
        }

        /// <summary>
        /// Logs a trace message with the specified tracking ID, message, and optional data.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="trackingId">The tracking ID associated with the log message.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="data">Optional data to include in the log message.</param>
        public static void LogTrace(this ILogger logger, Guid trackingId, string message, object data = null)
        {
            if (data != null)
            {
                var jsonData = JsonSerializer.Serialize(data);
                logger.LogTrace("Trace - Tracking ID: {TrackingId}, Message: {Message}, Data: {Data}", trackingId, message, jsonData);
            }
            else
            {
                logger.LogTrace("Trace - Tracking ID: {TrackingId}, Message: {Message}", trackingId, message);
            }
        }

        /// <summary>
        /// Logs a warning message with the specified tracking ID, message, and optional data.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="trackingId">The tracking ID associated with the log message.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="data">Optional data to include in the log message.</param>
        public static void LogWarning(this ILogger logger, Guid trackingId, string message, object data = null)
        {
            if (data != null)
            {
                var jsonData = JsonSerializer.Serialize(data);
                logger.LogWarning("Warning - Tracking ID: {TrackingId}, Message: {Message}, Data: {Data}", trackingId, message, jsonData);
            }
            else
            {
                logger.LogWarning("Warning - Tracking ID: {TrackingId}, Message: {Message}", trackingId, message);
            }
        }

        /// <summary>
        /// Logs an error message with the specified tracking ID, message, exception, and optional data.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="trackingId">The tracking ID associated with the log message.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="ex">The exception to log.</param>
        /// <param name="data">Optional data to include in the log message.</param>
        public static void LogError(this ILogger logger, Guid trackingId, string message, Exception ex, object data = null)
        {
            if (data != null)
            {
                var jsonData = JsonSerializer.Serialize(data);
                logger.LogError(ex, "Error - Tracking ID: {TrackingId}, Message: {Message}, Data: {Data}", trackingId, ex.Message, jsonData);
            }
            else
            {
                logger.LogError(ex, "Error - Tracking ID: {TrackingId}, Message: {Message}", trackingId, ex.Message);
            }
        }

        /// <summary>
        /// Logs an error message with the specified tracking ID, exception, and optional data.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="trackingId">The tracking ID associated with the log message.</param>
        /// <param name="ex">The exception to log.</param>
        /// <param name="data">Optional data to include in the log message.</param>
        public static void LogError(this ILogger logger, Guid trackingId, Exception ex, object data = null)
        {
            logger.LogError(trackingId, ex?.Message, ex, data);
        }
    }
}
