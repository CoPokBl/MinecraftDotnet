namespace Minecraft.Testing.Implementations.Storage;

/// <summary>
/// Packed entry arrays, at every width a palette can ask for.
/// </summary>
/// <remarks>
/// Entries never straddle a long, so a width that does not divide 64 leaves spare bits at the top of
/// each one and the last long is short. Reading a width back at the wrong stride still produces
/// numbers, which is why this compares values rather than lengths.
/// </remarks>
public class PackedDataArrayTest {
    private static ushort[] Entries(int count, int bits, int seed) {
        Random random = new(seed);
        ushort[] entries = new ushort[count];
        int max = bits >= 16 ? ushort.MaxValue : (1 << bits) - 1;
        for (int i = 0; i < count; i++) {
            entries[i] = (ushort)random.Next(max + 1);
        }

        return entries;
    }

    [Test]
    public void EveryWidthRoundTrips([Range(1, 16)] int bits) {
        ushort[] entries = Entries(4096, bits, bits);

        DataWriter writer = new();
        writer.WritePacketDataArray(bits, entries);

        ushort[] read = new DataReader(writer.ToArray()).ReadPacketDataArray(bits, entries.Length);
        Assert.That(read, Is.EqualTo(entries));
    }

    [Test]
    public void APrefixedArrayRoundTrips([Range(1, 16)] int bits) {
        ushort[] entries = Entries(4096, bits, bits + 100);

        DataWriter writer = new();
        writer.WritePrefixedPacketDataArray(bits, entries);

        ushort[] read = new DataReader(writer.ToArray()).ReadPrefixedPacketDataArray(bits);

        // A prefixed array is sized by the longs it holds, so the tail of the last one comes back as
        // spare entries the caller is expected to ignore.
        Assert.That(read.Length, Is.GreaterThanOrEqualTo(entries.Length));
        Assert.That(read[..entries.Length], Is.EqualTo(entries));
    }

    /// <summary>A count that does not fill its last long still reads back exactly what went in.</summary>
    [Test]
    public void APartialLastLongRoundTrips() {
        foreach (int count in (int[])[1, 7, 63, 65, 100]) {
            ushort[] entries = Entries(count, 5, count);

            DataWriter writer = new();
            writer.WritePacketDataArray(5, entries);

            ushort[] read = new DataReader(writer.ToArray()).ReadPacketDataArray(5, count);
            Assert.That(read, Is.EqualTo(entries), $"{count} entries");
        }
    }
}
