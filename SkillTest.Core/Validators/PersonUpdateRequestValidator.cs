using FluentValidation;
using SkillTest.Core.DTOs;

namespace SkillTest.Core.Validators
{
    public class PersonUpdateRequestValidator : AbstractValidator<PersonUpdateRequest>
    {
        public PersonUpdateRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required");
        }
    }
}
