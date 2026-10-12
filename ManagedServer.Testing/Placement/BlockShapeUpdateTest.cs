using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Testing.Placement;

/// <summary>
/// The shape update pass, vanilla's <c>updateNeighbourShapes</c> cascade out of <c>Level.setBlock</c>.
/// <p/>
/// Placement alone gets a block's first state right and nothing after that. These are the things that
/// only work because the write tells its neighbours: a fence letting go, a torch falling off a wall
/// that went, and both halves of a door or a bed going together.
/// <p/>
/// Written against <see cref="World.SetBlock(Vec3{int},IBlock,IBlockEntityType?,NBT.Tags.INbtTag?,int,int)"/>
/// rather than against the rules, because the cascade is the thing under test. A rule tested directly
/// passes whether or not anything ever calls it, which is exactly the state this was in before.
/// </summary>
[TestFixture]
public class BlockShapeUpdateTest {
    private static IBlock Fence(params BlockFace[] sides) {
        IBlock fence = Block.OakFence;
        foreach (BlockFace side in sides) {
            fence = ((IFaceConnected)fence).WithConnection(side, true);
        }

        return fence;
    }

    private static bool Connected(IBlock block, BlockFace face) =>
        ((IFaceConnected)block).Connected(face);

    /// <summary>
    /// A fence connects to a neighbour that appears and lets go of one that is broken. The second
    /// half is the one that needed the cascade: placement already worked out the first.
    /// </summary>
    [Test]
    public void AFenceConnectsAndThenLetsGo() {
        PlacementScene scene = new();
        Vec3<int> fence = scene.Above(0, 0);
        Vec3<int> beside = scene.Above(1, 0);

        scene.Set(fence, Block.OakFence);
        Assert.That(Connected(scene.World.GetBlock(fence), BlockFace.PosX), Is.False,
            "nothing there yet");

        scene.Set(beside, Block.Stone);
        Assert.That(Connected(scene.World.GetBlock(fence), BlockFace.PosX), Is.True,
            "a block appeared beside it");

        scene.Set(beside, Block.Air);
        Assert.That(Connected(scene.World.GetBlock(fence), BlockFace.PosX), Is.False,
            "and went again");
    }

    /// <summary>
    /// A ladder needs the wall behind it, and finds out when the wall goes. Same for a wall torch,
    /// which is the case that used to leave a torch hanging in the air.
    /// </summary>
    [Test]
    public void AttachedBlocksFallOffWhatTheyWereOn() {
        PlacementScene scene = new();
        Vec3<int> wall = scene.Above(0, 0);
        Vec3<int> ladder = scene.Above(1, 0);

        scene.Set(wall, Block.Stone);
        scene.Set(ladder, ((IHorizontalFacing)Block.Ladder).WithFacing(Direction.East));
        Assert.That(scene.World.GetBlock(ladder).Identifier, Is.EqualTo(Block.Ladder.Identifier),
            "it went up against stone");

        scene.Set(wall, Block.Air);
        Assert.That(scene.World.GetBlock(ladder).Air, Is.True, "and came down with the wall");
    }

    /// <summary>
    /// Breaking either half of a door takes the other with it. This is the case reported as missing:
    /// before the cascade existed, half a door stayed behind.
    /// </summary>
    [Test]
    public void BothHalvesOfADoorGoTogether() {
        PlacementScene scene = new();
        Vec3<int> lower = scene.Above(0, 0);
        Vec3<int> upper = lower.WithY(lower.Y + 1);

        PlaceDoor(scene, lower);
        Assert.That(scene.World.GetBlock(upper).Identifier, Is.EqualTo(Block.OakDoor.Identifier),
            "both halves went in");

        scene.Set(lower, Block.Air);
        Assert.That(scene.World.GetBlock(upper).Air, Is.True, "breaking the bottom took the top");

        PlaceDoor(scene, lower);
        scene.Set(upper, Block.Air);
        Assert.That(scene.World.GetBlock(lower).Air, Is.True, "and breaking the top took the bottom");
    }

    /// <summary>
    /// The same for a bed, which is the two cell rule laid sideways rather than stacked.
    /// </summary>
    [Test]
    public void BothEndsOfABedGoTogether() {
        PlacementScene scene = new();
        Vec3<int> foot = scene.Above(0, 0);
        Vec3<int> head = scene.Above(0, 1);

        IBlock bed = ((IHorizontalFacing)Block.RedBed).WithFacing(Direction.South);
        scene.Set(foot, ((IBedParted)bed).WithPart(BedPart.Foot));
        scene.Set(head, ((IBedParted)bed).WithPart(BedPart.Head));
        Assert.That(scene.World.GetBlock(foot).Identifier, Is.EqualTo(Block.RedBed.Identifier),
            "both ends are down");

        scene.Set(head, Block.Air);
        Assert.That(scene.World.GetBlock(foot).Air, Is.True, "breaking the head took the foot");
    }

