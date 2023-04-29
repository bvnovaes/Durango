using Durango.Application.Common.Interfaces.Authentication;
using Durango.Application.Common.Interfaces.Persistence;
using Durango.Domain.Common.Errors;
using Durango.Domain.Entities;
using ErrorOr;

namespace Durango.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validate the user does not already exist
        if (_userRepository.GetUserByEmail(email) != null)
        {
            return Errors.User.DuplicateEmail;
        }

        // 2. create user
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // 3. create jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        // 1. Validate the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 2. validate the passworld
        if (user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 3. create jwt token    
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
