namespace CopyPaste.Server.Features.Shared.Connections
{
    public class ConnectionData
    {
        public required string Key { get; set; }
        public required string Value { get; set; }
        public TimeSpan Expiry { get; set; }
        public required ICacheConnection CacheConnection { get; set; }
    }
}
