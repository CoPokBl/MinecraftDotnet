using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Testing.Schemas;

/// <summary>
/// The heightmaps a chunk puts on the wire.
/// </summary>
/// <remarks>
/// The client stores these without recomputing them, the same way it takes a section's block count,
/// so a wrong one is invisible to a decoder. It decides where rain and snow stop falling and where a
/// particle sits, so the symptom is weather through a roof rather than anything that throws.
/// </remarks>
public class HeightmapTest {
    private const int Height = ChunkData.VanillaOverworldHeight;

    private static ChunkData Chunk() => new(Height);

    private static Heightmaps Compute(ChunkData chunk) {
        return Heightmaps.Compute(chunk, VanillaRegistry.Data);
    }

    /// <summary>Nothing in a column means zero, not the world floor.</summary>
    [Test]
    public void AnEmptyColumnIsZero() {
        Heightmaps maps = Compute(Chunk());

        Assert.Multiple(() => {
            Assert.That(maps.WorldSurface[0], Is.Zero);
            Assert.That(maps.MotionBlocking[0], Is.Zero);
            Assert.That(maps.MotionBlockingNoLeaves[0], Is.Zero);
        });
    }

    /// <summary>
    /// The stored value is <c>getFirstAvailable</c>, one <b>above</b> the highest match, so a single
    /// block sitting on the world floor is 1 rather than 0. Off by one here is off by one for
    /// everything the client places on the surface.
    /// </summary>
    [Test]
    public void TheValueIsOneAboveTheBlock() {
        ChunkData chunk = Chunk();
        chunk.SetBlock(0, 0, 0, Block.Stone.StateId);
        chunk.SetBlock(1, 70, 0, Block.Stone.StateId);

        Heightmaps maps = Compute(chunk);

        Assert.Multiple(() => {
            Assert.That(maps.WorldSurface[0], Is.EqualTo(1));
            Assert.That(maps.WorldSurface[1], Is.EqualTo(71));
        });
    }

    /// <summary>The highest match wins, not the first one found.</summary>
    [Test]
    public void TheHighestBlockWins() {
        ChunkData chunk = Chunk();
        chunk.SetBlock(0, 10, 0, Block.Stone.StateId);
        chunk.SetBlock(0, 90, 0, Block.Stone.StateId);
        chunk.SetBlock(0, 50, 0, Block.Stone.StateId);

        Assert.That(Compute(chunk).WorldSurface[0], Is.EqualTo(91));
    }

    /// <summary>
    /// A torch is not air, so it is a world surface, and it does not block motion, so it is not one
    /// of the other two. Collapsing the two predicates puts rain on top of a torch.
    /// </summary>
    [Test]
    public void ATorchIsSurfaceButNotMotionBlocking() {
        ChunkData chunk = Chunk();
        chunk.SetBlock(0, 64, 0, Block.Stone.StateId);
        chunk.SetBlock(0, 65, 0, Block.Torch.StateId);

        Heightmaps maps = Compute(chunk);

        Assert.Multiple(() => {
            Assert.That(maps.WorldSurface[0], Is.EqualTo(66));
            Assert.That(maps.MotionBlocking[0], Is.EqualTo(65));
            Assert.That(maps.MotionBlockingNoLeaves[0], Is.EqualTo(65));
        });
    }

    /// <summary>Leaves are the whole reason the third map exists.</summary>
    [Test]
    public void LeavesAreExcludedFromTheNoLeavesMap() {
        ChunkData chunk = Chunk();
        chunk.SetBlock(0, 64, 0, Block.Stone.StateId);
        chunk.SetBlock(0, 70, 0, Block.OakLeaves.StateId);

        Heightmaps maps = Compute(chunk);

        Assert.Multiple(() => {
            Assert.That(maps.WorldSurface[0], Is.EqualTo(71));
            Assert.That(maps.MotionBlocking[0], Is.EqualTo(71));
            Assert.That(maps.MotionBlockingNoLeaves[0], Is.EqualTo(65));
        });
    }

    /// <summary>
    /// Water blocks nothing and still counts as motion blocking, because vanilla's predicate is
    /// <c>blocksMotion() || !getFluidState().isEmpty()</c>. Dropping the second half is what would
    /// let rain fall through the surface of an ocean.
    /// </summary>
    [Test]
    public void WaterIsMotionBlockingThroughTheFluidHalf() {
        ChunkData chunk = Chunk();
        chunk.SetBlock(0, 60, 0, Block.Water.StateId);

        Heightmaps maps = Compute(chunk);

        Assert.Multiple(() => {
            Assert.That(maps.MotionBlocking[0], Is.EqualTo(61));
            Assert.That(maps.WorldSurface[0], Is.EqualTo(61));
        });
    }

