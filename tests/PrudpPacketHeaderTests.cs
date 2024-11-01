using System.Buffers;

namespace Redplcs.PrudpProtocol.Tests;

public class PrudpPacketHeaderTests
{
	[Fact]
	public void TryRead_FromBytes_ReturnsTrueAndOutNonEmptyHeader()
	{
		var bytes = Data.InitialHandshake;
		var sequence = new ReadOnlySequence<byte>(bytes.AsMemory());
		var reader = new SequenceReader<byte>(sequence);

		var read = PrudpPacketHeader.TryRead(ref reader, out var header);

		Assert.True(read);
		Assert.NotEqual(default, header);
	}
}
