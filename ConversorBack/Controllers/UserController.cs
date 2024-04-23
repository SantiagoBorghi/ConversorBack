using ConversorBack.DTOs;
using ConversorBack.Services.Interfaces;
using ConversorDeMonedaBackEnd2.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace ConversorBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser(UserLoginDto dto)
        {
            try
            {
                _userService.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("User Created!", dto);
        }
        [HttpPut("{userId}/updateSubscription")]
        public IActionResult UpdateSubscription(int userId, ActivateSubscriptionDto dto)
        {
            _userService.UpdateUserSubscription(userId, dto);
            return Ok("Subscription updated successfully!");
        }
    }
}
