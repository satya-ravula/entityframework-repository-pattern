using DemoService.Infrastructure.Models;

namespace DemoService.Infrastructure.Extensions
{
    /// <summary>
    /// Extensions that extends RestRequest
    /// </summary>
    public static class RestRequestExtensions
    {
        /// <summary>
        /// Performs validation on RestRequest
        /// </summary>
        /// <param name="restRequest">Rest Request</param>
        /// <returns>Validation result</returns>
        /// <exception cref="ArgumentNullException">Exception when request is null or url is not defined</exception>
        /// <exception cref="ArgumentException">Exception when timeout in milliseconds is not valid</exception>
        public static bool IsValid(this RestRequest restRequest)
        {
            if (restRequest == null)
            {
                throw new ArgumentNullException(nameof(restRequest));
            }

            if (string.IsNullOrWhiteSpace(restRequest.Url))
            {
                throw new ArgumentNullException(nameof(restRequest.Url));
            }

            if (restRequest.TimeoutInMilliseconds <= 0)
            {
                throw new ArgumentException("TimeoutInMilliseconds should be greater than 0");
            }

            return true;
        }
    }
}
