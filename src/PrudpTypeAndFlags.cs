namespace Redplcs.PrudpProtocol;

internal static class PrudpTypeAndFlags
{
	private const byte TypeMask = 0b111;
	private const byte FlagsShiftBy = 3;

	public static (PrudpPacketType type, PrudpPacketFlags flags) Decode(byte b)
	{
		var type = (PrudpPacketType)(b & TypeMask);
		var flags = (PrudpPacketFlags)(b >> FlagsShiftBy);

		return (type, flags);
	}
}
