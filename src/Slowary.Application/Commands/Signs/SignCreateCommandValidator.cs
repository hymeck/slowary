using FluentValidation;

namespace Slowary.Application.Commands.Signs
{
    public class SignCreateCommandValidator : AbstractValidator<SignCreateCommand>
    {
        public SignCreateCommandValidator()
        {
            RuleFor(c => c.Value)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(c => c.Example)
                .MaximumLength(255);
            
            RuleFor(c => c.Note)
                .MaximumLength(255);
            
            RuleFor(c => c.Semantics)
                .MaximumLength(255);
            
            RuleFor(c => c.Source)
                .MaximumLength(255);
        }
    }
}