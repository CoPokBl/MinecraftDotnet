using System.Text;
using Minecraft.Implementations.AnvilWorld;
using Minecraft.Implementations.Storage;
using Minecraft.Schemas.Vec;
using NBT.Tags;

namespace Minecraft.Testing.Implementations.Storage;

/// <summary>
/// Sector allocation, which is the whole of a region file's correctness. A chunk that grows past its
/// old run has to move, and the sectors it left have to become available again without corrupting
/// whatever is allocated next to them.
/// </summary>
public class AnvilRegionFileTest {
    private string _directory = null!;

    [SetUp]
    public void SetUp() {
        _directory = Path.Join(Path.GetTempPath(), "anvil-test-" + Guid.NewGuid().ToString("N")[..12]);
        Directory.CreateDirectory(_directory);
    }

    [TearDown]
    public void TearDown() {
        Directory.Delete(_directory, true);
    }

    private static byte[] Payload(int length, byte fill) {
        byte[] data = new byte[length];
        Array.Fill(data, fill);
        return data;
    }

    [Test]
    public void AChunkComesBackAsItWentIn() {
        string path = Path.Join(_directory, "r.0.0.mca");
        byte[] payload = Payload(9000, 0xAB);

        using (AnvilRegionFile region = new(path, true)) {
            region.WriteChunkBytes(4, 9, payload);
        }

        using (AnvilRegionFile reopened = new(path)) {
            Assert.That(reopened.ReadChunkBytes(4, 9), Is.EqualTo(payload));
            Assert.That(reopened.ReadChunkBytes(5, 9), Is.Null);
        }
    }

    /// <summary>
    /// A chunk rewritten larger than its old run has to move, and the neighbour it used to sit beside
    /// must not move with it.
    /// </summary>
    [Test]
    public void AGrowingChunkMovesWithoutDisturbingItsNeighbour() {
        string path = Path.Join(_directory, "r.0.0.mca");

        // Incompressible, so the sector counts follow the sizes here rather than whatever zlib decides.
        byte[] small = RandomNumberBytes(1000, 1);
        byte[] neighbour = RandomNumberBytes(2000, 2);
        byte[] large = RandomNumberBytes(40000, 3);

        using AnvilRegionFile region = new(path, true);
        region.WriteChunkBytes(0, 0, small);
        region.WriteChunkBytes(1, 0, neighbour);
        region.WriteChunkBytes(0, 0, large);

        Assert.That(region.ReadChunkBytes(0, 0), Is.EqualTo(large));
        Assert.That(region.ReadChunkBytes(1, 0), Is.EqualTo(neighbour));
    }

    /// <summary>The sectors a deleted chunk held are available to the next one that needs them.</summary>
    [Test]
    public void ADeletedChunksSectorsAreReused() {
        string path = Path.Join(_directory, "r.0.0.mca");
        byte[] first = RandomNumberBytes(30000, 4);
        byte[] second = RandomNumberBytes(30000, 5);

        using AnvilRegionFile region = new(path, true);
        region.WriteChunkBytes(0, 0, first);
        long grown = new FileInfo(path).Length;

        region.DeleteChunk(0, 0);
        region.WriteChunkBytes(2, 2, second);

        Assert.That(region.ReadChunkBytes(0, 0), Is.Null);
        Assert.That(region.ReadChunkBytes(2, 2), Is.EqualTo(second));
        Assert.That(new FileInfo(path).Length, Is.EqualTo(grown), "the freed sectors were not reused");
    }

    [Test]
    public void AStoreListsWhatItHolds() {
        Vec2<int>[] positions = [new(0, 0), new(31, 31), new(-1, -1), new(70, -40)];

        using (AnvilRegionBlobStore store = new(_directory)) {
            foreach (Vec2<int> pos in positions) {
                store.Write(pos, Payload(64, (byte)(pos.X & 0xFF)));
            }

            store.Flush();
        }

        using AnvilRegionBlobStore reopened = new(_directory);
        Assert.That(reopened.EnumerateChunks().ToHashSet(), Is.EquivalentTo(positions));

        foreach (Vec2<int> pos in positions) {
            Assert.That(reopened.TryRead(pos, out byte[] data), Is.True, $"{pos} is missing");
            Assert.That(data, Is.EqualTo(Payload(64, (byte)(pos.X & 0xFF))));
        }
    }

