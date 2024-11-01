using System.Numerics;
using System.Runtime.InteropServices;

namespace Redplcs.PrudpProtocol;

internal static class PrudpChecksum
{
	public static byte Calculate(ReadOnlySpan<byte> data, ReadOnlySpan<byte> password)
	{
		var blocks = MemoryMarshal.Cast<byte, uint>(data);
		var blocksSum = Sum(blocks);
		var main = MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(ref blocksSum, length: 1));
		var remaining = data[^blocks.Length..];

		var checksum = Sum(password);
		checksum += Sum(remaining);
		checksum += Sum(main);
		return checksum;
	}

	private static T Sum<T>(ReadOnlySpan<T> data) where T : struct, IAdditionOperators<T, T, T>
	{
		T sum = default;
		foreach (var b in data)
			sum += b;
		return sum;
	}
}
