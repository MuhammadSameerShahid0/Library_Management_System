using Library_Management_System.Models;

namespace Library_Management_System.Interfaces
{
    public interface IAuthorRepository
    {
        void AddAuthor(Authors author);
        Authors GetAuthor(int authorId);
        void UpdateAuthor(Authors author);
        Task<Authors> DeleteAuthor(Authors author);
    }
}
