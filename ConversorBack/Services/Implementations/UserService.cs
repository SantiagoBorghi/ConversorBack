using ConversorBack.Data;
using ConversorBack.DTOs;
using ConversorBack.Entities;
using ConversorBack.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConversorBack.Services.Implementations
{
    public class UserService : IUserService
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

        public void Create(UserLoginDto dto)
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
        public void UpdateUserSubscription(int userId, ActivateSubscriptionDto dto)
        {
            var user = _context.Users.Find(userId);
            var subscription = _context.Subscriptions
                .Find(dto.newSubscriptionId);

            if (user != null)
            {
                user.SubscriptionId = dto.newSubscriptionId;
                user.TotalConversions = subscription.MaxConversions;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Usuario no encontrado.");
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
    }
}
