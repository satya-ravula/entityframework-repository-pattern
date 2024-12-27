using DemoService.Application.Models;
using DemoService.Domain.Interfaces;

namespace DemoService.Application.Interfaces
{
    public interface IYassiApiClient
    {
        Task<IApiClientResponse<InquiryTransactionResponse>> CreateInquiryTransaction(IYassiApiClientRequest<InquiryTransactionRequest> request);
    }
}
