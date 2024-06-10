using Library_Management_System.Data;
using Library_Management_System.Interfaces;
using Library_Management_System.Models;
using System.Net;

namespace Library_Management_System.Repository
{
    public class UserRepository : IUserRepository
    {
        //private readonly List<Users> _users = new List<Users>();
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Users> AddUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task <IEnumerable<Users>> GetAllUsers()
        {
            return _context.Users.OrderBy(u => u.UserId).ToList();
        }
        public Users GetUser(int id)
        {
            return _context.Users.Where(u => u.UserId == id).FirstOrDefault();
        }

        public Users LoginUserByUsernameAndPassword(string username, string password)
        {
            return _context.Users.Where(un => un.UserName == username && un.Password == password).FirstOrDefault();
        }
    }
}
