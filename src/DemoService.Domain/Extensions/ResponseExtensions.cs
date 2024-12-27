using DemoService.Domain.Enums;
using DemoService.Domain.Interfaces;
using DemoService.Domain.Models;

namespace DemoService.Domain.Extensions
{
    /// <summary>
    /// Extension methods for IResponse
    /// </summary>
    public static class ResponseExtensions
    {
        /// <summary>
        /// Add a Message to IResponse
        /// </summary>
        /// <param name="response">IResponse</param>
        /// <param name="code">Message/Error Code</param>
        /// <param name="description">Message/Error Description</param>
        public static void AddMessage(this IResponse response, string code, string description)
        {
            response.AddMessage(code, description, MessageType.Info);
        }

        /// <summary>
        /// Add a Message to IResponse
        /// </summary>
        /// <param name="response">IResponse</param>
        /// <param name="code">Message/Error Code</param>
        /// <param name="description">Message/Error Description</param>
        /// <param name="messageType">MessageType</param>
        public static void AddMessage(this IResponse response, string code, string description, MessageType messageType)
        {
            if (response == null)
            {
                return;
            }

            if (response.Messages == null)
            {
                response.Messages = new List<Message>();
            }

            response.Messages.Add(new Message { Code = code, Description = description, MessageType = messageType });
        }

        /// <summary>
        /// Adds a collection of messages to the response.
        /// </summary>
        /// <param name="response">The response to which messages will be added.</param>
        /// <param name="messages">The collection of messages to add to the response.</param>
        public static void AddMessages(this IResponse response, IEnumerable<Message> messages)
        {
            // Check if the response and messages are not null and if the messages collection is not empty
            if (response != null && messages != null && messages.Any())
            {
                // Add all messages from the collection to the response's messages list
                response.Messages.AddRange(messages);
            }
        }

        /// <summary>
        /// Get Generic Exception
        /// </summary>
        /// <typeparam name="T">Response model.</typeparam>
        /// <param name="response">IResponse</param>
        /// <param name="ex">Exception</param>
        /// <param name="code">Message/Error Code</param>
        /// <param name="description">Message/Error Description</param>
        /// <returns>IResponse</returns>
        public static void ToGenericException<T>(this IResponse<T> response, Exception ex, string code = null, string description = null)
        {
            if (response == null)
            {
                response = new ServiceResponse<T>();
            }

            response.SetupExceptionResponse(ex, code, description);
        }

        /// <summary>
        /// Get Generic Exception
        /// </summary>
        /// <typeparam name="T">Response model.</typeparam>
        /// <param name="response">IResponse</param>
        /// <param name="ex">Exception</param>
        /// <param name="code">Message/Error Code</param>
        /// <param name="description">Message/Error Description</param>
        /// <returns>IResponse</returns>
        public static void ToGenericException(this IResponse response, Exception ex, string code = null, string description = null)
        {
            if (response == null)
            {
                response = new ServiceResponse();
            }

            response.SetupExceptionResponse(ex, code, description);
        }

        /// <summary>
        /// Set up Exception Response
        /// </summary>
        /// <param name="response">IResponse</param>
        /// <param name="ex">Exception</param>
        /// <param name="code">Message/Error Code</param>
        /// <param name="description">Message/Error Description</param>
        /// <returns>IResponse</returns>
        private static void SetupExceptionResponse(this IResponse response, Exception ex, string code, string description)
        {
            response.Status = Status.Failed;
            response.AddMessage(code, string.IsNullOrWhiteSpace(description) ? ex.Message : description, MessageType.Error);
        }
    }
}
