namespace Redplcs.PrudpProtocol;

public enum PrudpPacketType : byte
{
	Syn = 0,
}

public enum PrudpPacketFlags : byte
{
	None = 0,
	Ack = 1,
	Reliable = 2,
	NeedAck = 4,
	HasSize = 8,
}
