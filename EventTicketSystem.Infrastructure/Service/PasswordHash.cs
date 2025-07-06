using BCrypt.Net;

namespace EventTicketSystem.Infrastructure.Service
{
    public class PasswordHash
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
