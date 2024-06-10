using Library_Management_System.Models;

namespace Library_Management_System.Interfaces
{
    public interface ILoansRepository
    {
        Task<Loans> AddLoan(Loans loan);
        Loans GetLoan(int loanId);
        IEnumerable<Loans> GetAllLoans();
        IEnumerable<Loans> GetLoansByUser(int userId);
        Task<Loans> UpdateLoan(Loans loan);
    }
}
