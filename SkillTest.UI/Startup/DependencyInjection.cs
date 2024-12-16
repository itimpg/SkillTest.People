using SkillTest.UI.Proxies;
using SkillTest.UI.ProxyContracts;
using SkillTest.UI.MappingProfiles;

namespace SkillTest.UI.Startup
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPeopleServiceProxy>(provider =>
                new PeopleServiceProxy(configuration["ApiSettings:PeopleApiUrl"]!));

            services.AddAutoMapper(typeof(PersonMappingProfile).Assembly);

            return services;
        }
    }
}
