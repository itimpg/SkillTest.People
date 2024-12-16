using AutoMapper;
using SkillTest.Proxy.Models;
using SkillTest.UI.Models;

namespace SkillTest.UI.MappingProfiles
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, PersonViewModel>().ReverseMap();
        }
    }
}
