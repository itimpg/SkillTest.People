using AutoMapper;
using SkillTest.Core.DTOs;
using SkillTest.Core.Entities;
using SkillTest.Core.RepositoryContracts;
using SkillTest.Core.ServiceContracts;

namespace SkillTest.Core.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _repository;
        private readonly IMapper _mapper;

        public PeopleService(IPeopleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PersonResponse?> CreatePerson(PersonCreateRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            Random rand = new Random();
            People people = _mapper.Map<People>(request);
            people.RandomNumber = rand.Next();

            People addedPeople = await _repository.AddPeople(people);
            if (addedPeople == null)
            {
                return null;
            }

            return _mapper.Map<PersonResponse>(addedPeople);
        }

        public async Task<bool> DeletePerson(Guid id)
        {
            People existingPeople = await _repository.GetPeopleById(id);
            if (existingPeople == null)
            {
                return false;
            }

            return await _repository.DeletePeople(id);
        }

        public async Task<IEnumerable<PersonResponse>> GetAllPeople()
        {
            return _mapper.Map<IEnumerable<PersonResponse>>(await _repository.GetPeople());
        }

        public async Task<PersonResponse?> GetPerson(Guid id)
        {
            People existingPeople = await _repository.GetPeopleById(id);
            if (existingPeople == null)
            {
                return null;
            }

            return _mapper.Map<PersonResponse>(existingPeople);
        }

        public async Task<PersonResponse?> UpdatePerson(PersonUpdateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            People existingPeople = await _repository.GetPeopleById(request.Id);
            if (existingPeople == null)
            {
                return null;
            }

            Random rand = new Random();
            People people = _mapper.Map<People>(request);
            people.RandomNumber = rand.Next();

            People updatedPeople = await _repository.EditPeople(people);
            if (updatedPeople == null)
            {
                return null;
            }

            return _mapper.Map<PersonResponse>(updatedPeople);
        }
    }
}
