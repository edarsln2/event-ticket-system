using EventTicketSystem.Entity;
using System.Data;

namespace EventTicketSystem.Factory
{
    public class UserFactory
    {
        public User CreateUser(string userName, string email, string password, string role, DateTime birthdate)
        {
            return new User
            {
                UserName = userName,
                Email = email,
                PasswordHash = password,
                Role = string.IsNullOrWhiteSpace(role) ? "user" : role,
                BirthDate = DateTime.SpecifyKind(birthdate, DateTimeKind.Utc)
            };
        }
    }
}
