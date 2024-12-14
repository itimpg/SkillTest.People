using AutoMapper;
using SkillTest.Core.DTOs;
using SkillTest.Core.Entities;

namespace SkillTest.Core.Mappers
{
    public class PersonCreateRequestToPeopleMappingProfile : Profile
    {
        public PersonCreateRequestToPeopleMappingProfile()
        {
            CreateMap<PersonCreateRequest, People>();
        }
    }
}
