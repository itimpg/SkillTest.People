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
                return new ReadDbContext(connectionString!);
            });

            services.AddScoped<WriteDbContext>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("WriteConnection");
                return new WriteDbContext(connectionString!);
            });

            return services;
        }
    }
}
