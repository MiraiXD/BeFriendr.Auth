using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFriendr.Auth.Accounts.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeFriendr.Auth
{
    public class AuthDbContext : DbContext
    {
        public DbSet<Account> Users { get; set; }        
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
            
        }
    }
}