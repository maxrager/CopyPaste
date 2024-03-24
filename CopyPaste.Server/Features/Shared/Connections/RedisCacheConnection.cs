using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace CopyPaste.Server.Features.Shared.Connections
{
    public class RedisCacheConnection(IOptions<ConnectionStrings> connectionStrings) : CacheConnectionBase
    {
        private readonly ConnectionStrings _connectionStrings = connectionStrings.Value;
        public override string ConnectionName => ConnectionNameConstants.RedisCacheConnectionName;
        public override async Task<string> Get()
        {
            var database = await GetDatabase();
            var value = await database.StringGetAsync(Data.Key);
            return value.HasValue ? value.ToString() : string.Empty;
        }
        public override async Task<string> Store()
        {
            var database = await GetDatabase();
            await database.StringSetAsync(Data.Key, Data.Value, Data.Expiry);
            return Data.Key;
        }
        private async Task<IDatabaseAsync> GetDatabase()
        {
            var connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(_connectionStrings.RedisCache);
            return connectionMultiplexer.GetDatabase();
        }
    }
}
