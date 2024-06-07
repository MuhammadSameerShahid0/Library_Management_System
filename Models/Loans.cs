using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class Loans
    {
        [Key]
        public int LoanID           { get; set; }

        public int UserID           { get; set; }
        public Users User            { get; set; } // Navigation property for User

        public int BookID           { get; set; }
        public Books Book           { get; set; } // Navigation property for Book

        public DateTime LoanDate    { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
