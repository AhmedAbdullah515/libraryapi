using AutoMapper;
using LibrarySystem.DTOs.BookDTOs;
using LibrarySystem.Models;

namespace LibrarySystem.Mapping
{
    public class MppingProfile:Profile
    {
        public MppingProfile()
        {
            CreateMap<CreateBookDTO, Book>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}
