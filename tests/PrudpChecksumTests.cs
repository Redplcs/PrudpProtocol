namespace Redplcs.PrudpProtocol.Tests;

public class PrudpChecksumTests
{
	[Fact]
	public void Calculate_FromBytes_ReturnsChecksum()
	{
		const byte expectedChecksum = 0x3e;
		var data = Data.InitialHandshakeWithoutChecksum;
		var password = "7fas5"u8;

		var checksum = PrudpChecksum.Calculate(data.AsSpan(), password);

		Assert.Equal(expectedChecksum, checksum);
	}
}