    /// <summary>
    /// A restart: the region exists, a chunk load reaches it first, and a save then writes into it. A
    /// region the store kept open from that read has to take the write.
    /// </summary>
    [Test]
    public void AStoreCanSaveIntoARegionItReadFirst() {
        using (AnvilRegionBlobStore first = new(_directory)) {
            first.Write(new Vec2<int>(0, 0), Payload(64, 1));
        }

        using AnvilRegionBlobStore second = new(_directory);
        Assert.That(second.TryRead(new Vec2<int>(0, 0), out _), Is.True);

        second.Write(new Vec2<int>(1, 0), Payload(64, 2));
        Assert.That(second.TryRead(new Vec2<int>(1, 0), out byte[] written), Is.True);
        Assert.That(written, Is.EqualTo(Payload(64, 2)));
    }

    /// <summary>
    /// <c>RegionFile.write</c> allocates the new run while the old one is still in use and frees the old
    /// one only after the header has moved. Rewound to the header from before a rewrite, which is what a
    /// process dying before the header entry is written leaves, the old chunk has to still be there.
    /// </summary>
    [Test]
    public void ARewriteDoesNotOverwriteTheChunkItReplaces() {
        string path = Path.Join(_directory, "r.0.0.mca");
        byte[] before = RandomNumberBytes(1000, 6);
        byte[] after = RandomNumberBytes(1000, 7);
        byte[] header;

        using (AnvilRegionFile region = new(path, true)) {
            region.WriteChunkBytes(0, 0, before);
            header = ReadHeader(path);
            region.WriteChunkBytes(0, 0, after);
            Assert.That(region.ReadChunkBytes(0, 0), Is.EqualTo(after));
        }

        using (FileStream file = new(path, FileMode.Open, FileAccess.Write)) {
            file.Write(header);
        }

        using AnvilRegionFile rewound = new(path);
        Assert.That(rewound.ReadChunkBytes(0, 0), Is.EqualTo(before));
    }

    /// <summary>The run a rewrite moved off is free once it has, so rewriting one chunk does not grow the file forever.</summary>
    [Test]
    public void RewritingAChunkReusesTheRunItLeft() {
        string path = Path.Join(_directory, "r.0.0.mca");

        using AnvilRegionFile region = new(path, true);
        for (int i = 0; i < 10; i++) {
            region.WriteChunkBytes(0, 0, RandomNumberBytes(1000, i));
        }

        // The header, and the two single sector runs the chunk alternates between.
        Assert.That(new FileInfo(path).Length, Is.EqualTo(4 * 4096));
    }

    /// <summary>
    /// A region file cut short, down to nothing at all, is a region with fewer chunks in it rather than
    /// one that cannot be opened, which is how <c>RegionFile</c>'s constructor reads a truncated header.
    /// </summary>
    [TestCase(0)]
    [TestCase(100)]
    [TestCase(5000)]
    public void ATruncatedRegionFileReadsAsEmpty(int length) {
        string path = Path.Join(_directory, "r.0.0.mca");
        File.WriteAllBytes(path, new byte[length]);

        using (AnvilRegionFile region = new(path)) {
            Assert.That(region.EnumerateChunks(), Is.Empty);
            Assert.That(region.ReadChunkBytes(0, 0), Is.Null);
        }

        using AnvilRegionBlobStore store = new(_directory);
        Assert.That(store.TryRead(new Vec2<int>(0, 0), out _), Is.False);

        store.Write(new Vec2<int>(0, 0), Payload(64, 3));
        Assert.That(store.TryRead(new Vec2<int>(0, 0), out byte[] data), Is.True);
        Assert.That(data, Is.EqualTo(Payload(64, 3)));
    }

