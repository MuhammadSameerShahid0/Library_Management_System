using AutoMapper;
using Library_Management_System.DTO;
using Library_Management_System.Interfaces;
using Library_Management_System.Models;
using Library_Management_System.Repositories;
using Library_Management_System.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;
        private readonly ILoansRepository _loansRepository;
        private readonly IBooksRepository _bookRepository;
        public UsersController(IUserRepository UserRepository , IMapper mapper , ILoansRepository loansRepository , IBooksRepository bookRepository)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
            _loansRepository = loansRepository;
            _bookRepository = bookRepository;
        }

        [HttpGet("All_Users")]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
        {
            var AllUsers = await _UserRepository.GetAllUsers();
            return Ok(AllUsers);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(UserDTO userDto)
        {
            try
            {
                var user = _mapper.Map<Users>(userDto);
                var CreatedUser = await _UserRepository.AddUser(user);
                var createdUserDto = _mapper.Map<UserDTO>(CreatedUser);
                return createdUserDto;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            var userlogin = _mapper.Map<UserDTO>(_UserRepository.LoginUserByUsernameAndPassword(username, password));
            if (userlogin != null)
            {
                return Ok(userlogin);
            }
            return Unauthorized();
        }

        [HttpPost("Borrow_Book")]
        public IActionResult BorrowBook(int userid , int bookid , [FromBody] BorrowBookLoansDTO borrowBookDto)
        {
            var user = _mapper.Map<UserDTO>(_UserRepository.GetUser(borrowBookDto.UserID = userid));
            var book = _mapper.Map<BooksDTO>(_bookRepository.GetBook(borrowBookDto.BookID = bookid));

            if (user == null || book == null)
            {
                return BadRequest("Invalid user ID or book ID");
            }

            var loan = new Loans
            {
                LoanID = borrowBookDto.LoanID,
                UserID = borrowBookDto.UserID,
                BookID = borrowBookDto.BookID,
                LoanDate = DateTime.Now
            };

            _loansRepository.AddLoan(loan);
            return Ok();
        }

        [HttpPost("Return_Book")]
        public IActionResult ReturnBook(int userId, int loanId)
        {
            var loan = _loansRepository.GetLoan(loanId);
            if (loan == null || loan.UserID != userId)
            {
                return BadRequest("Invalid loan or user");
            }

            loan.ReturnDate = DateTime.Now;
            _loansRepository.UpdateLoan(loan);
            return Ok(loan);
        }

        [HttpGet("Loans_History")]
        public IActionResult GetLoanHistory(int userId)
        {
            var loans = _mapper.Map<LoansDTO>(_loansRepository.GetLoansByUser(userId));
            if (loans == null)
                return NotFound();
            return Ok(loans);
        }
    }
}
