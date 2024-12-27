using System.Text.RegularExpressions;

namespace DemoService.Infrastructure.Extensions
{
    /// <summary>
    /// Extension method to mask sensitive field values in a JSON string.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Masks sensitive field values in a JSON string based on the provided list of field names.
        /// </summary>
        /// <param name="content">The JSON string to be processed.</param>
        /// <param name="maskedFields">A list of field names to be masked.</param>
        /// <returns>A JSON string with sensitive field values masked.</returns>
        /// <remarks>
        /// This method uses regular expressions to locate and replace the values of fields specified
        /// in the <paramref name="maskedFields"/> list with a masking value "***MASKED***".
        /// </remarks>
        public static string ToMaskedContent(this string content, List<string> maskedFields)
        {
            if (maskedFields == null || !maskedFields.Any() || string.IsNullOrWhiteSpace(content))
                return content;

            // Use regular expressions to replace sensitive field values with masked values
            foreach (var field in maskedFields)
            {
                var pattern = $"(?i)\"{field}\":\\s*(\"[^\"]*\"|[^,]*)";
                var maskedValue = $"\"{field}\": \"***MASKED***\"";

                content = Regex.Replace(content, pattern, maskedValue);
            }

            return content;
        }
    }
}
