using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonDirectory.Application.Common.Options;
using PersonDirectory.Application.Services;
using PersonDirectory.Infrastructure.Services;
namespace PersonDirectory.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FileManagerOptions>(configuration.GetSection("FileManagerOptions"));
            services.AddScoped<IFileManagerService, FileManagerService>();

            return services;
        }
    }


}
