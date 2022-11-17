using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeFriendr.Auth.Authentication.Helpers;
using BeFriendr.Auth.Authentication.Interfaces;
using BeFriendr.Auth.Authentication.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BeFriendr.Auth.Authentication.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<AuthenticationSettings>(configuration.GetSection("AuthenticationSettings"));
            services.AddScoped<ITokenService, JwtTokenService>();

            var authenticationSettings = new AuthenticationSettings();
            configuration.Bind("AuthenticationSettings", authenticationSettings);
            services.AddSingleton<AuthenticationSettings>(authenticationSettings);            
            return services;
        }
    }
}