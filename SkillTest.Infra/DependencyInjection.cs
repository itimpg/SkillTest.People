using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillTest.Core.RepositoryContracts;
using SkillTest.Infra.DatabaseContext;
using SkillTest.Infra.Repositories;

namespace SkillTest.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<ReadDbContext>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("ReadConnection");
                var connection = new SqlConnection(connectionString);
                return new ReadDbContext(connection);
            });

            services.AddScoped<WriteDbContext>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("WriteConnection");
                var connection = new SqlConnection(connectionString);
                return new WriteDbContext(connection);
            });


            return services;
        }
    }
}
