using Dapper;
using Microsoft.EntityFrameworkCore;
using SkillTest.Core.Entities;
using SkillTest.Core.RepositoryContracts;
using SkillTest.Infra.DatabaseContext;

namespace SkillTest.Infra.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly ReadDbContext _readDbContext;
        private readonly WriteDbContext _writeDbContext;

        public PeopleRepository(ReadDbContext readDbContext, WriteDbContext writeDbContext)
        {
            _readDbContext = readDbContext;
            _writeDbContext = writeDbContext;
        }

        public async Task<People?> AddPeople(People entity)
        {
            string query = @"INSERT INTO dbo.People (Id, FirstName, LastName, RandomNumber, Active) VALUES (@Id, @FirstName, @LastName, @RandomNumber, @Active)";
            entity.Id = Guid.NewGuid();
            int rowCountAffected = await _writeDbContext.DbConnection.ExecuteAsync(query, entity);
            if (rowCountAffected > 0)
            {
                return entity;
            }

            return null;
        }

        public async Task<bool> DeletePeople(Guid id)
        {
            string query = "SELECT * FROM dbo.People WHERE Id = @Id";
            People? existingPeople = await _readDbContext.DbConnection.QueryFirstOrDefaultAsync<People>(query, new { Id = id });
            if (existingPeople == null)
            {
                return false;
            }

            string deleteQuery = "DELETE FROM dbo.People WHERE Id = @Id";
            int rowCountAffected = await _writeDbContext.DbConnection.ExecuteAsync(deleteQuery, new { Id = id });
            return rowCountAffected > 0;
        }

        public async Task<People?> EditPeople(People entity)
        {
            string query = @"SELECT * FROM dbo.People WHERE Id = @Id";

            People? existingPeople = await _readDbContext.DbConnection.QueryFirstOrDefaultAsync<People>(query, new { Id = entity.Id });
            if (existingPeople == null)
            {
                return null;
            }

            string updateQuery = @"UPDATE dbo.People SET FirstName=@FirstName, LastName=@LastName, RandomNumber=@RandomNumber, Active=@Active WHERE Id = @Id";

            int rowCountAffected = await _writeDbContext.DbConnection.ExecuteAsync(updateQuery, entity);
            if (rowCountAffected > 0)
            {
                return entity;
            }

            return null;
        }

        public Task<IEnumerable<People>> GetPeople()
        {
            string query = @"SELECT * FROM dbo.People";

            return _readDbContext.DbConnection.QueryAsync<People>(query);
        }

        public Task<People?> GetPeopleById(Guid id)
        {
            string query = @"SELECT * FROM dbo.People WHERE Id = @Id";

            return _readDbContext.DbConnection.QueryFirstOrDefaultAsync<People>(query, new { Id = id });
        }
    }
}
