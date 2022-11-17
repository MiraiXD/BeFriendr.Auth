using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFriendr.Auth.Accounts.Interfaces;
using BeFriendr.Common;

namespace BeFriendr.Auth
{
    public class UnitOfWork : BaseUnitOfWork<AuthDbContext>
    {
        public IAccountRepository AccountRepository { get; private set;}

        public UnitOfWork(AuthDbContext dbContext, IAccountRepository accountRepository) : base(dbContext)
        {
            AccountRepository = accountRepository;
        }
    }
}