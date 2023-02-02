using FluentValidation;
using SerializationExample;

namespace FunWithSerialization.Validation
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .Matches("^[a-zA-Z]+$")
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotNull()
                .Matches("^[a-zA-Z]+$")
                .NotEmpty();
            RuleFor(x => x.Age)
                .InclusiveBetween(0, 150)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.PlaceOfBirth)
                .NotNull()
                .NotEmpty()
                .Matches("^[a-zA-Z ]+$");
        }
    }
}
