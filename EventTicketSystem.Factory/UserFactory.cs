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
                PasswordHash = password
            };
        }
    }
}
