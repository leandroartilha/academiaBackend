using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace artsfitness.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ITokenService _tokenService;

        public AuthenticationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login", Name = "login")]
        public ActionResult Login(UserDTO user)
        {
            var token = _tokenService.GenerateToken(user);

            if (token == "")
                return Unauthorized("Usuário não existe");

            return Ok(token);
        }
    }
}
