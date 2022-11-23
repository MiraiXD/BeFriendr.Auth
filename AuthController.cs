using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using BeFriendr.Accounts.Requests;
using BeFriendr.Auth.Accounts.Entities;
using BeFriendr.Auth.Accounts.Interfaces;
using BeFriendr.Auth.Authentication.Interfaces;
using BeFriendr.Auth.Responses;
using BeFriendr.Common.Messages;
using MassTransit;
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
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;
        public AuthController(UnitOfWork unitOfWork, IAccountService accountService, ITokenService tokenService, IPublishEndpoint publishEndpoint
        , IMapper mapper)
        {
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _accountService = accountService;

        }
        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterRequest request)
        {
            var account = await _accountService.RegisterAsync(request);
            var token = _tokenService.CreateToken(new List<Claim>{
                new Claim( ClaimTypes.NameIdentifier, request.UserName),
                new Claim(ClaimTypes.Role, account.Role)
            });

            await _unitOfWork.SaveAllAsync();
            var message = _mapper.Map<AccountCreatedMessage>(account);
            await _publishEndpoint.Publish(message);

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