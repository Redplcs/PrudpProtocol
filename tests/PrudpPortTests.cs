namespace Redplcs.PrudpProtocol.Tests;

public class PrudpPortTests
{
	[Theory]
	[InlineData(0x31, 1, PrudpStreamType.Secure)]
	[InlineData(0x3f, 15, PrudpStreamType.Secure)]
	public void Decode_FromEncoded_ReturnsExpectedStreamIdAndType(
		byte encoded,
		byte expectedStreamId,
		PrudpStreamType expectedStreamType)
	{
		var port = PrudpPort.Decode(encoded);

		Assert.Equal(expectedStreamId, port.StreamId);
		Assert.Equal(expectedStreamType, port.StreamType);
	}
}
