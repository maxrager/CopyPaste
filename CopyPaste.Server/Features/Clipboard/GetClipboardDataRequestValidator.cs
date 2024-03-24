using FluentValidation;

namespace CopyPaste.Server.Features.Clipboard
{
    public class GetClipboardDataRequestValidator : AbstractValidator<GetClipboardDataRequest>
    {
        public GetClipboardDataRequestValidator()
        {
            RuleFor(x => x.Key).NotEmpty();
        }
    }
}
