using Library_Management_System.Data;
using Library_Management_System.Models;


namespace Library_Management_System
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Users.Any())
            {
                // Seed users
                var users = new List<Users>
                {
                    new Users { UserName = "user1", Password = "password1", Email = "user1@example.com" },
                    new Users { UserName = "user2", Password = "password2", Email = "user2@example.com" },
                };
                dataContext.Users.AddRange(users);
                dataContext.SaveChanges();
            }

            if (!dataContext.Authors.Any())
            {
                // Seed authors
                var authors = new List<Authors>
                {
                    new Authors { Name = "Author 1", Biography = "Bio of Author 1" },
                    new Authors { Name = "Author 2", Biography = "Bio of Author 2" },
                };
                dataContext.Authors.AddRange(authors);
                dataContext.SaveChanges();
            }

            if (!dataContext.Books.Any())
            {
                // Seed books
                var books = new List<Books>
                {
                    new Books { Title = "Book 1", ISBN = "ISBN1", Genre = "Genre1" },
                    new Books { Title = "Book 2", ISBN = "ISBN2", Genre = "Genre2" },
                };
                dataContext.Books.AddRange(books);
                dataContext.SaveChanges();
            }

            if (!dataContext.Loans.Any())
            {
                // Seed loans
                var loans = new List<Loans>
                {
                    new Loans { UserID = dataContext.Users.First(u => u.UserName == "user1").UserId, BookID = dataContext.Books.First(b => b.Title == "Book 1").BookId, LoanDate = DateTime.Now },
                    new Loans { UserID = dataContext.Users.First(u => u.UserName == "user2").UserId, BookID = dataContext.Books.First(b => b.Title == "Book 2").BookId, LoanDate = DateTime.Now },
                };
                dataContext.Loans.AddRange(loans);
                dataContext.SaveChanges();
            }

            if (!dataContext.BookAuthors.Any())
            {
                // Seed book authors
                var bookAuthors = new List<BookAuthor>
                {
                    new BookAuthor { BookId = dataContext.Books.First(b => b.Title == "Book 1").BookId, AuthorId = dataContext.Authors.First(a => a.Name == "Author 1").AuthorId },
                    new BookAuthor { BookId = dataContext.Books.First(b => b.Title == "Book 2").BookId, AuthorId = dataContext.Authors.First(a => a.Name == "Author 2").AuthorId },
                };
                dataContext.BookAuthors.AddRange(bookAuthors);
                dataContext.SaveChanges();
            }
        }
    }
}
