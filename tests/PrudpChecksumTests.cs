namespace Redplcs.PrudpProtocol.Tests;

public class PrudpChecksumTests
{
	[Fact]
	public void Calculate_FromHandshakeData_ReturnsExpectedChecksum()
	{
		const byte expectedChecksum = 0x3e;
		var data = new ReadOnlySpan<byte>([0x3f, 0x31, 0x20, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x8, 0x0, 0x0, 0x0]);
		var password = "7fas5"u8;

		var checksum = PrudpChecksum.Calculate(data, password);

		Assert.Equal(expectedChecksum, checksum);
	}
}
