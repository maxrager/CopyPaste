using MediatR;

namespace CopyPaste.Server.Features.Clipboard
{
    public class GetClipboardDataRequest : IRequest<string>
    {
        public required string Key { get; set; }
    }
}
