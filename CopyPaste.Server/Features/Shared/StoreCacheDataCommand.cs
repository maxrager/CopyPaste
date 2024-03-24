using MediatR;

namespace CopyPaste.Server.Features.Shared
{
    public class StoreCacheDataCommand : IRequest<string>
    {
        public required string Key { get; set; }
        public required string Value { get; set; }
        public required TimeSpan Expiry { get; set; }
        public required string ConnectionName { get; set; }
    }
}
