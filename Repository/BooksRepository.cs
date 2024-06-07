using Library_Management_System.Interfaces;
using Library_Management_System.Models;

namespace Library_Management_System.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly List<Books> _books = new List<Books>();

       public async Task<Books> AddBook(Books book)
        {
            _books.Add(book);
            return book;
        }

        public async Task<Books> DeleteBook(Books book) 
        {
            _books.Remove(book);
            return book;
        }

        public async Task<IEnumerable<Books>> GetAllBooks()
        {
            return _books.OrderBy(b => b.BookId).ToList();
        }

        public Books GetBook(int bookId)
        {
            return _books.FirstOrDefault(b => b.BookId == bookId);
        }
        public async Task<Books> UpdateBook(Books book)
        {
            var existingBook = _books.FirstOrDefault(b => b.BookId == book.BookId);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.Genre = book.Genre;
            }
            return existingBook;
        }
    }
}
