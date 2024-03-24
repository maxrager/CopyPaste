namespace CopyPaste.Server.Features.Shared.Connections
{
    public interface ICacheConnection
    {
        public string ConnectionName { get; }
        public ConnectionData Data { get; set; }
        public Task<string> Store();
        public Task<string> Get();
    }
}
