namespace Redplcs.PrudpProtocol;

internal static class PrudpTypeAndFlags
{
	private const byte TypeMask = 0b111;
	private const byte FlagsShiftBy = 3;

	public static byte Encode(PrudpPacketType type, PrudpPacketFlags flags)
	{
		var typeMasked = (int)type & TypeMask;
		var flagsInt = (int)flags;

		return (byte)(flagsInt << FlagsShiftBy | typeMasked);
	}

	public static (PrudpPacketType type, PrudpPacketFlags flags) Decode(byte b)
	{
		var type = (PrudpPacketType)(b & TypeMask);
		var flags = (PrudpPacketFlags)(b >> FlagsShiftBy);

		return (type, flags);
	}
}
