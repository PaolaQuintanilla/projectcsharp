using Asp.Learning.Commanding.Commands.CreateAuthor;
using Asp.Learning.Commanding.Commands.UpdateAuthor;
using Asp.Learning.Dtos.requests;
using AutoMapper;

namespace Asp.Learning.Profiles;

public class AuthorsProfile : Profile
{
    public AuthorsProfile()
    {
        CreateMap<CreateAuthorV1Dto, CreateAuthorCommand>();
        CreateMap<UpdateAuthorV1Dto, UpdateAuthorCommand>();
        //CreateMap<CreateAuthorCommand, Author>()
        //    .ConstructUsing(src => new Author(src.FirstName, src.LastName, src.MainCategory)) // Constructor mapping
        //    .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));
    }
}
