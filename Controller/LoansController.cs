//using AutoMapper;
//using Library_Management_System.DTO;
//using Library_Management_System.Interfaces;
//using Library_Management_System.Models;
//using Library_Management_System.Repositories;
//using Library_Management_System.Repository;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Mvc;

//namespace Library_Management_System.Controller
//{
//    [ApiController]
//    [Microsoft.AspNetCore.Mvc.Route("api/[Controller]")]
//    public class LoansController : ControllerBase
//    {
//        private readonly ILoansRepository _loansRepository;
//        private readonly IMapper _mapper;
//        public LoansController(ILoansRepository loansRepository, IMapper mapper)
//        {
//            _loansRepository = loansRepository;
//            _mapper = mapper;
//        }

//        [HttpPost("Add_Loan")]
//        public async Task<ActionResult<LoansDTOWithoutReturn>> AddLoan(LoansDTOWithoutReturn loansDTO)
//        {
//            try
//            {
//                var loan = _mapper.Map<Loans>(loansDTO);
//                var LoanAdd = await _loansRepository.AddLoan(loan);
//                var LoanAddDto = _mapper.Map<LoansDTOWithoutReturn>(LoanAdd);
//                return LoanAddDto;
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpGet("All_Loans")]
//        public ActionResult<IEnumerable<LoansDTO>> GetAllLoans()
//        {
//            var loans = _loansRepository.GetAllLoans();
//            var loanDtos = loans.Select(loan => new LoansDTO
//            {
//                LoanID = loan.LoanID,
//                UserID = loan.UserID,
//                BookID = loan.BookID,
//                LoanDate = loan.LoanDate,
//                ReturnDate = loan.ReturnDate
//            }).ToList();

//            return Ok(loanDtos);
//        }

//        [HttpGet("Loan_By_LoanId")]
//        public ActionResult<IEnumerable<LoansDTO>> GetLoan(int loanID)
//        {
//            var LoanId = _mapper.Map<LoansDTO>(_loansRepository.GetLoan(loanID));
//            if (LoanId == null)
//                return NotFound();
//            return Ok(LoanId);
//        }

//        [HttpGet("Loan_By_UserId")]
//        public ActionResult<IEnumerable<LoansDTO>> GetLoansByUser(int userId)
//        {
//            var LoanByUserId = _mapper.Map<LoansDTO>(_loansRepository.GetLoansByUser(userId));
//            if (LoanByUserId == null)
//                return NotFound();
//            return Ok(LoanByUserId);
//        }

//        [HttpPut("Update_Loan")]
//        public async Task<ActionResult<UpdateLoansDTO>> UpdateLoan(int loanid, [FromBody] UpdateLoansDTO updteloansDTO)
//        {
//            try
//            {
//                if (loanid != updteloansDTO.LoanID)
//                    return BadRequest("Loan ID mismatch");

//                var laonToUpdate = _mapper.Map<Loans>(updteloansDTO);

//                if (laonToUpdate == null)
//                    return NotFound($"User with Id = {loanid} not found");

//                var updateResult = _loansRepository.UpdateLoan(laonToUpdate);
//                if (updateResult != null)
//                {
//                    return Ok();
//                }
//                else
//                {
//                    return StatusCode(500, "A problem happened while handling your request.");
//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }

//        }
//    }
//}
