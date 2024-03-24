using AutoMapper;
using CopyPaste.Server.Features.Shared;
using MediatR;
using Microsoft.Extensions.Options;

namespace CopyPaste.Server.Features.Clipboard
{
    public class StoreClipboardDataCommandHandler(IMediator mediator, 
        IMapper mapper, 
        IOptions<CacheExpirySettings> cacheExpirySettings,
        IOptions<DefaultSettings> defaultSettings) 
        : IRequestHandler<StoreClipboardDataCommand, string>
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;
        private readonly CacheExpirySettings _cacheExpirySettings = cacheExpirySettings.Value;
        private readonly DefaultSettings _defaultSettings = defaultSettings.Value;

        public async Task<string> Handle(StoreClipboardDataCommand request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<StoreCacheDataCommand>(request);
            data.Key = Guid.NewGuid().ToString();
            data.Expiry = TimeSpan.FromSeconds(_cacheExpirySettings.Clipboard);
            data.ConnectionName = _defaultSettings.ClipboardConnection;
            var result = await _mediator.Send(data, cancellationToken);
            return result;
        }
    }
}
