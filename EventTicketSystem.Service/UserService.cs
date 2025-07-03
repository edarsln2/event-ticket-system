using EventTicketSystem.Entity;
using EventTicketSystem.Repository;
using EventTicketSystem.Factory;
using EventTicketSystem.Dto.Request;

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

        public User RegisterUser(RegisterUserRequest request)
        {
            var user = _userFactory.CreateUser(request); 
            var existing = _userRepository.GetByUserEmail(user.Email);
            if (existing != null)
            {
                throw new Exception("Bu e-posta zaten kayıtlı");
            }

            return _userRepository.RegisterUser(user);
        }

        public User? GetUserById(int userId)
        {
            var user = _userRepository.GetUserById(userId);

            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            return user;
        }

        public User? GetByUserEmail(string email)
        {
            return _userRepository.GetByUserEmail(email);
        }
    }
}