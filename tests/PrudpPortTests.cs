namespace Redplcs.PrudpProtocol.Tests;

public class PrudpPortTests
{
	[Theory]
	[InlineData(1, PrudpStreamType.Secure, 0x31)]
	[InlineData(15, PrudpStreamType.Secure, 0x3f)]
	public void Encode_FromPort_ReturnsByte(
		byte streamId,
		PrudpStreamType streamType,
		byte expectedByte)
	{
		var port = new PrudpPort
		{
			StreamId = streamId,
			StreamType = streamType,
		};

		var encoded = port.Encode();

		Assert.Equal(expectedByte, encoded);
	}

	[Theory]
	[InlineData(0x31, 1, PrudpStreamType.Secure)]
	[InlineData(0x3f, 15, PrudpStreamType.Secure)]
	public void Decode_FromByte_ReturnsPort(
		byte encoded,
		byte expectedStreamId,
		PrudpStreamType expectedStreamType)
	{
		var port = PrudpPort.Decode(encoded);

		Assert.Equal(expectedStreamId, port.StreamId);
		Assert.Equal(expectedStreamType, port.StreamType);
	}
}
