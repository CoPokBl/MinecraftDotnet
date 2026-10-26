using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Shapes;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Physics;

/// <summary>
/// Pins <see cref="BlockInfo.ShapeOffset"/> against vanilla. The expected values came out of
/// <c>BlockState.getOffset</c> run against the 26.2 server jar, the way <c>LpVec3Test</c>'s did:
/// the offset is a hash that overflows an int and divides in float on the way out, so it is exactly
/// the kind of thing a hand derived port gets subtly wrong.
/// </summary>
[TestFixture]
public class BlockShapeOffsetTest {
    private static readonly Vec3<int>[] Positions = [
        new(0, 0, 0), new(1, 0, 0), new(-1, 0, 3), new(7, 64, 13), new(-1000, 0, 1000),
        new(123456, 0, -654321), new(int.MaxValue, 0, int.MinValue), new(31, 0, 31), new(5, 0, -7)
    ];

    /// <summary>Half a block of spread, which is what everything but the dripstones gets.</summary>
    private static readonly Vec3<double>[] BambooOffsets = [
        new(-0.25, 0.0, -0.25),
        new(0.11666667461395264, 0.0, -0.01666666567325592),
        new(0.11666667461395264, 0.0, 0.18333333730697632),
        new(0.18333333730697632, 0.0, 0.18333333730697632),
        new(0.016666680574417114, 0.0, 0.18333333730697632),
        new(-0.18333332985639572, 0.0, -0.0833333283662796),
        new(-0.25, 0.0, -0.14999999850988388),
        new(0.11666667461395264, 0.0, -0.25),
        new(-0.04999999701976776, 0.0, 0.11666667461395264)
    ];

    /// <summary>The same hash clamped to a quarter of a block instead of half.</summary>
    private static readonly Vec3<double>[] DripstoneOffsets = [
        new(-0.125, 0.0, -0.125),
        new(0.11666667461395264, 0.0, -0.01666666567325592),
        new(0.11666667461395264, 0.0, 0.125),
        new(0.125, 0.0, 0.125),
        new(0.016666680574417114, 0.0, 0.125),
        new(-0.125, 0.0, -0.0833333283662796),
        new(-0.125, 0.0, -0.125),
        new(0.11666667461395264, 0.0, -0.125),
        new(-0.04999999701976776, 0.0, 0.11666667461395264)
    ];

    /// <summary>Grass sinks into the ground as well, which is the only place the y term shows up.</summary>
    private static readonly Vec3<double>[] ShortGrassOffsets = [
        new(-0.25, -0.20000000298023224, -0.25),
        new(0.11666667461395264, -0.1333333333333333, -0.01666666567325592),
        new(0.11666667461395264, -0.06666666368643437, 0.18333333730697632),
        new(0.18333333730697632, -0.06666666368643437, 0.18333333730697632),
        new(0.016666680574417114, -0.1333333333333333, 0.18333333730697632),
        new(-0.18333332985639572, -0.14666666607062018, -0.0833333283662796),
        new(-0.25, -0.14666666607062018, -0.14999999850988388),
        new(0.11666667461395264, -0.013333332737286874, -0.25),
        new(-0.04999999701976776, -0.18666666875282922, 0.11666667461395264)
    ];

    [Test]
    public void TestOffsetsMatchVanilla() {
        Assert.Multiple(() => {
            Check(Block.Bamboo.Info, BambooOffsets, "bamboo");
            Check(Block.PointedDripstone.Info, DripstoneOffsets, "pointed dripstone");
            Check(Block.ShortGrass.Info, ShortGrassOffsets, "short grass");
        });
    }

    [Test]
    public void TestBlocksWithoutAnOffsetFunctionStayPut() {
        Assert.Multiple(() => {
            Assert.That(Block.Stone.Info.OffsetType, Is.EqualTo(BlockOffsetType.None));
            foreach (Vec3<int> position in Positions) {
                Assert.That(Block.Stone.Info.ShapeOffset(position), Is.EqualTo(Vec3<double>.Zero));
            }
        });
    }

    /// <summary>
    /// The generated shapes have the offset taken back out of them, so bamboo's is centred on the
    /// block rather than sitting where the origin's hash would put it.
    /// </summary>
    [Test]
    public void TestShapesAreStoredWithoutTheirOffset() {
        Assert.Multiple(() => {
            Assert.That(Block.Bamboo.Info.OffsetType, Is.EqualTo(BlockOffsetType.Xz));
            Assert.That(Block.Bamboo.Info.MaxHorizontalOffset, Is.EqualTo(0.25f));
            // Centred on the block, where the dump would have written it a quarter block off.
            Assert.That(Block.Bamboo.CollisionShape, Is.EqualTo(
                new Aabb(new Vec3<double>(0.40625, 0, 0.40625), new Vec3<double>(0.1875, 1, 0.1875))));
        });
    }

    private static void Check(BlockInfo block, Vec3<double>[] expected, string name) {
        for (int i = 0; i < Positions.Length; i++) {
            Assert.That(block.ShapeOffset(Positions[i]), Is.EqualTo(expected[i]), $"{name} at {Positions[i]}");
        }
    }
}
