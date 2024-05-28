using FluentValidation;
using static CoolChat.WebAPI.Dto.Validators.ValidatorErrorMessages;

namespace CoolChat.WebAPI.Dto.Validators;

public class MessageDtoValidator : AbstractValidator<MessageDto>
{
    public MessageDtoValidator()
    {
        RuleFor(m => m.Username)
            .NotEmpty().WithMessage(NullOrEmpty())
            .MinimumLength(4).WithMessage(StringLengthShouldBeBiggerThan(4))
            .MaximumLength(32).WithMessage(StringLengthShouldBeLessThan(32));
        RuleFor(m => m.Content)
            .NotEmpty().WithMessage(NullOrEmpty())
            .MaximumLength(512).WithMessage(StringLengthShouldBeLessThan(512));
    }
}