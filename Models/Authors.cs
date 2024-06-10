using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class Authors
    {
        [Key]
        public int AuthorId     { get; set; }
        public string Name      { get; set; }
        public string Biography { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
