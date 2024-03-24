using AutoMapper;
using CopyPaste.Server.Features.Shared.Connections;

namespace CopyPaste.Server.Features.Shared
{
    public class CacheDataMapper : Profile
    {
        public CacheDataMapper()
        {
            CreateMap<GetCacheDataRequest, ConnectionData>();
            CreateMap<StoreCacheDataCommand, ConnectionData>();
        }
    }
}
