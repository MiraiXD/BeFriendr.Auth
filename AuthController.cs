using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BeFriendr.Accounts.Requests;
using BeFriendr.Auth.Accounts.Interfaces;
using BeFriendr.Auth.Authentication.Interfaces;
using BeFriendr.Auth.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BeFriendr.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly UnitOfWork _unitOfWork;
        public AuthController(UnitOfWork unitOfWork, IAccountService accountService, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _accountService = accountService;

        }
        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest request)
        {
            var account = await _accountService.RegisterAsync(request);
            var token = _tokenService.CreateToken(new List<Claim>{
                new Claim( JwtRegisteredClaimNames.NameId, request.UserName)
            });

            await _unitOfWork.SaveAllAsync();

            var response = new RegisterResponse
            {
                Email = account.Email,
                UserName = account.UserName,
                Token = token
            };
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            var user = await _accountService.LoginAsync(request);
            var token = _tokenService.CreateToken(new List<Claim>{
                new Claim( JwtRegisteredClaimNames.NameId, request.UserName)
            });
            var response = new LoginResponse
            {
                Email = user.Email,
                UserName = user.UserName,
                Token = token
            };
            return Ok(response);
        }
    }
}