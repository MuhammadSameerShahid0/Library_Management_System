using Library_Management_System.Data;
using Library_Management_System.Interfaces;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management_System.Repositories
{
    public class LoanRepository : ILoansRepository
    {
        //private readonly List<Loans> _loans = new List<Loans>();
        private readonly DataContext _context;
        public LoanRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Loans> AddLoan(Loans loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();  
            return loan;
        }
        public IEnumerable<Loans> GetAllLoans()
        {
            return _context.Loans.OrderBy(L => L.LoanID).ToList(); 
        }
        public Loans GetLoan(int loanId)
        {
           return _context.Loans.FirstOrDefault(l => l.LoanID == loanId);
        }
        public Loans GetLoansByUser(int userId)
        {
            return _context.Loans.Where(u => u.UserID == userId).FirstOrDefault();
        }

        public async Task<Loans> UpdateLoan(Loans loan)
        {
            var existingLoan = _context.Loans.FirstOrDefault(ul => ul.LoanID == loan.LoanID);
            if (existingLoan != null)
            {
                existingLoan.LoanID = loan.LoanID;
                existingLoan.LoanDate = loan.LoanDate;
                existingLoan.ReturnDate = loan.ReturnDate;
            }
            await _context.SaveChangesAsync();
            return existingLoan;
        }
    }
}
