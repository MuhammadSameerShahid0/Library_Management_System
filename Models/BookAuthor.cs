namespace Library_Management_System.Models
{
    public class BookAuthor
    {
        public int BookId       { get; set; }
        public Books Books      { get; set; }
        public int AuthorId     { get; set; }
        public Authors Authors  { get; set; }
    }
}
