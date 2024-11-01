using System.Buffers;

namespace Redplcs.PrudpProtocol.Tests;

public class PrudpPacketHeaderTests
{
	[Fact]
	public void TryRead_FromHandshakeData_ReturnsTrue()
	{
		var bytes = new byte[] { 0x3f, 0x31, 0x20, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x8, 0x0, 0x0, 0x0 };
		var sequence = new ReadOnlySequence<byte>(bytes);
		var reader = new SequenceReader<byte>(sequence);

		var read = PrudpPacketHeader.TryRead(ref reader, out var header);

		Assert.True(read);
	}
}
