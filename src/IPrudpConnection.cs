using System.Net;

namespace Redplcs.PrudpProtocol;

public interface IPrudpConnection
{
	IPEndPoint LocalEndPoint { get; }
	IPEndPoint RemoteEndPoint { get; }

	ValueTask CloseAsync(CancellationToken cancellationToken = default);
	ValueTask<Stream> GetStreamAsync(CancellationToken cancellationToken = default);
}
