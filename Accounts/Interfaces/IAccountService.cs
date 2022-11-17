using BeFriendr.Auth.Accounts.Entities;
using BeFriendr.Accounts.Requests;

namespace BeFriendr.Auth.Accounts.Interfaces
{
    public interface IAccountService
    {
        IAccountRepository AccountRepository { get; }
        Task<Account> RegisterAsync(RegisterRequest request);
        Task<Account> LoginAsync(LoginRequest request);
    }
}