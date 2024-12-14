using AutoMapper;
using SkillTest.Core.DTOs;
using SkillTest.Core.Entities;

namespace SkillTest.Core.Mappers
{
    public class PeopleToPersonResponseMappingProfile : Profile
    {
        public PeopleToPersonResponseMappingProfile()
        {
            CreateMap<People, PersonResponse>();
        }
    }
}
