using AutoMapper;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Core.Mappers;
using UserService.Core.Services;
using UserService.Core.Validators;
using UserService.Domain.Contracts.Services;


namespace UserService.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IUserService, Services.UserService>();
            services.AddAutoMapper(cfg => cfg.AddProfile<ApplicationUserMappingProfile>());
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

            // Core service registrations go here
            return services;
        }
    }
}
