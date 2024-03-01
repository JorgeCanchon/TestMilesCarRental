using MilesCarRental.Application.Common.Interfaces;

namespace MilesCarRental.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
