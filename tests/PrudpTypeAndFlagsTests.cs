namespace Redplcs.PrudpProtocol.Tests;

public class PrudpTypeAndFlagsTests
{
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
