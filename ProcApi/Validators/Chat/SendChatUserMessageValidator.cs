using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.DTOs.Chat.Request;
using ProcApi.Resources;

namespace ProcApi.Validators.Chat;

public class SendChatUserMessageValidator : AbstractValidator<SendChatUserMessageRequestDto>
{
    public SendChatUserMessageValidator(IStringLocalizer<SharedResource> _localizer)
    {
        RuleFor(x => x.Message)
            .NotEmpty()
            .WithMessage(_localizer["MessageCantBeEmpty"]);

        RuleFor(x => x.ReceiverUserId)
            .GreaterThan(0)
            .WithMessage(_localizer["ChatReceiverNotSet"]);
    }
}