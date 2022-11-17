using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendr.Auth.Responses
{
    public class LoginResponse
    {
         public string Email { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}