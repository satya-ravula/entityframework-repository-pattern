using DemoService.Application.Interfaces;
using DemoService.Domain.Interfaces;
using DemoService.Infrastructure.ApiClients;
using DemoService.Infrastructure.Interfaces;
using DemoService.Infrastructure.Models;
using DemoService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InquiryDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("default"));
            });

            var apiSettingsSection = configuration.GetSection("YassiApiSettings");
            var apiSettings = new YassiApiSettings();
            apiSettingsSection.Bind(apiSettings);
            services.AddSingleton<YassiApiSettings>(apiSettings);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddHttpClient<IRestClient, RestClient>();
            services.AddSingleton<IYassiApiClient, YassiApiClient>();
            services.AddSingleton<IYassiTokenProvider, YassiTokenProvider>();
        }
    }
}
