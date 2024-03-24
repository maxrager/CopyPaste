using MediatR;

namespace CopyPaste.Server.Features.Clipboard
{
    public class StoreClipboardDataCommand : IRequest<string>
    {
        public required string Value { get; set; }
    }
}
