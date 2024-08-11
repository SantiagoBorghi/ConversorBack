using ConversorBack.DTOs;
using ConversorBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConversorBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public IActionResult CreateUser(UserRegisterDto dto)
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
        [HttpPut("updateSubscription")]
        public IActionResult UpdateSubscription(ActivateSubscriptionDto dto)
        {
            int userID = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            _userService.UpdateUserSubscription(userID, dto);
            return Ok("Subscription updated successfully!");
        }

        [HttpGet("GetSub")]
        public string GetSub()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            string sub = _userService.GetSubscription(userId);
            return sub.ToString();
        }
    }
}
