using SkillTest.Proxy.Models;

namespace SkillTest.Proxy.ProxyContracts
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
