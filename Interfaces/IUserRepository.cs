using Library_Management_System.Models;

namespace Library_Management_System.Interfaces
{
    public interface IUserRepository
    {
        //void AddUser (Users user);
        public Users LoginUserByUsernameAndPassword(string username, string password);
        Task  <IEnumerable<Users>> GetAllUsers();
        public Users GetUser(int id);
        Task<Users> AddUser(Users user);

    }
}
