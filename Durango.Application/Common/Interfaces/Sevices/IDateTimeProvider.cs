namespace Durango.Application.Common.Interfaces.Sevices;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}