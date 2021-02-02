using AutoMapper;
using MediumApi.Domain.Entities;
using MediumApi.Models;

namespace MediumApi.Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePostModel, Post>().ForMember(x => x.Id, opt => opt.Ignore());
        }   
    }
}