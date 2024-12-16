using System.Data;

namespace SkillTest.Infra.DatabaseContext
{
    public abstract class ApplicationDbContext
    {
        private readonly IDbConnection _connection;

        protected ApplicationDbContext(IDbConnection connection)
        {
            _connection = connection;
        }

        public virtual IDbConnection DbConnection => _connection;
    }
}
