using System.Text.Json.Serialization;

namespace DemoService.Infrastructure.Models
{
    /// <summary>
    /// Oauth Token response
    /// </summary>
    public class TokenResponse
    {
        /// <summary>
        /// Gets or sets the oauth AccessToken.
        /// </summary>
        [JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the oauth Token type.
        /// </summary>
        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }

        /// <summary>
        /// Gets or sets the oauth Token expiration seconds.
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the oauth Token expiration time.
        /// </summary>
        public DateTime ExpiryUtc { get; set; }

        /// <summary>
        /// Gets if Oauth token is expired or not
        /// </summary>
        /// <returns>True or False.</returns>
        public bool IsExpired() => ExpiryUtc != DateTime.MinValue && DateTime.UtcNow >= this.ExpiryUtc;
    }
}
