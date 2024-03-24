namespace CopyPaste.Server.Features.Shared.Connections
{
    public abstract class CacheConnectionBase : ICacheConnection
    {
        public virtual string ConnectionName => string.Empty;
        public required ConnectionData Data { get; set; }
        public virtual Task<string> Get()
        {
            throw new NotImplementedException();
        }
        public virtual Task<string> Store()
        {
            throw new NotImplementedException();
        }
    }
}
