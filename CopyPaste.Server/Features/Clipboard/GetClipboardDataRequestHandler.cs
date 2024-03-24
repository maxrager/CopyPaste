using AutoMapper;
using CopyPaste.Server.Features.Shared;
using MediatR;
using Microsoft.Extensions.Options;

namespace CopyPaste.Server.Features.Clipboard
{
    public class GetClipboardDataRequestHandler(IMediator mediator, 
        IMapper mapper,
        IOptions<DefaultSettings> defaultSettings) 
        : IRequestHandler<GetClipboardDataRequest, string>
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;
        private readonly DefaultSettings _defaultSettings = defaultSettings.Value;

        public async Task<string> Handle(GetClipboardDataRequest request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<GetCacheDataRequest>(request);
            data.ConnectionName = _defaultSettings.ClipboardConnection;
            var result = await _mediator.Send(data, cancellationToken);
            return result;
        }
    }
}
