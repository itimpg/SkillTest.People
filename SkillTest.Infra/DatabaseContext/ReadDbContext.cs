namespace SkillTest.Infra.DatabaseContext
{
    public class ReadDbContext : ApplicationDbContext
    {
        public ReadDbContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}
