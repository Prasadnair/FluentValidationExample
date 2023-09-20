using FluentValidation;
using FluentValidationTutorial.Model;

namespace FluentValidationTutorial.Validations
{
    public class PersonValidator:AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Age).InclusiveBetween(18,60).WithMessage("Age must be between 18 and 60");
            RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.EmailAddress).EmailAddress().WithMessage("Email is not valid");
        }
    }
}
