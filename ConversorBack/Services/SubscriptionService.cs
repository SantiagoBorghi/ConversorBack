using ConversorBack.Data;

namespace ConversorBack.Services
{
    public class SubscriptionService
    {
        private readonly ConversorDeMonedaContext _context;
        public SubscriptionService(ConversorDeMonedaContext context)
        {
            _context = context;
        }
        public ulong? GetTotalConversions(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            return user?.TotalConversions;
        }
    }
}
