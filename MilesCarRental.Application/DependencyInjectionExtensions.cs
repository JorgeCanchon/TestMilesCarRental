using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MilesCarRental.Application.Common.Behaviours;
using System.Reflection;

namespace MilesCarRental.Application
{
    public static class DependencyInjectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
