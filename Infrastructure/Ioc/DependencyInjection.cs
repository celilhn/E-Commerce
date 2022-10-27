using System;
using Application.Interfaces;
using Application.Models;
using Application.Utilities;
using Application.Logging;
using Application.Mapping;
using Application.Services;
using Application.ValidationRules.FluentValidation.AdminUser;
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
            services.AddScoped<ILoginLogService, LoginLogService>();
            services.AddScoped<ILoginLogRepository, LoginLogRepository>();
            services.AddScoped<IAdminUserService, AdminUserService>();
            services.AddScoped<IAdminUserRepository, AdminUserRepository>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITagRepository, TagRepository>();

            services.AddScoped<IValidator<Faq>, FaqValidator>();
            services.AddScoped<IValidator<Brand>, BrandValidator>();
            services.AddScoped<IValidator<Size>, SizeValidator>();
            services.AddScoped<IValidator<UserAddDto>, UserAddValidator>();
            services.AddScoped<IValidator<UserUpdateDto>, UserUpdateValidator>();
            services.AddScoped<IValidator<UserLoginDto>, UserLoginValidator>();
            services.AddScoped<IValidator<UserRegisterDto>, UserRegisterValidator>();
            services.AddScoped<IValidator<AdminUserAddDto>, AdminUserAddValidator>();
            services.AddScoped<IValidator<AdminUserUpdateDto>, AdminUserUpdateValidator>();

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
