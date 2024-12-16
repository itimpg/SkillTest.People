using SkillTest.UI.Models;

namespace SkillTest.UI.ProxyContracts
{
    public interface IPeopleServiceProxy
    {
        Task<List<Person>> GetAllPeopleAsync();
        Task<Person> GetPersonByIdAsync(Guid id);
        Task<bool> CreatePersonAsync(Person person);
        Task<bool> UpdatePersonAsync(Person person);
        Task<bool> DeletePersonAsync(Guid id);
    }
}
