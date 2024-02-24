using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace artsfitness.Controllers
{
    [Authorize(Roles = "Gentleman")]
    public class UsersController : Controller
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add-user", Name = "add-user")]
        public ActionResult AddUser(UserDTO user)
        {
            _userService.AddUser(user);
            return Ok();
        }

    }
}