    /// <summary>
    /// Columns are indexed <c>z * 16 + x</c>. Getting the two round the wrong way is invisible in a
    /// symmetric test world and mirrors the terrain in a real one.
    /// </summary>
    [Test]
    public void ColumnsAreIndexedZTimesSixteenPlusX() {
        ChunkData chunk = Chunk();
        chunk.SetBlock(3, 40, 0, Block.Stone.StateId);
        chunk.SetBlock(0, 80, 3, Block.Stone.StateId);

        Heightmaps maps = Compute(chunk);

        Assert.Multiple(() => {
            Assert.That(maps.WorldSurface[3], Is.EqualTo(41), "x = 3, z = 0");
            Assert.That(maps.WorldSurface[3 * 16], Is.EqualTo(81), "x = 0, z = 3");
        });
    }

    /// <summary>
    /// The uniform section fast path has to reach the same answer as the per block walk, since a
    /// section filled with one state resolves all 256 columns from a single predicate.
    /// </summary>
    [Test]
    public void AFilledSectionMatchesThePerBlockAnswer() {
        ChunkData chunk = Chunk();
        chunk.Sections[3].Fill(Block.Stone.StateId);  // protocol y 48 through 63

        Heightmaps maps = Compute(chunk);

        for (int column = 0; column < Heightmaps.Columns; column++) {
            Assert.That(maps.WorldSurface[column], Is.EqualTo(64), $"column {column}");
        }
    }

    /// <summary>A column full to the roof still fits, which is what the bit width is sized for.</summary>
    [Test]
    public void AColumnFullToTheRoofFits() {
        ChunkData chunk = Chunk();
        chunk.Fill(Block.Stone.StateId);

        Heightmaps maps = Compute(chunk);

        Assert.That(maps.WorldSurface[0], Is.EqualTo(Height));

        // And the width the wire form picks still holds it, which is what the "+ 1" in the bit count
        // is for: the largest answer is the height itself, not the highest position.
        Assert.That(maps.WorldSurface[0], Is.LessThan(1 << Mth.CeilLog2(Height + 1)));
    }

    [Test]
    public void RoundTripsThroughTheWireForm() {
        ChunkData chunk = Chunk();
        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {
                chunk.SetBlock(x, 60 + x + z, z, Block.Stone.StateId);
            }
        }

        Heightmaps written = Compute(chunk);
        DataWriter w = new();
        written.Write(w, Height);

        Heightmaps? read = Heightmaps.Read(new DataReader(w.ToArray()), Height);

        Assert.That(read, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(read!.WorldSurface, Is.EqualTo(written.WorldSurface));
            Assert.That(read.MotionBlocking, Is.EqualTo(written.MotionBlocking));
            Assert.That(read.MotionBlockingNoLeaves, Is.EqualTo(written.MotionBlockingNoLeaves));
        });
    }

    /// <summary>
    /// Exactly the three <c>Types.sendToClient()</c> selects, by their protocol ids. <c>OCEAN_FLOOR</c>
    /// is the one that looks like it belongs and is <c>LIVE_WORLD</c>.
    /// </summary>
    [Test]
    public void SendsThreeMapsByProtocolId() {
        DataWriter w = new();
        Compute(Chunk()).Write(w, Height);
        DataReader r = new(w.ToArray());

        Assert.That(r.ReadVarInt(), Is.EqualTo(3));

        List<int> types = [];
        foreach (int _ in Enumerable.Range(0, 3)) {
            types.Add(r.ReadVarInt());
            r.ReadPrefixedArray(re => re.ReadLong());
        }

        Assert.That(types, Is.EqualTo(new[] { 1, 4, 5 }));
    }

    /// <summary>
    /// Cached on the chunk because a packet is serialised once per recipient, so it has to be dropped
    /// when a block moves or every later reader sees the old surface.
    /// </summary>
    [Test]
    public void AWriteInvalidatesTheCache() {
        ChunkData chunk = Chunk();
        chunk.SetBlock(0, 60, 0, Block.Stone.StateId);

        byte[] before = Serialise(chunk);
        chunk.SetBlock(0, 100, 0, Block.Stone.StateId);
        byte[] after = Serialise(chunk);

        Assert.That(after, Is.Not.EqualTo(before));
    }

    private static byte[] Serialise(ChunkData chunk) {
        DataWriter w = new();
        chunk.Write(w, VanillaRegistry.Data);
        return w.ToArray();
    }
}
