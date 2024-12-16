using AutoMapper;
using SkillTest.UI.Models;
using SkillTest.UI.ViewModels;

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
