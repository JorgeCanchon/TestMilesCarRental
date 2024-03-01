using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Infrastructure.Persistence.Contexts;
using MilesCarRental.Infrastructure.Persistence.Repository;
using MilesCarRental.Infrastructure.Services;

namespace MilesCarRental.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static void AddInfraestructureDependency(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddTransient<IDateTimeService, DateTimeService>();

            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString)
                ));

            #region Repositories
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            #endregion
        }
    }
}
