using SkillTest.Core.DTOs;
using SkillTest.Core.ServiceContracts;

namespace SkillTest.Core.Services
{
    public class MockPeopleService : IPeopleService
    {
        public Task<PersonResponse?> CreatePerson(PersonCreateRequest request)
        {
            return Task.FromResult(new PersonResponse
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                RandomNumber = new Random().Next(),
                Active = request.Active,
            });
        }

        public Task<bool> DeletePerson(Guid id)
        {
            return Task.FromResult(true);
        }

        public Task<IEnumerable<PersonResponse>> GetAllPeople()
        {
            List<PersonResponse> items = new List<PersonResponse>();

            for (int i = 0; i < 10; i++)
            {
                items.Add(new PersonResponse
                {
                    Id = Guid.NewGuid(),
                    FirstName = $"FirstName{i}",
                    LastName = $"LastName{i}",
                    RandomNumber = new Random().Next(),
                    Active = i % 3 == 0
                });
            }

            return Task.FromResult(items.AsEnumerable());
        }

        public Task<PersonResponse?> GetPerson(Guid id)
        {
            return Task.FromResult(new PersonResponse
            {
                Id = Guid.NewGuid(),
                FirstName = $"FirstName{0}",
                LastName = $"LastName{0}",
                RandomNumber = new Random().Next(),
                Active = true
            });
        }

        public Task<PersonResponse?> UpdatePerson(PersonUpdateRequest request)
        {
            return Task.FromResult(new PersonResponse
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                RandomNumber = new Random().Next(),
                Active = request.Active,
            });
        }
    }
}
