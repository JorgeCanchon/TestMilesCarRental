using Microsoft.AspNetCore.Mvc;

namespace MilesCarRental.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddApiVersionExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}
