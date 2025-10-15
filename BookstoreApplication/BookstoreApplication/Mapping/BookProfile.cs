using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Models;

namespace BookstoreApplication.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile() {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AuthorFullName, 
                    opt => opt.MapFrom(src => src.Author != null? src.Author.FullName : string.Empty))
                .ForMember(dest => dest.PublisherName,
                    opt => opt.MapFrom(src => src.Publisher !=null? src.Publisher.Name : string.Empty))
                .ForMember(dest => dest.YearsSincePublished,
                    opt => opt.MapFrom(src => DateTime.Now.Year - src.PublishedDate.Year)); 

            CreateMap<Book, BookDetailsDto>()
                .ForMember(dest => dest.AuthorFullName, 
                    opt => opt.MapFrom(src => src.Author != null ? src.Author.FullName : string.Empty))
                .ForMember(dest => dest.PublisherName,
                    opt => opt.MapFrom(src => src.Publisher != null ? src.Publisher.Name : string.Empty));
        }
    }
}
