using Durango.Domain.Entities;

namespace Durango.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);
