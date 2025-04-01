using Asp.Learning.Commanding.Commands.CreateAuthor;
using Asp.Learning.Dtos.requests;
using Asp.Learning.repositories.Entities;
using AutoMapper;

namespace Asp.Learning.Profiles
{
    public class AuthorsProfile: Profile
    {
        public AuthorsProfile()
        {
            CreateMap<CreateAuthorV1Dto, CreateAuthorCommand>();
            //CreateMap<CreateAuthorCommand, Author>()
            //    .ConstructUsing(src => new Author(src.FirstName, src.LastName, src.MainCategory)) // Constructor mapping
            //    .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));
        }
    }
}
