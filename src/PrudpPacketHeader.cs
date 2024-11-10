namespace Redplcs.PrudpProtocol;

internal struct PrudpPacketHeader
{
	public PrudpPort SourcePort;
	public PrudpPort DestinationPort;
	public PrudpPacketType Type;
	public PrudpPacketFlags Flags;
	public byte SessionId;
	public uint Signature;
	public ushort SequenceId;
	public uint ConnectionSignature;
	public byte FragmentId;
	public ushort PayloadSize;
}
