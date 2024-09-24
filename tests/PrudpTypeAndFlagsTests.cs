namespace Redplcs.PrudpProtocol.Tests;

public class PrudpTypeAndFlagsTests
{
	[Theory]
	[InlineData(PrudpPacketType.Syn, PrudpPacketFlags.NeedAck, 0x20)]
	public void Encode_FromTypeAndFlags_ReturnsExpectedEncodedByte(
		PrudpPacketType type,
		PrudpPacketFlags flags,
		byte expectedEncodedByte)
	{
		var encodedByte = PrudpTypeAndFlags.Encode(type, flags);

		Assert.Equal(expectedEncodedByte, encodedByte);
	}

	[Theory]
	[InlineData(0x20, PrudpPacketType.Syn, PrudpPacketFlags.NeedAck)]
	public void Decode_FromEncoded_ReturnsExpectedTypeAndFlags(
		byte encoded,
		PrudpPacketType expectedType,
		PrudpPacketFlags expectedFlags)
	{
		var (type, flags) = PrudpTypeAndFlags.Decode(encoded);

		Assert.Equal(expectedType, type);
		Assert.Equal(expectedFlags, flags);
	}
}
