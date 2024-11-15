using ConversorBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConversorBack.Controllers
{
    [Route("api/subscription")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _subscriptionService;

        public SubscriptionController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet("GetConvertCount")]
        public ulong GetConversionCount()
        {
            int userID = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            ulong ConvCount = (ulong)_subscriptionService.GetTotalConversions(userID);
            return ConvCount;
        }
    }
}