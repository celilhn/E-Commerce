using System;
using Application.Interfaces;
using Application.Models;
using Application.Utilities;
using Application.Logging;
using Application.Mapping;
using Application.Services;
using Application.ValidationRules.FluentValidation.Brand;
using Application.ValidationRules.FluentValidation.Faq;
using Application.ValidationRules.FluentValidation.Size;
using Application.ValidationRules.FluentValidation.User;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
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
                GetDbConnectionText(configuration),
                b => b.MigrationsAssembly(typeof(ECommerceDbContext).Assembly.FullName)));

            /* Services & Repositories */
            services.AddScoped<IHttpUtilities, HttpUtilities>();
            services.AddScoped<ILoggerManager, LoggerManager>();
            services.AddScoped<IApiLogger, ApiLogger>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFaqService, FaqService>();
            services.AddScoped<IFaqRepository, FaqRepository>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserLoginLogService, UserLoginLogService>();
            services.AddScoped<IUserLoginLogRepository, UserLoginLogRepository>();

            services.AddScoped<IValidator<Faq>, FaqValidator>();
            services.AddScoped<IValidator<Brand>, BrandValidator>();
            services.AddScoped<IValidator<Size>, SizeValidator>();
            services.AddScoped<IValidator<UserAddDto>, UserAddValidator>();
            services.AddScoped<IValidator<UserUpdateDto>, UserUpdateValidator>();
            services.AddScoped<IValidator<UserLoginDto>, UserLoginValidator>();
            services.AddScoped<IValidator<UserRegisterDto>, UserRegisterValidator>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static string GetDbConnectionText(Configuration configuration)
        {
            string connectionString = configuration.DBConnectionText;
            connectionString = string.Format(connectionString, Environment.GetEnvironmentVariable("ECommerceDbUser"), Environment.GetEnvironmentVariable("ECommerceDbPassword"));
            return connectionString;
        }
    }
}
