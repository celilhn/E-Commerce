using Application.Interfaces;
using Application.Models;
using Application.Utilities;
using Application.Logging;
using Application.Mapping;
using Application.Services;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Infrastructure.Repositories;

namespace Infrastructure.Ioc
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration _configuration)
        {
            Configuration configuration = _configuration.Get<Configuration>();
            services.AddSingleton(configuration);
            services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(
                configuration.DBConnectionText,
                b => b.MigrationsAssembly(typeof(ECommerceDbContext).Assembly.FullName)));

            /* Services & Repositories */
            services.AddScoped<IHttpUtilities, HttpUtilities>();
            services.AddScoped<ILoggerManager, LoggerManager>();
            services.AddScoped<IApiLogger, ApiLogger>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFaqService, FaqService>();
            services.AddScoped<IFaqRepository, FaqRepository>();


            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
