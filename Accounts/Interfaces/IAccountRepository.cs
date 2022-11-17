using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFriendr.Common;
using BeFriendr.Auth.Accounts.Entities;

namespace BeFriendr.Auth.Accounts.Interfaces
{
    public interface IAccountRepository : ICrudRepository<Account>
    {
        Task<Account> GetByUserName(string userName);
    }
}