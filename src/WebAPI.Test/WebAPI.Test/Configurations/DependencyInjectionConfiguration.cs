using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;
using WebAPI.Test.Service;

namespace WebAPI.Test.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddHttpClient<SpotfyService, SpotfyService>(config =>
            {
                config.BaseAddress = new Uri(configuration.GetSection("SpotfyServer")["BaseUrl"]);
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            return services;
        }
    }
}
