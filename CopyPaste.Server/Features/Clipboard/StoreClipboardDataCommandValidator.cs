using FluentValidation;

namespace CopyPaste.Server.Features.Clipboard
{
    public class StoreClipboardDataCommandValidator : AbstractValidator<StoreClipboardDataCommand>
    {
        public StoreClipboardDataCommandValidator()
        {
            RuleFor(x => x.Value).NotEmpty();
        }
    }
}
