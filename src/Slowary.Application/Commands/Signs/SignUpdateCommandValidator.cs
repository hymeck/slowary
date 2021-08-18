using FluentValidation;

namespace Slowary.Application.Commands.Signs
{
    public class SignUpdateCommandValidator : AbstractValidator<SignUpdateCommand>
    {
        public SignUpdateCommandValidator()
        {
            RuleFor(c => c.SignId)
                .GreaterThan((ulong)0);
            
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