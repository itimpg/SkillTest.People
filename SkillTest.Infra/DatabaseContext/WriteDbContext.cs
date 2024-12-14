namespace SkillTest.Infra.DatabaseContext
{
    public class WriteDbContext : ApplicationDbContext
    {
        public WriteDbContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}
