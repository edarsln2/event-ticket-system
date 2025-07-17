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

        public UserService(UserRepository userRepository, UserFactory userFactory)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
        }

        public User RegisterUser(string userName, string email, string password, string role, DateTime birthdate)
        {
            var existing = _userRepository.GetByUserEmail(email);
            if (existing != null)
            {
                throw new Exception("Bu e-posta zaten kayıtlı.");
            }

            var hash = PasswordHasher.Hash(password);
            var user = _userFactory.CreateUser(userName, email, hash, role, birthdate);
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

        public User Login(string email, string password)
        {
            var user = _userRepository.GetByUserEmail(email);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            var psswrd = PasswordHasher.Verify(password, user.PasswordHash);
            if (!psswrd)
            {
                throw new Exception("Şifre hatalı.");
            }

            return user;
        }
        public bool IsBirthdayToday(DateTime birthDate)
        {
            var today = DateTime.Today;
            return birthDate.Month == today.Month && birthDate.Day == today.Day;
        }

        public bool IsStudent(DateTime birthDate)
        {
            var today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            if (birthDate.Month > today.Month || (birthDate.Month == today.Month && birthDate.Day > today.Day))
            {
                age--;
            }

            return age >= 18 && age <= 25;
        }
    }
}
