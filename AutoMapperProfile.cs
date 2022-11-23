using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeFriendr.Accounts.Requests;
using BeFriendr.Auth.Accounts.Entities;
using BeFriendr.Common.Messages;

namespace BeFriendr.Auth.Accounts.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterRequest, Account>();
            CreateMap<Account, AccountCreatedMessage>();
        }
    }
}