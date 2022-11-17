using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFriendr.Auth.Accounts.Interfaces;
using BeFriendr.Auth.Accounts.Repositories;
using BeFriendr.Auth.Accounts.Services;
using BeFriendr.Auth.Authentication;

namespace BeFriendr.Auth.Accounts.Extensions
{
    public static class AccountExtensions
    {
        public static IServiceCollection AddAccountServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
            return services;
        }
    }
}