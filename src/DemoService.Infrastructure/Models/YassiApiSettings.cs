namespace DemoService.Infrastructure.Models
{
    public class YassiApiSettings
    {
        public string Url { get; set; }

        public string TokenUrl { get; set; }

        public string AdminClientId { get; set; }

        public string AdminScope { get; set; }

        public string UserScope { get; set; }

        public int TimeoutInMilliseconds { get; set; } = 20000;

        public string GrantType { get; set; } = "client_credentials";
    }
}
