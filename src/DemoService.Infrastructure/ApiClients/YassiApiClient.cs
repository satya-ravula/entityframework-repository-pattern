using DemoService.Application;
using DemoService.Application.Interfaces;
using DemoService.Application.Models;
using DemoService.Domain.Enums;
using DemoService.Domain.Extensions;
using DemoService.Domain.Interfaces;
using DemoService.Domain.Models;
using DemoService.Infrastructure.Interfaces;
using DemoService.Infrastructure.Models;
using Microsoft.Extensions.Logging;

namespace DemoService.Infrastructure.ApiClients
{
    public class YassiApiClient : IYassiApiClient
    {
        private readonly ILogger<YassiApiClient> _logger;
        private readonly YassiTokenProvider _tokenProvider;
        private readonly YassiApiSettings _apiSettings;
        private readonly IRestClient _client;

        public YassiApiClient(ILogger<YassiApiClient> logger, 
            YassiTokenProvider tokenProvider, 
            YassiApiSettings apiSettings, 
            IRestClient client
        ) 
        {
            _logger = logger;
            _tokenProvider = tokenProvider;
            _apiSettings = apiSettings;
            _client = client;
        }

        public async Task<IApiClientResponse<InquiryTransactionResponse>> CreateInquiryTransaction(IYassiApiClientRequest<InquiryTransactionRequest> request)
        {
            try
            {
                var restRequest = new RestRequest<InquiryDispatchRequest>
                {
                    Url = $"{_apiSettings.Url}/inquiry/transactions",
                    TimeoutInMilliseconds = _apiSettings.TimeoutInMilliseconds,
                    Headers = new Dictionary<string, string>
                    {
                        {"Authorization", await _tokenProvider.GetToken(request.TokenParameters) }
                    },
                    Data = new InquiryDispatchRequest(),
                    TrackingId = request.TrackingId
                };

                var restResponse = await _client.Post<InquiryDispatchRequest, InquiryDispatchResponse>(restRequest);
                return new ApiClientResponse<InquiryTransactionResponse>
                {
                    Data = new InquiryTransactionResponse(),
                    Status = restResponse.IsSuccess ? Status.Success : Status.Failed,
                    HttpStatusCode = restResponse.StatusCode,
                    ErrorContent = !restResponse.IsSuccess ? restResponse.Content : null
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(request.TrackingId, "Exception occurred in YassiApiClient.CreateInquiryTransaction", ex);
                throw new YassiApiClientException("CreateInquiryTransaction", ex);
            }
        }
    }
}