    /// <summary>
    /// A header entry starting past the end of the file is dropped when the region opens. One starting
    /// exactly at the end is kept, since <c>RegionFile</c> only drops a start strictly past the size,
    /// and reads as a missing chunk.
    /// </summary>
    [Test]
    public void AnEntryPastTheEndOfTheFileIsDropped() {
        string path = Path.Join(_directory, "r.0.0.mca");
        using (AnvilRegionFile region = new(path, true)) {
            region.WriteChunkBytes(0, 0, Payload(64, 4));
            region.WriteChunkBytes(1, 0, Payload(64, 5));
        }

        using (FileStream file = new(path, FileMode.Open, FileAccess.Write)) {
            file.SetLength(2 * 4096);
        }

        using AnvilRegionFile reopened = new(path);
        Assert.That(reopened.EnumerateChunks(), Is.EquivalentTo(new[] { (0, 0) }));
        Assert.That(reopened.ReadChunkBytes(0, 0), Is.Null);
        Assert.That(reopened.ReadChunkBytes(1, 0), Is.Null);
    }

    /// <summary>
    /// A stream claiming more bytes than its run holds is a missing chunk, as
    /// <c>getChunkDataInputStream</c> reads it, rather than a read off the end of the run.
    /// </summary>
    [Test]
    public void AStreamLongerThanItsRunIsAMissingChunk() {
        string path = Path.Join(_directory, "r.0.0.mca");
        using (AnvilRegionFile region = new(path, true)) {
            region.WriteChunkBytes(0, 0, Payload(64, 5));
        }

        using (FileStream file = new(path, FileMode.Open, FileAccess.Write)) {
            file.Seek(2 * 4096, SeekOrigin.Begin);
            file.Write([0x00, 0x01, 0x00, 0x00]);
        }

        using AnvilRegionFile reopened = new(path);
        Assert.That(reopened.ReadChunkBytes(0, 0), Is.Null);
    }

    /// <summary>
    /// A chunk kept in an external <c>.mcc</c> is not damaged, so it must not read as missing: a store in
    /// front of a generator would regenerate it and the next save would write over a chunk vanilla can
    /// read perfectly well.
    /// </summary>
    [Test]
    public void AnExternalChunkIsUnsupportedRatherThanMissing() {
        string path = Path.Join(_directory, "r.0.0.mca");
        using (AnvilRegionFile region = new(path, true)) {
            region.WriteChunkBytes(0, 0, Payload(64, 6));
        }

        using (FileStream file = new(path, FileMode.Open, FileAccess.Write)) {
            file.Seek(2 * 4096 + 4, SeekOrigin.Begin);
            file.WriteByte(0x82);
        }

        using AnvilRegionFile reopened = new(path);
        Assert.Throws<NotSupportedException>(() => reopened.ReadChunkBytes(0, 0));
    }

    [Test]
    public void AReadOnlyStoreRefusesToWrite() {
        using (AnvilRegionBlobStore writer = new(_directory)) {
            writer.Write(new Vec2<int>(0, 0), Payload(64, 7));
        }

        byte[] before = File.ReadAllBytes(Path.Join(_directory, "r.0.0.mca"));

        using (AnvilRegionBlobStore reader = new(_directory, false)) {
            Assert.That(reader.TryRead(new Vec2<int>(0, 0), out _), Is.True);
            Assert.Throws<InvalidOperationException>(() => reader.Write(new Vec2<int>(0, 0), Payload(64, 8)));
            Assert.Throws<InvalidOperationException>(() => reader.Delete(new Vec2<int>(0, 0)));
        }

        Assert.That(File.ReadAllBytes(Path.Join(_directory, "r.0.0.mca")), Is.EqualTo(before));
    }

    /// <summary>
    /// A file's root tag carries a name, which no tag inside one does. Getting this wrong writes a
    /// spare type byte that a reader counts against the length the region file recorded.
    /// </summary>
    [Test]
    public void AnNbtRootRoundTrips() {
        CompoundTag root = new(
            ("Number", new IntegerTag(42)),
            ("Text", new StringTag("hello")),
            ("Nested", new CompoundTag(("Inner", new LongTag(7)))));

        Assert.That(NbtRoot.Parse(NbtRoot.Serialise(root)), Is.EqualTo(root));
    }

    private static byte[] ReadHeader(string path) {
        byte[] header = new byte[2 * 4096];
        using FileStream file = new(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        file.ReadExactly(header);
        return header;
    }

    private static byte[] RandomNumberBytes(int length, int seed) {
        byte[] data = new byte[length];
        new Random(seed).NextBytes(data);
        return data;
    }
}
