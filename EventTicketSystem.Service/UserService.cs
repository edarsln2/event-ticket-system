using EventTicketSystem.Entity;
using EventTicketSystem.Factory;
using EventTicketSystem.Repository;
using EventTicketSystem.Infrastructure.Service;

namespace EventTicketSystem.Service
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly UserFactory _userFactory;
        private readonly PasswordHash _passwordHash;

        public UserService(UserRepository userRepository, UserFactory userFactory, PasswordHash passwordHash)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
            _passwordHash = passwordHash;
        }

        public User RegisterUser(string userName, string email, string password)
        {
            var existing = _userRepository.GetByUserEmail(email);
            if (existing != null)
            {
                throw new Exception("Bu e-posta zaten kayıtlı.");
            }

            var hashPassword = _passwordHash.HashPassword(password);
            var user = _userFactory.CreateUser(userName, email, hashPassword);
            return _userRepository.RegisterUser(user);
        }

        public User GetUserById(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            return user;
        }
    }
}
