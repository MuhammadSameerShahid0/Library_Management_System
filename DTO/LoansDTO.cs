namespace Library_Management_System.DTO
{
    public class LoansDTO
    {
        public int LoanID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
    public class LoansDTOWithoutReturn
    {
        public int UserID { get; set; }
        public int BookID { get; set; }
        public int LoanID { get; set; }
        public DateTime LoanDate { get; set; }
    }
    public class UpdateLoansDTO
    {
        public int LoanID { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }

    public class BorrowBookLoansDTO
    {
        public int UserID { get; set; }
        public int BookID { get; set; }
        public int LoanID { get; set; }
        public DateTime LoanDate { get; set; }
    }
}
