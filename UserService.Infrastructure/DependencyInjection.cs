using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Contracts.Repository;
using UserService.Infrastructure.DBContext;
using UserService.Infrastructure.Repositories;

namespace UserService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Infrastructure service registrations go here
            services.AddSingleton<IUsersRepository, UserRepository>();
            services.AddTransient<DapperDbContext>();
            return services;
        }
    }
}
