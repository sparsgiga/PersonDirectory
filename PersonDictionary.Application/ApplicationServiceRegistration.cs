using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PersonDirectory.Application.Common.Behaviours;
using PersonDirectory.Application.Common.Mapster;
using System.Reflection;


namespace PersonDirectory.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestTransactionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.RegisterMapsterApplicationConfiguration();

            return services;

        }
    }
}
