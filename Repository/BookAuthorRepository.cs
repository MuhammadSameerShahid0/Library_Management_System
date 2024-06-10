using Library_Management_System.Data;
using Library_Management_System.Interfaces;
using Library_Management_System.Models;
using System.Net;

namespace Library_Management_System.Repository
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        //private readonly List<BookAuthor> _bookAuthors = new List<BookAuthor>();
        private readonly DataContext _context;
        public BookAuthorRepository(DataContext context)
        {
            _context = context;
        }

        public async void AddBookAuthor(BookAuthor bookAuthor)
        {
            _context.BookAuthors.Add(bookAuthor);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<BookAuthor> BooksByAuthor(int authorId)
        {
           return _context.BookAuthors.Where(ba => ba.AuthorId == authorId);
        }

        public IEnumerable<BookAuthor> IdBookAuthors(int bookId)
        {
            return _context.BookAuthors.Where(ba => ba.BookId == bookId);
        }
    }
}
