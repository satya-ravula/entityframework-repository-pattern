using DemoService.Domain.Models;

namespace DemoService.Infrastructure.Interfaces
{
    /// <summary>
    ///  Represents a token provider interface for generating token
    /// </summary>
    public interface IYassiTokenProvider
    {
        Task<string> GetToken(TokenParameters parameters);
    }
}
