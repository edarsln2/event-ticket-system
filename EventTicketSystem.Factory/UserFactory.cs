using BCrypt.Net;
using EventTicketSystem.Dto.Request;
using EventTicketSystem.Entity;

namespace EventTicketSystem.Factory
{
    public class UserFactory
    {
        public User CreateUser(RegisterUserRequest request)
        {
            return new User
            {
                UserName = request.UserName,
                Email = request.Email,
                PasswordHash = HashPassword(request.Password)
            };
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

    }
}