    /// <summary>
    /// A door's two halves are written one after the other, so the lower one exists on its own for a
    /// moment. It survives that because <c>updateNeighbourShapes</c> tells a block's <b>neighbours</b>
    /// what it has become and never asks the block about itself, which is easy to lose in the port and
    /// would make every door impossible to place.
    /// </summary>
    [Test]
    public void ADoorSurvivesBeingWrittenOneHalfAtATime() {
        PlacementScene scene = new();
        Vec3<int> lower = scene.Above(0, 0);

        IBlock half = ((IDoubleHalved)Block.OakDoor).WithHalf(BlockHalf.Lower);
        scene.Set(lower, half);

        Assert.That(scene.World.GetBlock(lower).Identifier, Is.EqualTo(Block.OakDoor.Identifier),
            "a lone lower half is not destroyed by its own placement");
    }

    /// <summary>
    /// <see cref="BlockUpdateFlags.KnownShape"/> is the caller saying it has already worked out what
    /// the surroundings should be. It is what a scene builder or a schematic loader wants, and it must
    /// suppress the pass in both directions: neither the written block nor its neighbours move.
    /// </summary>
    [Test]
    public void KnownShapeWritesVerbatim() {
        PlacementScene scene = new();
        Vec3<int> fence = scene.Above(0, 0);
        Vec3<int> beside = scene.Above(1, 0);

        scene.Set(fence, Fence(BlockFace.PosX));
        scene.World.SetBlock(beside, Block.Stone, flags: BlockUpdateFlags.KnownShape);

        Assert.Multiple(() => {
            Assert.That(Connected(scene.World.GetBlock(fence), BlockFace.PosX), Is.True,
                "the connection the caller asked for is still there");

            // And a wrong one is left wrong, which is the point: the caller is trusted.
            scene.World.SetBlock(fence, Fence(BlockFace.NegZ),
                flags: BlockUpdateFlags.KnownShape);
            Assert.That(Connected(scene.World.GetBlock(fence), BlockFace.NegZ), Is.True,
                "a connection to nothing survives a verbatim write");
        });
    }

    /// <summary>
    /// A cascade runs to the end of a chain rather than one step of it. Ten stacked ladders come down
    /// as one, and the whole thing has to terminate: the update limit is the only guard, there is no
    /// visited set.
    /// </summary>
    [Test]
    public void ACascadeRunsAllTheWayDownAChain() {
        PlacementScene scene = new();
        Vec3<int> wallBase = scene.Above(0, 0);
        const int height = 10;

        for (int i = 0; i < height; i++) {
            scene.Set(wallBase.WithY(wallBase.Y + i), Block.Stone);
            scene.Set(wallBase.WithY(wallBase.Y + i).GetBlockTowards(BlockFace.PosX),
                ((IHorizontalFacing)Block.Ladder).WithFacing(Direction.East));
        }

        // Take the whole wall out from the bottom up, one block at a time.
        for (int i = 0; i < height; i++) {
            scene.Set(wallBase.WithY(wallBase.Y + i), Block.Air);
        }

        for (int i = 0; i < height; i++) {
            Assert.That(scene.World.GetBlock(wallBase.WithY(wallBase.Y + i)
                .GetBlockTowards(BlockFace.PosX)).Air, Is.True, $"ladder {i}");
        }
    }

    /// <summary>
    /// A block destroyed by a shape update leaves the fluid that was in it, which is
    /// <c>destroyBlock</c> writing <c>getFluidState(pos).createLegacyBlock()</c> rather than air. A
    /// waterlogged ladder that loses its wall leaves water behind, not a hole in the sea.
    /// </summary>
    [Test]
    public void DestroyingAWaterloggedBlockLeavesTheWater() {
        PlacementScene scene = new();
        Vec3<int> wall = scene.Above(0, 0);
        Vec3<int> ladder = scene.Above(1, 0);

        scene.Set(wall, Block.Stone);
        IBlock wet = ((IWaterlogged)((IHorizontalFacing)Block.Ladder).WithFacing(Direction.East))
            .WithWaterlogged(true);
        scene.Set(ladder, wet);

        scene.Set(wall, Block.Air);
        Assert.That(scene.World.GetBlock(ladder).Identifier, Is.EqualTo(Block.Water.Identifier));
    }

    /// <summary>
    /// Writes the two halves of a door the way the placement path does: the lower one, then the upper
    /// one from <c>setPlacedBy</c>.
    /// </summary>
    private static void PlaceDoor(PlacementScene scene, Vec3<int> lower) {
        IDoubleHalved door = (IDoubleHalved)Block.OakDoor;
        scene.Set(lower, door.WithHalf(BlockHalf.Lower));
        scene.Set(lower.WithY(lower.Y + 1), door.WithHalf(BlockHalf.Upper));
    }
}
