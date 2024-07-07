
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Realtor.Application.Authentication.Commands.Register;
using Realtor.Application.Authentication.Common;
using Realtor.Application.Common.Behaviors;
using Realtor.Application.Common.Mapping;
using System.Reflection;

namespace Realtor.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddApplicationMappings();
            return services;
        }
    }
}