using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace CopyPaste.Server.Features.Shared.Connections
{
    public class InMemoryConnection(IMemoryCache memoryCache, IOptions<CacheExpirySettings> cacheExpirySettings) : CacheConnectionBase
    {
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly CacheExpirySettings _cacheExpirySettings = cacheExpirySettings.Value;
        public override string ConnectionName => ConnectionNameConstants.InMemoryConnectionName;
        public override async Task<string> Get()
        {
            var result = await _memoryCache.GetOrCreateAsync(Data.Key, x =>
            {
                x.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheExpirySettings.InMemoryDefault);
                return Task.FromResult(string.Empty);
            });

            return result ?? string.Empty;
        }
        public override Task<string> Store()
        {
            _memoryCache.Set(Data.Key, Data.Value, Data.Expiry);
            return Task.FromResult(Data.Key);
        }
    }
}
