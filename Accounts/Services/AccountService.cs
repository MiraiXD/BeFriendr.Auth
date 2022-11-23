using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using BeFriendr.Accounts.Requests;
using BeFriendr.Auth.Accounts.Entities;
using BeFriendr.Auth.Accounts.Exceptions;
using BeFriendr.Auth.Accounts.Interfaces;

namespace BeFriendr.Auth.Accounts.Services
{
    public class AccountService : IAccountService
    {
        public IAccountRepository AccountRepository { get; }
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _mapper = mapper;
            AccountRepository = accountRepository;
        }

        public async Task<Account> LoginAsync(LoginRequest request)
        {
            var account = await AccountRepository.GetByUserName(request.UserName);
            if (account == null) throw new AccountExceptions.Login.UserDoesNotExistException(request.UserName);

            using var hmac = new HMACSHA256(account.PasswordSalt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
            if (!hash.SequenceEqual(account.PasswordHash)) throw new AccountExceptions.Login.IncorrectPasswordException(request.Password);

            return account;
        }

        public async Task<Account> RegisterAsync(RegisterRequest request)
        {
            var account = await AccountRepository.GetByUserName(request.UserName);
            if (account != null) throw new AccountExceptions.Register.UserAlreadyExistsException(request.UserName);

            using var hmac = new HMACSHA256();

            account = _mapper.Map<Account>(request);
            account.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
            account.PasswordSalt = hmac.Key;
            account.Role = Account.UserRole.User.ToString();

            AccountRepository.Insert(account);

            return account;
        }

        public async Task<Account> UnregisterAsync(UnregisterRequest request)
        {
            var account = await AccountRepository.GetByUserName(request.UserName);
            if (account == null) throw new AccountExceptions.Unregister.UserDoesNotExistException(request.UserName);

            AccountRepository.Delete(account.ID);

            return account;
        }
    }
}