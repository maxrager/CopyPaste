using AutoMapper;
using CopyPaste.Server.Features.Shared;
using CopyPaste.Server.Features.Shared.Connections;
using MediatR;

namespace CopyPaste.Server.Features.Clipboard
{
    public class StoreCacheDataCommandHandler(IEnumerable<ICacheConnection> cacheConnections, IMapper mapper) 
        : HandlerBase(cacheConnections), IRequestHandler<StoreCacheDataCommand, string>
    {
        private readonly IMapper _mapper = mapper;
        public async Task<string> Handle(StoreCacheDataCommand request, CancellationToken cancellationToken)
        {
            var cacheConnection = GetConnection(request.ConnectionName);
            cacheConnection.Data = _mapper.Map<ConnectionData>(request);
            return await cacheConnection.Store();
        }
    }
}
