//using AutoMapper;
//using Library_Management_System.DTO;
//using Library_Management_System.Interfaces;
//using Library_Management_System.Models;
//using Library_Management_System.Repository;
//using Microsoft.AspNetCore.Mvc;

//namespace Library_Management_System.Controller
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthorController : ControllerBase
//    {
//        private readonly IAuthorRepository _authorRepository;
//        private readonly IMapper _mapper;
//        public AuthorController(IAuthorRepository authorRepository , IMapper mapper)
//        {
//            _authorRepository = authorRepository;
//            _mapper = mapper;
//        }

//        [HttpPost("Add_Author")]
//        public ActionResult AddAuthor(AuthorDTO authorDto)
//        {
//            var author = _mapper.Map<Authors>(authorDto);
//            _authorRepository.AddAuthor(author);
//            return CreatedAtAction(nameof(AddAuthor), new { id = author.AuthorId }, authorDto);
//        }

//        [HttpGet("Get_Author")]
//        public ActionResult<AuthorDTO> GetAuthor(int id)
//        {
//            var author = _mapper.Map<AuthorDTO>(_authorRepository.GetAuthor(id));
//            if (author == null)
//                return NotFound();
//            return Ok(author);
//        }

//        [HttpPut("Update_Author")]
//        public ActionResult UpdateAuthor(int id, AuthorDTO authorDto)
//        {
//            var author = _authorRepository.GetAuthor(id);
//            if (author == null)
//                return NotFound();

//            _mapper.Map(authorDto, author);
//            _authorRepository.UpdateAuthor(author);
//            return NoContent();
//        }
//    }
//}
