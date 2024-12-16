using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SkillTest.Core.Mappers;
using SkillTest.Core.ServiceContracts;
using SkillTest.Core.Services;
using SkillTest.Core.Validators;

namespace SkillTest.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<PersonCreateRequestValidator>();
            services.AddAutoMapper(typeof(PeopleToPersonResponseMappingProfile).Assembly);
            services.AddScoped<IPeopleService, PeopleService>();
            //services.AddScoped<IPeopleService, MockPeopleService>();
            
            return services;
        }
    }
}
