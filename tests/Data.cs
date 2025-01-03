﻿using System.Collections.Immutable;

namespace Redplcs.PrudpProtocol.Tests;

internal static class Data
{
	public static readonly ImmutableArray<byte> InitialHandshake = [0x3f, 0x31, 0x20, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x8, 0x0, 0x0, 0x0, 0x3e];
	public static readonly ImmutableArray<byte> InitialHandshakeWithoutChecksum = [0x3f, 0x31, 0x20, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x8, 0x0, 0x0, 0x0];
}
