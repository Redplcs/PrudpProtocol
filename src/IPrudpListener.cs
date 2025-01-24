using System.Net;

namespace Redplcs.PrudpProtocol;

public interface IPrudpListener
{
	IPEndPoint LocalEndPoint { get; }

	ValueTask<IPrudpConnection> AcceptConnectionAsync(CancellationToken cancellationToken = default);
}
