using AutoMapper;
using SkillTest.Core.DTOs;
using SkillTest.Core.Entities;

namespace SkillTest.Core.Mappers
{
    public class PersonUpdateRequestToPeopleMappingProfile : Profile
    {
        public PersonUpdateRequestToPeopleMappingProfile()
        {
            CreateMap<PersonUpdateRequest, People>();
        }
    }
}
