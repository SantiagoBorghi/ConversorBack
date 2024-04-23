using ConversorBack.DTOs;
using ConversorBack.Entities;

namespace ConversorBack.Services.Interfaces
{
    public interface IUserService
    {
        void Create(UserLoginDto dto);
        User? Validate(string email, string password);
        void UpdateUserSubscription(int userId, ActivateSubscriptionDto dto);
    }
}
