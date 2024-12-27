using DemoService.Application.Interfaces;
using DemoService.Domain.Models;

namespace DemoService.Application.Models
{
    public class YassiApiClientRequest<TRequest> : ServiceRequest<TRequest>, IYassiApiClientRequest<TRequest>
    {
        public TokenParameters TokenParameters { get; set; }
    }
}
