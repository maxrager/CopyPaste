using AutoMapper;
using CopyPaste.Server.Features.Shared;

namespace CopyPaste.Server.Features.Clipboard
{
    public class ClipboardDataMapper : Profile
    {
        public ClipboardDataMapper()
        {
            CreateMap<GetClipboardDataRequest, GetCacheDataRequest>();
            CreateMap<StoreClipboardDataCommand, StoreCacheDataCommand>();
        }
    }
}
