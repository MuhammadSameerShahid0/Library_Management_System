

using AutoMapper;
using Library_Management_System.DTO;
using Library_Management_System.Models;

namespace Library_Management_System.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Users , UserDTO>();
            CreateMap<UserDTO , Users>();

            CreateMap<Books , BooksDTO>();
            CreateMap<BooksDTO , Books>();

            CreateMap<Loans, LoansDTO>();
            CreateMap<Loans, LoansDTOWithoutReturn>();
            CreateMap<LoansDTO, Loans>();
            CreateMap<UpdateLoansDTO, Loans>();
            CreateMap<LoansDTOWithoutReturn, Loans>();

            CreateMap<Authors, AuthorDTO>();
            CreateMap<AuthorDTO , Authors>();

            CreateMap<BookAuthor , BookAuthorDTO>();
            CreateMap<BookAuthorDTO , BookAuthor>();
        }
    }
}
