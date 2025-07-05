using EventTicketSystem.Entity;

namespace EventTicketSystem.Factory
{
    public class UserFactory
    {
        public User CreateUser(string userName, string email, string password)
        {
            return new User
            {
                UserName = userName,
                Email = email,
                PasswordHash = HashPassword(password)
            };
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
