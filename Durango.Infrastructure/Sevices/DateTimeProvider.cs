using Durango.Application.Common.Interfaces.Sevices;

namespace Durango.Infrastructure.Sevices;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}