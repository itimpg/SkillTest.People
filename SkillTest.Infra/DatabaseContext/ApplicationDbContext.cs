using Microsoft.Data.SqlClient;
using System.Data;

namespace SkillTest.Infra.DatabaseContext
{
    public abstract class ApplicationDbContext
    {
        private readonly IDbConnection _connection;

        public ApplicationDbContext(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public IDbConnection DbConnection => _connection;
    }
}
