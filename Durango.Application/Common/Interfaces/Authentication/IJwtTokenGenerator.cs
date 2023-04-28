using Durango.Domain.Entities;

namespace Durango.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User User);
}