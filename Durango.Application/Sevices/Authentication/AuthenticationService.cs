using Durango.Application.Common.Interfaces.Authentication;
using Durango.Application.Common.Interfaces.Persistence;
using Durango.Domain.Entities;

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

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validate the user does not already exist

        if (_userRepository.GetUserByEmail(email) != null)
        {
            throw new Exception("User with this email already exists.");
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

    public AuthenticationResult Login(string email, string password)
    {
        // 1. Validate the user exists

        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with this email does not exists.");
        }

        // 2. validate the passworld

        if (user.Password != password)
        {
            throw new Exception("Password is incorrect.");
        }

        // 3. create jwt token     

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
