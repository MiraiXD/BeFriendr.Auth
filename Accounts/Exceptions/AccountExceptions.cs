using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendr.Auth.Accounts.Exceptions
{
    public class AccountExceptions
    {
        public class Register
        {
            public class UserAlreadyExistsException : Exception
            {
                public string UserName { get; }
                public UserAlreadyExistsException(string userName)
                {
                    UserName = userName;
                }
            }
        }
        public class Unregister
        {
            public class UserDoesNotExistException : Exception
            {
                public string UserName { get; set; }
                public UserDoesNotExistException(string userName)
                {
                    UserName = userName;
                }
            }
        }
        public class Login
        {
            public class UserDoesNotExistException : Exception
            {
                public string UserName { get; }
                public UserDoesNotExistException(string userName)
                {
                    UserName = userName;
                }
            }
            public class IncorrectPasswordException : Exception
            {
                public string Password { get; }
                public IncorrectPasswordException(string password)
                {

                }
            }
        }
    }
}