using CopyPaste.Server.Features.Shared.Connections;

namespace CopyPaste.Server.Features.Shared
{
    public abstract class HandlerBase(IEnumerable<ICacheConnection> cacheConnections)
    {
        private readonly IEnumerable<ICacheConnection> _cacheConnections = cacheConnections;

        protected ICacheConnection GetConnection(string connectionName)
        {
            return _cacheConnections.First(x => x.ConnectionName == connectionName);
        }
    }
}
