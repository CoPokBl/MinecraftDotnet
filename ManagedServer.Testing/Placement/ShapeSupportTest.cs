using ManagedServer.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace ManagedServer.Testing.Placement;

/// <summary>
/// <c>BlockState.isFaceSturdy</c>, the question behind every block that attaches to a surface.
/// <p/>
/// Each case here is one a bounding box test gets wrong, which is what this replaced. They fall into
/// three groups: a shape that does not reach the boundary it is asked about, a support shape that
/// deliberately disagrees with the collision shape, and a support type that is not the full face.
/// </summary>
[TestFixture]
public class ShapeSupportTest {
    private static IBlock Slab(SlabType type) => ((ISlabTyped)Block.OakSlab).WithType(type);

    /// <summary>
    /// The slice is taken at the block boundary, not at the top of the shape. A bottom slab fills
    /// the lower half of its cube, so its down face is whole and its up face is empty: a ladder does
    /// not go on its side and nothing stands on top of it, which is the same rule that stops
    /// redstone running over one.
    /// </summary>
    [Test]
    public void ASlabIsSturdyOnlyOnTheSideItFills() {
        IBlock bottom = Slab(SlabType.Bottom);
        IBlock top = Slab(SlabType.Top);

        Assert.Multiple(() => {
            Assert.That(ShapeSupport.IsFaceSturdy(bottom, BlockFace.NegY), Is.True, "bottom slab, underside");
            Assert.That(ShapeSupport.IsFaceSturdy(bottom, BlockFace.PosY), Is.False, "bottom slab, top");
            Assert.That(ShapeSupport.IsFaceSturdy(bottom, BlockFace.NegX), Is.False, "bottom slab, side");

            Assert.That(ShapeSupport.IsFaceSturdy(top, BlockFace.PosY), Is.True, "top slab, top");
            Assert.That(ShapeSupport.IsFaceSturdy(top, BlockFace.NegY), Is.False, "top slab, underside");
            Assert.That(ShapeSupport.IsFaceSturdy(top, BlockFace.NegX), Is.False, "top slab, side");

            Assert.That(ShapeSupport.IsFaceSturdy(Slab(SlabType.Double), BlockFace.NegX), Is.True,
                "a double slab is a whole cube");
        });
    }

    /// <summary>
    /// The support shape is not the collision shape, and the two disagree in both directions.
    /// Leaves collide as a full cube and support nothing; soul sand and mud collide an eighth short
    /// and support as full cubes, which is why a torch stands on soul sand.
    /// </summary>
    [Test]
    public void TheSupportShapeIsNotTheCollisionShape() {
        Assert.Multiple(() => {
            Assert.That(ShapeSupport.IsFaceSturdy(Block.OakLeaves, BlockFace.PosY), Is.False, "leaves");
            Assert.That(ShapeSupport.IsShapeFullBlock(Block.OakLeaves.CollisionShape), Is.True,
                "leaves still collide as a whole cube");

            Assert.That(ShapeSupport.IsFaceSturdy(Block.SoulSand, BlockFace.PosY), Is.True, "soul sand");
            Assert.That(ShapeSupport.IsShapeFullBlock(Block.SoulSand.CollisionShape), Is.False,
                "soul sand still collides short");

            Assert.That(ShapeSupport.IsFaceSturdy(Block.Mud, BlockFace.PosY), Is.True, "mud");
        });
    }

    /// <summary>
    /// The three support types are different questions, not degrees of one. A fence post presents no
    /// whole face and still holds a torch, because a torch asks for the centre column.
    /// </summary>
    [Test]
    public void TheSupportTypesAskDifferentQuestions() {
        Assert.Multiple(() => {
            Assert.That(ShapeSupport.IsFaceSturdy(Block.OakFence, BlockFace.PosY, SupportType.Full),
                Is.False, "a fence post has no whole face");
            Assert.That(ShapeSupport.IsFaceSturdy(Block.OakFence, BlockFace.PosY, SupportType.Center),
                Is.True, "and still holds a torch");
            Assert.That(ShapeSupport.IsFaceSturdy(Block.OakFence, BlockFace.PosY, SupportType.Rigid),
                Is.False, "but not a pressure plate");

            // A whole cube answers yes to all three, which is what makes the middle ground the only
            // interesting part.
            foreach (SupportType type in Enum.GetValues<SupportType>()) {
                Assert.That(ShapeSupport.IsFaceSturdy(Block.Stone, BlockFace.PosY, type), Is.True,
                    $"stone, {type}");
            }
        });
    }

    /// <summary>
    /// Air supports nothing, and an empty region is contained in anything. The second is what makes
    /// the containment test total rather than a special case at every call site.
    /// </summary>
    [Test]
    public void EmptyShapesBehave() {
        Assert.Multiple(() => {
            foreach (BlockFace face in Enum.GetValues<BlockFace>()) {
                Assert.That(ShapeSupport.IsFaceSturdy(Block.Air, face), Is.False, $"air, {face}");
            }

            Assert.That(ShapeSupport.Contains([], []), Is.True, "nothing covers nothing");
            Assert.That(ShapeSupport.Contains([], ShapeSupport.FullCube), Is.False, "nothing covers a cube");
        });
    }
}
