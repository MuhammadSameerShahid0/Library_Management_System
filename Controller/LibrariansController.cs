using AutoMapper;
using Library_Management_System.DTO;
using Library_Management_System.Interfaces;
using Library_Management_System.Models;
using Library_Management_System.Repositories;
using Library_Management_System.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Library_Management_System.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrariansController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LibrariansController(IBooksRepository booksRepository , IAuthorRepository authorRepository , IUserRepository userRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _authorRepository = authorRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        //Librarians Add Book
        [HttpPost("Add_Book")]
        public async Task<ActionResult<BooksDTO>> AddBook(BooksDTO booksDTO)
        {
            try
            {
                var book = _mapper.Map<Books>(booksDTO);
                var CreatedBook = await _booksRepository.AddBook(book);
                var createdBookDto = _mapper.Map<BooksDTO>(CreatedBook);
                return createdBookDto;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Librarians Edit Book
        [HttpPut("Edit_Book")]
        public async Task<ActionResult<BooksDTO>> UpdateBook(int bookid, [FromBody] BooksDTO bookdto)
        {
            if (bookid == bookdto.BookId)
            {
                try
                {
                    var book = _mapper.Map<Books>(bookdto);
                    var UpdateBook = await _booksRepository.UpdateBook(book);
                    var UpdateBookDto = _mapper.Map<BooksDTO>(UpdateBook);
                    return UpdateBookDto;
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return NotFound();
            }
        }

        //Librarians Delete Book
        [HttpDelete("Delete_Book")]
        public async Task<ActionResult<BooksDTO>> DeleteBook(int bookid)
        {
            var BookToDelete = _booksRepository.GetBook(bookid);

            if (_booksRepository.DeleteBook(BookToDelete) == null)
            {
                return NotFound();
            }
            return Ok(BookToDelete);
        }

        //Librarians Add Author
        [HttpPost("Add_Author")]
        public async Task<ActionResult<AuthorDTO>> AddAuthor(AuthorDTO authorDto)
        {
            try
            {
                var loans = _mapper.Map<Authors>(authorDto);
                var CreatedLoan = await _authorRepository.AddAuthor(loans);
                var createdLoanDto = _mapper.Map<AuthorDTO>(CreatedLoan);
                return Ok(createdLoanDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Librarians Edit Author
        [HttpPut("Edit_Author_Info")]
        public ActionResult UpdateAuthor(int id, AuthorDTO authorDto)
        {
            var author = _authorRepository.GetAuthor(id);
            if (author == null)
                return NotFound();

            _mapper.Map(authorDto, author);
            _authorRepository.UpdateAuthor(author);
            return NoContent();
        }

        //Librarians Delete Author
        [HttpDelete("Delete_Authors")]
        public async Task<ActionResult<AuthorDTO>> DeleteAuthor(int authorid)
        {
            var AuthorToDelete = _authorRepository.GetAuthor(authorid);

            if (_authorRepository.DeleteAuthor(AuthorToDelete) == null)
            {
                return NotFound();
            }
            return Ok(AuthorToDelete);
        }
    }
}
