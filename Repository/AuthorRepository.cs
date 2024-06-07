using Library_Management_System.Interfaces;
using Library_Management_System.Models;

namespace Library_Management_System.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly List<Authors> _authors = new List<Authors>();
        public void AddAuthor(Authors author)
        {
            _authors.Add(author);
        }
        public async Task<Authors> DeleteAuthor(Authors author)
        {
            _authors.Remove(author);
            return author;
        }
        public Authors GetAuthor(int authorId)
        {
           return _authors.FirstOrDefault(a => a.AuthorId == authorId);
        }
        public void UpdateAuthor(Authors author)
        {
            var existingAuthor = _authors.FirstOrDefault(a => a.AuthorId == author.AuthorId);
            if (existingAuthor != null)
            {
                existingAuthor.Name = author.Name;
                existingAuthor.Biography = author.Biography;
            }
        }
    }
}
