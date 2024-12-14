using SkillTest.Core.Entities;

namespace SkillTest.Core.RepositoryContracts
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<People>> GetPeople();
        Task<People?> GetPeopleById(Guid id); 
        Task<People?> AddPeople(People entity);
        Task<People?> EditPeople(People entity);
        Task<bool> DeletePeople(Guid id);
    }
}
