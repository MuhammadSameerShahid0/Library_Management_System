//using AutoMapper;
//using Library_Management_System.DTO;
//using Library_Management_System.Interfaces;
//using Library_Management_System.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace Library_Management_System.Controller
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class BookAuthorController : ControllerBase
//    {
//        private readonly IBookAuthorRepository _bookAuthorRepository;
//        private readonly IMapper _mapper;

//        public BookAuthorController(IBookAuthorRepository bookAuthorRepository, IMapper mapper)
//        {
//            _bookAuthorRepository = bookAuthorRepository;
//            _mapper = mapper;
//        }

//        [HttpPost("Add_Book_Author")]
//        public ActionResult AddBookAuthor(BookAuthorDTO bookAuthorDto)
//        {
//            var bookAuthor = _mapper.Map<BookAuthor>(bookAuthorDto);
//            _bookAuthorRepository.AddBookAuthor(bookAuthor);
//            return CreatedAtAction(nameof(AddBookAuthor), new { bookId = bookAuthor.BookId }, bookAuthorDto);
//        }

//        [HttpGet("authors/{authorId}")]
//        public ActionResult<IEnumerable<BookAuthorDTO>> GetBooksForAuthor(int authorId)
//        {
//            var bookAuthors = _bookAuthorRepository.BooksByAuthor(authorId);
//            return Ok(_mapper.Map<IEnumerable<BookAuthorDTO>>(bookAuthors));
//        }

//        [HttpGet("books/{bookId}")]
//        public ActionResult<IEnumerable<BookAuthorDTO>> IdBookAuthors(int bookId)
//        {
//            var bookAuthors = _bookAuthorRepository.IdBookAuthors(bookId);
//            return Ok(_mapper.Map<IEnumerable<BookAuthorDTO>>(bookAuthors));
//        }
//    }
//}
