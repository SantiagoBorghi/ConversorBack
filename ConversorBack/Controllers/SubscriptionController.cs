using ConversorBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConversorBack.Controllers
{
    [ApiController]
    [Route("api/subscription")]
    public class SubscriptionController : ControllerBase
    {
        private readonly UserService _userService;

        public SubscriptionController(UserService userService)
        {
            _userService = userService;
        }
    }
}