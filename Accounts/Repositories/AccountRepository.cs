using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFriendr.Common;
using BeFriendr.Auth.Accounts.Entities;
using BeFriendr.Auth.Accounts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BeFriendr.Auth.Accounts.Repositories
{
    public class AccountRepository : CrudRepository<Account>, IAccountRepository
    {
        //public AccountRepository(AuthenticationDbContext context) : base(context)
        public AccountRepository(DbContext context) : base(context)
        {
        }

        public async Task<Account> GetByUserName(string userName)
        {
            return await Entities.FirstOrDefaultAsync(account => account.UserName == userName);
        }
    }
}