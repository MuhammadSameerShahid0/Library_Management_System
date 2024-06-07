using Library_Management_System.Interfaces;
using Library_Management_System.Models;
using System.Net;

namespace Library_Management_System.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<Users> _users = new List<Users>();
        public async Task<Users> AddUser(Users user)
        {
            _users.Add(user);
            return user;
        }
        public async Task <IEnumerable<Users>> GetAllUsers()
        {
            return _users.OrderBy(u => u.UserId).ToList();
        }
        public Users GetUser(int id)
        {
            return _users.FirstOrDefault(u => u.UserId == id);
        }

        public Users LoginUserByUsernameAndPassword(string username, string password)
        {
            return _users.FirstOrDefault(un => un.UserName == username && un.Password == password);
        }
    }
}
