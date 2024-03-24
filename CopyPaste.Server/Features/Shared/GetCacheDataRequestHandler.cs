using AutoMapper;
using CopyPaste.Server.Features.Shared.Connections;
using MediatR;

namespace CopyPaste.Server.Features.Shared
{
    public class GetCacheDataRequestHandler(IEnumerable<ICacheConnection> cacheConnections, IMapper mapper) 
        : HandlerBase(cacheConnections), IRequestHandler<GetCacheDataRequest, string>
    {
        private readonly IMapper _mapper = mapper;
        public async Task<string> Handle(GetCacheDataRequest request, CancellationToken cancellationToken)
        {
            var cacheConnection = GetConnection(request.ConnectionName);
            cacheConnection.Data = _mapper.Map<ConnectionData>(request);
            return await cacheConnection.Get();
        }
    }
}
