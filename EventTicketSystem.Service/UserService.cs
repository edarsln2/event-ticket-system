using EventTicketSystem.Entity;
using EventTicketSystem.Factory;
using EventTicketSystem.Repository;

namespace EventTicketSystem.Service
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly UserFactory _userFactory;

        public UserService(UserRepository userRepository, UserFactory userFactory)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
        }

        public User RegisterUser(string userName, string email, string password)
        {
            var user = _userFactory.CreateUser(userName, email, password);

            var existing = _userRepository.GetByUserEmail(email);
            if (existing != null)
            {
                throw new Exception("Bu e-posta zaten kayıtlı.");
            }

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
