using EventTicketSystem.Data;
using EventTicketSystem.Entity;
using Microsoft.EntityFrameworkCore; 

namespace EventTicketSystem.Repository
{
    public class UserRepository
    {
        private readonly AppDbContext _context; 

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User RegisterUser(User user) 
        {
            _context.Users.Add(user); 
            _context.SaveChanges(); 
            return user; 
        }

        public User? GetByUserEmail(string email)
        {
            return _context.Users.FirstOrDefault(e => e.Email == email);
        }

        public User? GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }
    }
}