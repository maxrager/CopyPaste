using MediatR;

namespace CopyPaste.Server.Features.Shared
{
    public class GetCacheDataRequest : IRequest<string>
    {
        public required string Key { get; set; }
        public required string ConnectionName { get; set; }
    }
}
