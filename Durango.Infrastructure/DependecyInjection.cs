using Durango.Application.Common.Interfaces.Authentication;
using Durango.Application.Common.Interfaces.Sevices;
using Durango.Infrastructure.Authentication;
using Durango.Infrastructure.Authetication;
using Durango.Infrastructure.Sevices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Durango.Infrastructure.Persistence;
using Durango.Application.Common.Interfaces.Persistence;

namespace Durango.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}