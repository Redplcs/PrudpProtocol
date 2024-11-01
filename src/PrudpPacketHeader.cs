using System.Buffers;
using System.Numerics;
using System.Runtime.InteropServices;

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

	public static bool TryRead(ref SequenceReader<byte> reader, out PrudpPacketHeader header)
	{
		header = default;

		return
			TryReadPort(ref reader, out header.SourcePort) &&
			TryReadPort(ref reader, out header.DestinationPort) &&
			TryReadTypeAndFlags(ref reader, out header.Type, out header.Flags) &&
			reader.TryRead(out header.SessionId) &&
			TryReadUnsigned(ref reader, out header.Signature) &&
			TryReadUnsigned(ref reader, out header.SequenceId);

		bool TryReadPort(ref SequenceReader<byte> reader, out PrudpPort port)
		{
			var read = reader.TryRead(out var value);
			port = read ? PrudpPort.Decode(value) : default;
			return read;
		}

		bool TryReadTypeAndFlags(ref SequenceReader<byte> reader, out PrudpPacketType type, out PrudpPacketFlags flags)
		{
			var read = reader.TryRead(out var value);
			(type, flags) = read ? PrudpTypeAndFlags.Decode(value) : default;
			return read;
		}

		bool TryReadUnsigned<T>(ref SequenceReader<byte> reader, out T value) where T : struct, IUnsignedNumber<T>
		{
			var read = reader.TryReadExact(count: Marshal.SizeOf<T>(), out var sequence);
			value = read ? MemoryMarshal.Read<T>(sequence.FirstSpan) : default;
			return read;
		}
	}
}
