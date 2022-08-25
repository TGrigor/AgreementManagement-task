using AgreementManagement.Services;
using AgreementManagement.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace AgreementManagement.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IAgreementService, AgreementService>();
            return services;
        }

    }
}
