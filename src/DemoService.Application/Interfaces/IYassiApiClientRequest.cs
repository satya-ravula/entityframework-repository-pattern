using DemoService.Domain.Interfaces;
using DemoService.Domain.Models;

namespace DemoService.Application.Interfaces
{
    public interface IYassiApiClientRequest<TRequest> : IRequest<TRequest>
    {
        TokenParameters TokenParameters { get; set; }
    }
}
