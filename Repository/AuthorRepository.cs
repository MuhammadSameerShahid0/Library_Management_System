using Library_Management_System.Data;
using Library_Management_System.Interfaces;
using Library_Management_System.Models;

namespace Library_Management_System.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        //private readonly List<Authors> _authors = new List<Authors>();
        private readonly DataContext _context;
        public AuthorRepository(DataContext context)
        {
            _context = context;
        }
        public async void AddAuthor(Authors author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }
        public async Task<Authors> DeleteAuthor(Authors author)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return author;
        }
        public Authors GetAuthor(int authorId)
        {
           return _context.Authors.FirstOrDefault(a => a.AuthorId == authorId);
        }
        public void UpdateAuthor(Authors author)
        {
            var existingAuthor = _context.Authors.FirstOrDefault(a => a.AuthorId == author.AuthorId);
            if (existingAuthor != null)
            {
                existingAuthor.Name = author.Name;
                existingAuthor.Biography = author.Biography;
            }
            _context.SaveChangesAsync();
        }
    }
}
