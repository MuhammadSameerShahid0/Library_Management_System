using Library_Management_System.Models;

namespace Library_Management_System.Interfaces
{
    public interface IBooksRepository
    {
        Task<Books> AddBook(Books book);
        Books GetBook(int bookId);
        Task <IEnumerable<Books>> GetAllBooks();
        Task<Books> UpdateBook(Books book);
        Task<Books> DeleteBook(Books book);
    }
}
