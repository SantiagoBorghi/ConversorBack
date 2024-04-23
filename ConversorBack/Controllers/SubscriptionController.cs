using ConversorBack.Services.Interfaces;
using ConversorDeMonedaBackEnd2.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ConversorBack.Controllers
{
    [ApiController]
    [Route("api/subscription")]
    public class SubscriptionController : ControllerBase
    {
        private readonly IUserService _userService;

        public SubscriptionController(IUserService userService)
        {
            _userService = userService;
        }
    }
}