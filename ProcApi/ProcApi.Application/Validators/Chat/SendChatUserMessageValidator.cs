using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Chat.Requests;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.Chat;

public class SendChatUserMessageValidator : AbstractValidator<SendChatUserMessageRequest>
{
    public SendChatUserMessageValidator(IStringLocalizer<SharedResource> localizer)
    {
        RuleFor(x => x.Message)
            .NotEmpty()
            .WithMessage(localizer["MessageCantBeEmpty"]);

        RuleFor(x => x.ReceiverUserId)
            .GreaterThan(0)
            .WithMessage(localizer["ChatReceiverNotSet"]);
    }
}