namespace Redplcs.PrudpProtocol;

internal record struct PrudpPort
{
	public byte StreamId;
	public PrudpStreamType StreamType;

	public static PrudpPort Decode(byte b)
	{
		const byte streamIdMask = 0xF;
		const byte streamTypeShiftBy = 0x4;

		return new PrudpPort
		{
			StreamId = (byte)(b & streamIdMask),
			StreamType = (PrudpStreamType)(b >> streamTypeShiftBy)
		};
	}
}
