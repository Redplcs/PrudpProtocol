namespace Redplcs.PrudpProtocol;

internal record struct PrudpPort
{
	private const byte StreamIdMask = 0xF;
	private const byte StreamTypeShiftBy = 0x4;

	public byte StreamId;
	public PrudpStreamType StreamType;

	public readonly byte Encode()
	{
		var streamIdMasked = StreamId & StreamIdMask;
		var streamTypeInt = (int)StreamType;

		// Shifting applies to integer, so casting streamTypeInt to byte adds excess casting to int.
		return (byte)((streamTypeInt << StreamTypeShiftBy) | streamIdMasked);
	}

	public static PrudpPort Decode(byte b)
	{
		return new PrudpPort
		{
			StreamId = (byte)(b & StreamIdMask),
			StreamType = (PrudpStreamType)(b >> StreamTypeShiftBy)
		};
	}
}
