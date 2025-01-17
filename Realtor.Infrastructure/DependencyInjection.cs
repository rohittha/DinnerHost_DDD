
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Realtor.Application.Common.Interfaces.Authentication;
using Realtor.Infrastructure.Authentication;
using Realtor.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Realtor.Application.Common.Interfaces.Persistence;
using Realtor.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Realtor.Infrastructure.Data;
using Realtor.Application.Services;

namespace Realtor.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            ConfigurationManager configuration
            )
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("Server=DESKTOP-KSAT5NM\\RTSQL;Database=RealtorsDb1;Trusted_Connection=True;Encrypt=true;TrustServerCertificate=true;"));
            //services.AddDbContext<AppDbContext>(options =>
            //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            services.AddAuth(configuration);
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPropertyUnitRepository, PropertyUnitRepository>();
            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);
            services.AddSingleton(Options.Create(jwtSettings));

            //services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });
            return services;
        }
    }
}