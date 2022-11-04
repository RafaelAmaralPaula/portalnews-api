using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalNews.Api.Services;
using PortalNews.Application.DTO.UserDataTransferObject;
using PortalNews.Application.Services.Interfaces;
using PortalNews.Infratructure.Persistences.Interfaces;

namespace PortalNews.Api.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly TokenService _tokenService;

        private readonly IUserRepository _userRepository;

        public AccountController (TokenService tokenService , IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository= userRepository;
        }


        [AllowAnonymous]
        [HttpPost("/login")]
        public IActionResult Login([FromBody] LoginDTO logindDTO)
        {
            var user =  _userRepository.GetByEmail(logindDTO.Email);
            var token = _tokenService.GenerateToken(user);
            return Ok(token);
        }

    }
}
