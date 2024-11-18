using ConversorBack.Data;
using ConversorBack.DTOs;
using ConversorBack.Entities;

namespace ConversorBack.Services
{
    public class UserService
    {
        private readonly ConversorDeMonedaContext _context;
        public UserService(ConversorDeMonedaContext context)
        {
            _context = context;
        }
        public User? Validate(string email, string password)
        {
            return _context.Users.FirstOrDefault(p => p.Email == email && p.Password == password);
        }
        public void Create(UserRegisterDto dto)
        {
            User newUser = new User()
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
        public void UpdateUserSubscription(int userID, ActivateSubscriptionDto dto)
        {
            var user = _context.Users.Find(userID);
            var subscription = _context.Subscriptions.Find(dto.newSubscriptionId);

            if (user != null)
            {
                user.SubscriptionId = subscription.Id;
                user.TotalConversions = subscription.MaxConversions;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Usuario no encontrado.");
            }
        }
        public string GetSubscription(int userId)
        {
            User user = _context.Users.First(u => u.Id == userId);
            if (user.SubscriptionId == null)
            {
                return "No subscription";
            }
            else
            {
                Subscription subscription = _context.Subscriptions.First(s => s.Id == user.SubscriptionId);
                return subscription.Type.ToString();
            }
        }
        public void UseConversions(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                user.TotalConversions = user.TotalConversions - 1;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Usuario no encontrado.");
            }
        }

        public string GetRole(int userId)
        {
            User user = _context.Users.First(u => u.Id == userId);
            if (user == null)
            {
                return "User not found";
            }
            return user.Role.ToString();
        }
    }
}