using SkillTest.Core.DTOs;

namespace SkillTest.Core.ServiceContracts
{
    public interface IPeopleService
    {
        Task<IEnumerable<PersonResponse>> GetAllPeople();
        Task<PersonResponse?> GetPerson(Guid id);
        Task<PersonResponse?> CreatePerson(PersonCreateRequest request);
        Task<PersonResponse?> UpdatePerson(PersonUpdateRequest request);
        Task<bool> DeletePerson(Guid id);
    }
}
