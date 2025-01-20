using FluentValidation;
using workshop.wwwapi.ViewModel;

namespace workshop.wwwapi.Validators
{
    public class PetPostValidator : AbstractValidator<PetPost>
    {
        public PetPostValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MaximumLength(50);
            RuleFor(p => p.Age).InclusiveBetween(0, 100);
            RuleFor(p => p.Species).NotEmpty().MaximumLength(50);
        }
    }
}
