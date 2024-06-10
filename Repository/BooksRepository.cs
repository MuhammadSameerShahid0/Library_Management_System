using Library_Management_System.Data;
using Library_Management_System.Interfaces;
using Library_Management_System.Models;

namespace Library_Management_System.Repository
{
    public class BooksRepository : IBooksRepository
    {
        //private readonly List<Books> _books = new List<Books>();
        private readonly DataContext _context;
        public BooksRepository(DataContext context)
        { _context = context; }
       public async Task<Books> AddBook(Books book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Books> DeleteBook(Books book) 
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<IEnumerable<Books>> GetAllBooks()
        {
            return _context.Books.OrderBy(b => b.BookId).ToList();
        }

        public Books GetBook(int bookId)
        {
            return _context.Books.FirstOrDefault(b => b.BookId == bookId);
        }
        public async Task<Books> UpdateBook(Books book)
        {
            var existingBook = _context.Books.FirstOrDefault(b => b.BookId == book.BookId);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.Genre = book.Genre;
            }
            await _context.SaveChangesAsync();
            return existingBook;
        }
    }
}
