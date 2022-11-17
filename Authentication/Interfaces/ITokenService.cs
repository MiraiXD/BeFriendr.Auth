using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BeFriendr.Auth.Authentication.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(List<Claim> claims);
    }
}