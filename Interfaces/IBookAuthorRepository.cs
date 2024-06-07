using Library_Management_System.Models;

namespace Library_Management_System.Interfaces
{
    public interface IBookAuthorRepository
    {
        void AddBookAuthor(BookAuthor bookAuthor);
        IEnumerable<BookAuthor> IdBookAuthors(int bookId);
        IEnumerable<BookAuthor> BooksByAuthor(int authorId);
    }
}
