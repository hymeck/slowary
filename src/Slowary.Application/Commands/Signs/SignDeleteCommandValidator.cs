using FluentValidation;

namespace Slowary.Application.Commands.Signs
{
    public class SignDeleteCommandValidator : AbstractValidator<SignDeleteCommand>
    {
        public SignDeleteCommandValidator()
        {
            RuleFor(x => x.SignId)
                .GreaterThan((ulong) 0);
        }
    }
}