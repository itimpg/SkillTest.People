using System.Data;

namespace SkillTest.Infra.DatabaseContext
{
    public class WriteDbContext : ApplicationDbContext
    {
        public WriteDbContext(IDbConnection connection) : base(connection) { }
    }
}
