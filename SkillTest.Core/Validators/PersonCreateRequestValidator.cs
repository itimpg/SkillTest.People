using FluentValidation;
using SkillTest.Core.DTOs;

namespace SkillTest.Core.Validators
{
    public class PersonCreateRequestValidator : AbstractValidator<PersonCreateRequest>
    {
        public PersonCreateRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required");
        }
    }
}
