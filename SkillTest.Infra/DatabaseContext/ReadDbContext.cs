using System.Data;

namespace SkillTest.Infra.DatabaseContext
{
    public class ReadDbContext : ApplicationDbContext
    {
        public ReadDbContext(IDbConnection connection) : base(connection) { }
    }
}
