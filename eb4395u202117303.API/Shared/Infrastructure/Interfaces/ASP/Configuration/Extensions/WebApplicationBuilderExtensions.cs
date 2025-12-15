using eb4395u202117303.API.Shared.Domain.Repositories;
using eb4395u202117303.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace eb4395u202117303.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

/// <summary>
///     Extension methods for configuring Shared context services in a WebApplicationBuilder.
/// </summary>
public static class WebApplicationBuilderExtensions
{
    /// <summary>
    ///     Adds the Shared context services to the WebApplicationBuilder.
    /// </summary>
    /// <param name="builder"></param>
    public static void AddSharedContextServices(this WebApplicationBuilder builder)
    {
        // Here you would typically add services related to the Shared context,
        // such as repositories, query services, command handlers, etc.
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}