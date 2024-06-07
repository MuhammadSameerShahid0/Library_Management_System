using Library_Management_System.Interfaces;
using Library_Management_System.Models;
using System.Net;

namespace Library_Management_System.Repository
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        private readonly List<BookAuthor> _bookAuthors = new List<BookAuthor>();

        public void AddBookAuthor(BookAuthor bookAuthor)
        {
            _bookAuthors.Add(bookAuthor);
        }

        public IEnumerable<BookAuthor> BooksByAuthor(int authorId)
        {
           return _bookAuthors.Where(ba => ba.AuthorId == authorId);
        }

        public IEnumerable<BookAuthor> IdBookAuthors(int bookId)
        {
            return _bookAuthors.Where(ba => ba.BookId == bookId);
        }
    }
}
