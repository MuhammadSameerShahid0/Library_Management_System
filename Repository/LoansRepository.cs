using Library_Management_System.Interfaces;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management_System.Repositories
{
    public class LoanRepository : ILoansRepository
    {
        private readonly List<Loans> _loans = new List<Loans>();
        public async Task<Loans> AddLoan(Loans loan)
        {
            _loans.Add(loan);
            return loan;
        }
        public IEnumerable<Loans> GetAllLoans()
        {
            return _loans.OrderBy(L => L.LoanID).ToList(); 
        }
        public Loans GetLoan(int loanId)
        {
           return _loans.FirstOrDefault(l => l.LoanID == loanId);
        }
        public Loans GetLoansByUser(int userId)
        {
            return _loans.Where(u => u.UserID == userId).FirstOrDefault();
        }

        public async Task<Loans> UpdateLoan(Loans loan)
        {
            var existingLoan = _loans.FirstOrDefault(ul => ul.LoanID == loan.LoanID);
            if (existingLoan != null)
            {
                existingLoan.LoanID = loan.LoanID;
                existingLoan.LoanDate = loan.LoanDate;
                existingLoan.ReturnDate = loan.ReturnDate;
            }
            return existingLoan;
        }
    }
}
