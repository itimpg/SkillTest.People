using AutoMapper;
using Moq;
using SkillTest.Core.DTOs;
using SkillTest.Core.Entities;
using SkillTest.Core.RepositoryContracts;
using SkillTest.Core.Services;

namespace SkillTest.Core.Tests.Services
{
    public class PeopleServiceTests
    {
        private readonly Mock<IPeopleRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly PeopleService _service;

        public PeopleServiceTests()
        {
            _repositoryMock = new Mock<IPeopleRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new PeopleService(_repositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task CreatePerson_WithValidRequest_ReturnsPersonResponse()
        {
            // Arrange
            var request = new PersonCreateRequest();
            var people = new People();
            var addedPeople = new People { Id = Guid.NewGuid(), RandomNumber = 42 };
            var response = new PersonResponse { Id = addedPeople.Id };

            _mapperMock.Setup(m => m.Map<People>(request)).Returns(people);
            _repositoryMock.Setup(r => r.AddPeople(people)).ReturnsAsync(addedPeople);
            _mapperMock.Setup(m => m.Map<PersonResponse>(addedPeople)).Returns(response);

            // Act
            var result = await _service.CreatePerson(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(addedPeople.Id, result.Id);
            _mapperMock.Verify(m => m.Map<People>(request), Times.Once);
            _repositoryMock.Verify(r => r.AddPeople(people), Times.Once);
            _mapperMock.Verify(m => m.Map<PersonResponse>(addedPeople), Times.Once);
        }

        [Fact]
        public async Task CreatePerson_WithNullRequest_ThrowsArgumentNullException()
        {
            // Arrange
            PersonCreateRequest request = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreatePerson(request));
        }

        [Fact]
        public async Task DeletePerson_WithValidId_ReturnsTrue()
        {
            // Arrange
            var id = Guid.NewGuid();
            var existingPeople = new People { Id = id };

            _repositoryMock.Setup(r => r.GetPeopleById(id)).ReturnsAsync(existingPeople);
            _repositoryMock.Setup(r => r.DeletePeople(id)).ReturnsAsync(true);

            // Act
            var result = await _service.DeletePerson(id);

            // Assert
            Assert.True(result);
            _repositoryMock.Verify(r => r.GetPeopleById(id), Times.Once);
            _repositoryMock.Verify(r => r.DeletePeople(id), Times.Once);
        }

        [Fact]
        public async Task DeletePerson_WithNonExistentId_ReturnsFalse()
        {
            // Arrange
            var id = Guid.NewGuid();

            _repositoryMock.Setup(r => r.GetPeopleById(id)).ReturnsAsync((People)null);

            // Act
            var result = await _service.DeletePerson(id);

            // Assert
            Assert.False(result);
            _repositoryMock.Verify(r => r.GetPeopleById(id), Times.Once);
            _repositoryMock.Verify(r => r.DeletePeople(It.IsAny<Guid>()), Times.Never);
        }

        [Fact]
        public async Task GetAllPeople_ReturnsPersonResponseList()
        {
            // Arrange
            var peopleList = new List<People>
        {
            new People { Id = Guid.NewGuid() },
            new People { Id = Guid.NewGuid() }
        };
            var responseList = new List<PersonResponse>
        {
            new PersonResponse { Id = peopleList[0].Id },
            new PersonResponse { Id = peopleList[1].Id }
        };

            _repositoryMock.Setup(r => r.GetPeople()).ReturnsAsync(peopleList);
            _mapperMock.Setup(m => m.Map<IEnumerable<PersonResponse>>(peopleList)).Returns(responseList);

            // Act
            var result = await _service.GetAllPeople();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            _repositoryMock.Verify(r => r.GetPeople(), Times.Once);
            _mapperMock.Verify(m => m.Map<IEnumerable<PersonResponse>>(peopleList), Times.Once);
        }

        [Fact]
        public async Task UpdatePerson_WithValidRequest_ReturnsUpdatedPersonResponse()
        {
            // Arrange
            var request = new PersonUpdateRequest { Id = Guid.NewGuid() };
            var existingPeople = new People { Id = request.Id };
            var updatedPeople = new People { Id = request.Id, RandomNumber = 42 };
            var response = new PersonResponse { Id = updatedPeople.Id };

            _repositoryMock.Setup(r => r.GetPeopleById(request.Id)).ReturnsAsync(existingPeople);
            _mapperMock.Setup(m => m.Map<People>(request)).Returns(updatedPeople);
            _repositoryMock.Setup(r => r.EditPeople(updatedPeople)).ReturnsAsync(updatedPeople);
            _mapperMock.Setup(m => m.Map<PersonResponse>(updatedPeople)).Returns(response);

            // Act
            var result = await _service.UpdatePerson(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedPeople.Id, result.Id);
            _repositoryMock.Verify(r => r.GetPeopleById(request.Id), Times.Once);
            _mapperMock.Verify(m => m.Map<People>(request), Times.Once);
            _repositoryMock.Verify(r => r.EditPeople(updatedPeople), Times.Once);
            _mapperMock.Verify(m => m.Map<PersonResponse>(updatedPeople), Times.Once);
        }
    }

}
