using Application.Interfaces;
using Application.Models;
using Application.Utilities;
using Application.Logging;
using Application.Mapping;
using AutoMapper;
using Infrastructure.Context;
using Infrastructure.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Infrastructure.Ioc
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration _configuration)
        {
            Configuration configuration = _configuration.Get<Configuration>();
            services.AddSingleton(configuration);
            services.AddDbContext<MTriggerDbContext>(options => options.UseSqlServer(
                configuration.DBConnectionText,
                b => b.MigrationsAssembly(typeof(MTriggerDbContext).Assembly.FullName)));

            /* Services & Repositories */
            services.AddScoped<IHttpUtilities, HttpUtilities>();
            services.AddScoped<ILoggerManager, LoggerManager>();
            services.AddScoped<IApiLogger, ApiLogger>();
            services.AddScoped<IEmailService, EmailService>();


            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
