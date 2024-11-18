using AuthorBookAuthorDetails1.Dto;
using AuthorBookAuthorDetails1.Models;
using AutoMapper;

namespace AuthorBookAuthorDetails1.Mappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.TotalBooks, val => val.MapFrom(src => src.Books.Count));
            CreateMap<AuthorDto, Author>();
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.DateOfRelease, val => val.MapFrom(src => src.DateOfRelease.ToUniversalTime()));
            CreateMap<BookDto, Book>();
            
            CreateMap<AuthorDetails, AuthorDetailsDto>()
                 .ForMember(dest => dest.CityLength, val => val.MapFrom(src => src.City.Length));
            CreateMap<AuthorDetailsDto, AuthorDetails>();
        }
       
    }
}
