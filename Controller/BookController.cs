//using AutoMapper;
//using Library_Management_System.DTO;
//using Library_Management_System.Interfaces;
//using Library_Management_System.Models;
//using Library_Management_System.Repository;
//using Microsoft.AspNetCore.Mvc;
//using System.Net;

//namespace Library_Management_System.Controller
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class BookController : ControllerBase
//    {
//        private readonly IBooksRepository _BooksRepository;
//        private readonly IMapper _mapper;
//        public BookController(IBooksRepository BooksRepository, IMapper mapper)
//        {
//            _BooksRepository = BooksRepository;
//            _mapper = mapper;
//        }

//        [HttpGet("All_Books")]
//        public async Task<ActionResult<IEnumerable<BooksDTO>>> GetAllBooks()
//        {
//            var AllBooks = await _BooksRepository.GetAllBooks();
//            if(AllBooks == null)
//                return NotFound();
//            return Ok(AllBooks);
//        }

//        [HttpGet("Get_Book_By_Id")]
//        [ProducesResponseType(200, Type = typeof(IEnumerable<Users>))]
//        public IActionResult GetBook(int id)
//        {
//            var Book = _mapper.Map<BooksDTO>(_BooksRepository.GetBook(id));
//            if (Book == null)
//                return NotFound();
//            return Ok(Book);
//        }

//        [HttpPost("Add_Book")]
//        public async Task<ActionResult<BooksDTO>> AddBook(BooksDTO booksDTO)
//        {
//            try
//            {
//                var book = _mapper.Map<Books>(booksDTO);
//                var CreatedBook = await _BooksRepository.AddBook(book);
//                var createdBookDto = _mapper.Map<BooksDTO>(CreatedBook);
//                return createdBookDto;
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpPut("Update_Book_Info")]
//        public async Task<ActionResult<BooksDTO>> UpdateBook(int bookid, [FromBody] BooksDTO bookdto)
//        {
//            if(bookid == bookdto.BookId)
//            {
//            try
//            {
//                var book = _mapper.Map<Books>(bookdto);
//                var UpdateBook = await _BooksRepository.UpdateBook(book);
//                var UpdateBookDto = _mapper.Map<BooksDTO>(UpdateBook);
//                return UpdateBookDto;
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//            }
//            else
//            {
//                return NotFound();
//            }
//        }

//    }
//}
