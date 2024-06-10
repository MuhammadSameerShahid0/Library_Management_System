using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class Books
    {
        [Key]
        public int BookId       { get; set; }
        public string Title     { get; set; }
        public string Author    { get; set; }
        public string ISBN      { get; set; }
        public string Genre     { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
