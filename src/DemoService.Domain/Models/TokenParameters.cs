namespace DemoService.Domain.Models
{
    public class TokenParameters
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Subject { get; set; }

        public string Scope { get; set; }
    }
}
