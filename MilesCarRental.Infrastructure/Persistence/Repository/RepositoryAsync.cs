using Ardalis.Specification.EntityFrameworkCore;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Infrastructure.Persistence.Contexts;

namespace MilesCarRental.Infrastructure.Persistence.Repository
{
    public class RepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public RepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
