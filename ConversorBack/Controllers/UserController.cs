using ConversorBack.Data;
using ConversorBack.DTOs;
using ConversorBack.Entities;
using ConversorBack.Entities.Enums;
using ConversorBack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ConversorBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ConversorDeMonedaContext _context;
        public UserController(UserService userService, ConversorDeMonedaContext context)
        {
            _userService = userService;
            _context = context;
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

        [HttpGet("GetRole")]
        public string GetRole()
        {
            int userID = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            string role = _userService.GetRole(userID);
            return role;
        }
    }
}
