using ManagedServer;
using Minecraft.Placement.Rules;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Items;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Testing.Placement;

/// <summary>
/// What the placement rules have to get right, stated as the things everyone knows the game does: a
/// stair faces away from where you were standing, its half comes from where on the block you clicked,
/// a second slab of the same kind doubles the first, a log lies along the face you hit, and a block
/// put into a water source comes out waterlogged.
/// <p/>
/// These are outcomes rather than a trace. Each one falls out of the context's replace decision, the
/// rule's own arithmetic and the property interfaces agreeing with each other, so a port that gets
/// one of them wrong lands somewhere visible.
/// <p/>
/// Placement is client predicted, so a wrong answer here is not a subtle inaccuracy, it is a block
/// that visibly appears and then changes. That is what
/// <c>Conformance/PlacementHarness.java</c> is for; these cover the cases a person would notice.
/// </summary>
[TestFixture]
public class BlockPlacementTest {
    [Test]
    public void AStairsHalfComesFromWhereOnTheBlockYouClicked() {
        PlacementScene scene = new();
        Vec3<int> floor = scene.Floor(0, 0);

        // Clicking the top of the floor always gives a bottom stair, wherever the cursor was.
        Assert.That(Half(scene.StateFor(Block.OakStairs, floor, BlockFace.PosY)), Is.EqualTo(TopBottom.Bottom));

        // Clicking the underside always gives a top stair.
        Assert.That(Half(scene.StateFor(Block.OakStairs, floor, BlockFace.NegY)), Is.EqualTo(TopBottom.Top));

        // On a side, it is the cursor height that decides, split at the middle of the block.
        Assert.Multiple(() => {
            Assert.That(Half(scene.StateFor(Block.OakStairs, floor, BlockFace.PosX, 0.2)),
                Is.EqualTo(TopBottom.Bottom), "clicked low on the side");
            Assert.That(Half(scene.StateFor(Block.OakStairs, floor, BlockFace.PosX, 0.8)),
                Is.EqualTo(TopBottom.Top), "clicked high on the side");
        });
    }

    [Test]
    public void ALogLiesAlongTheFaceItWasPlacedOn() {
        PlacementScene scene = new();
        Vec3<int> floor = scene.Floor(0, 0);

        Assert.Multiple(() => {
            Assert.That(Axis(scene.StateFor(Block.OakLog, floor, BlockFace.PosY)), Is.EqualTo(Minecraft.Schemas.Blocks.BlockEnums.Axis.Y));
            Assert.That(Axis(scene.StateFor(Block.OakLog, floor, BlockFace.PosX)), Is.EqualTo(Minecraft.Schemas.Blocks.BlockEnums.Axis.X));
            Assert.That(Axis(scene.StateFor(Block.OakLog, floor, BlockFace.NegZ)), Is.EqualTo(Minecraft.Schemas.Blocks.BlockEnums.Axis.Z));
        });
    }

    [Test]
    public void ASecondSlabDoublesTheFirst() {
        PlacementScene scene = new();
        Vec3<int> pos = scene.Above(0, 0);
        scene.Set(pos, ((ISlabTyped)Block.OakSlab).WithType(SlabType.Bottom));

        // Clicking the top of a bottom slab with another of the same kind targets the slab itself
        // rather than the block above it, which is what lets the rule find it and merge.
        Assert.That(scene.PlacePosFor(pos, BlockFace.PosY, Item.OakSlab), Is.EqualTo(pos),
            "the slab should have agreed to be replaced");

        IBlock? placed = scene.StateFor(Block.OakSlab, pos, BlockFace.PosY, 0.5, Item.OakSlab);
        Assert.That(SlabTypeOf(placed), Is.EqualTo(SlabType.Double));
    }

    [Test]
    public void ADifferentSlabDoesNotDoubleAndGoesBeside() {
        PlacementScene scene = new();
        Vec3<int> pos = scene.Above(0, 0);
        scene.Set(pos, ((ISlabTyped)Block.OakSlab).WithType(SlabType.Bottom));

        // A spruce slab is a different block, so the oak slab refuses to be replaced and the new one
        // goes above it as a bottom slab of its own.
        Assert.That(scene.PlacePosFor(pos, BlockFace.PosY, Item.SpruceSlab), Is.EqualTo(pos.WithY(pos.Y + 1)));

        IBlock? placed = scene.StateFor(Block.SpruceSlab, pos, BlockFace.PosY, 0.5, Item.SpruceSlab);
        Assert.That(SlabTypeOf(placed), Is.EqualTo(SlabType.Bottom));
    }

    [Test]
    public void ASlabPlacedIntoWaterIsWaterloggedAndDoublingClearsIt() {
        PlacementScene scene = new();
        Vec3<int> pos = scene.Above(0, 0);
        scene.Set(pos, Block.Water);

        IBlock? single = scene.StateFor(Block.OakSlab, pos, BlockFace.PosY, 0.5, Item.OakSlab);
        Assert.That(single, Is.InstanceOf<IWaterlogged>());
        Assert.That(((IWaterlogged)single!).Waterlogged, Is.True, "placed into a water source");

        // A double slab is full, so there is nowhere for the water to be.
        scene.Set(pos, single);
        IBlock? doubled = scene.StateFor(Block.OakSlab, pos, BlockFace.PosY, 0.5, Item.OakSlab);
        Assert.Multiple(() => {
            Assert.That(SlabTypeOf(doubled), Is.EqualTo(SlabType.Double));
            Assert.That(((IWaterlogged)doubled!).Waterlogged, Is.False);
        });
    }

    [Test]
    public void ALightBlockDoesNotWaterlogOnPlacement() {
        PlacementScene scene = new();
        Vec3<int> pos = scene.Above(0, 0);
        scene.Set(pos, Block.Water);

        // One of the two blocks in the game that has a waterlogged property and does not set it when
        // placed, because LightBlock never overrides getStateForPlacement. A blanket "waterlog
        // anything that can be" rule would get this wrong, which is why there is not one.
        IBlock? placed = scene.StateFor(Block.Light, pos, BlockFace.PosY);
        Assert.That(((IWaterlogged)placed!).Waterlogged, Is.False);
    }

    [Test]
    public void TwoStairsFacingAcrossEachOtherFormACorner() {
        PlacementScene scene = new();
        Vec3<int> pos = scene.Above(0, 0);
        Vec3<int> east = scene.Above(1, 0);

        // A stair facing east, with a stair facing north in front of it, turns an inner corner.
        IBlock facingEast = ((IHorizontalFacing)Block.OakStairs).WithFacing(Direction.East);
        IBlock facingNorth = ((IHorizontalFacing)Block.OakStairs).WithFacing(Direction.North);
        scene.Set(east, facingNorth);
        scene.Set(pos, facingEast);

        IBlockPlacementRule rule = scene.Rules.For(Block.OakStairs, scene.World)!;
        IBlock settled = rule.UpdateShape(facingEast, scene.World, pos, BlockFace.PosX, east, facingNorth);

        Assert.That(((IStairShaped)settled).Shape, Is.Not.EqualTo(StairShape.Straight),
            "a stair across the one in front should corner");
    }

    [Test]
    public void AStairWithNothingAroundItIsStraight() {
        PlacementScene scene = new();
        Vec3<int> pos = scene.Above(0, 0);

        Assert.That(Shape(scene.StateFor(Block.OakStairs, scene.Floor(0, 0), BlockFace.PosY)),
            Is.EqualTo(StairShape.Straight));
    }

    [Test]
    public void ABlockWithNoRulePlacesItsDefaultState() {
        PlacementScene scene = new();

        // Stone has no getStateForPlacement upstream either, so the default state is the right answer
        // rather than a gap.
        Assert.That(scene.Rules.For(Block.Stone, scene.World), Is.Null);
        Assert.That(scene.StateFor(Block.Stone, scene.Floor(0, 0), BlockFace.PosY), Is.EqualTo(Block.Stone));
    }

    [Test]
    public void RulesResolveThroughTheVanillaClassChain() {
        PlacementScene scene = new();

        // One StairBlock rule covers every stair, including the copper ones that weather, because
        // resolution walks the block's Java superclass chain rather than matching an identifier.
        Assert.Multiple(() => {
            Assert.That(scene.Rules.For(Block.OakStairs, scene.World), Is.InstanceOf<StairPlacementRule>());
            Assert.That(scene.Rules.For(Block.CutCopperStairs, scene.World), Is.InstanceOf<StairPlacementRule>());
            Assert.That(scene.Rules.For(Block.OxidizedCutCopperStairs, scene.World), Is.InstanceOf<StairPlacementRule>());
        });
    }

    private static TopBottom? Half(IBlock? block) => (block as IHalved)?.Half;

    private static Axis? Axis(IBlock? block) => (block as IAxisAligned)?.Axis;

    private static SlabType? SlabTypeOf(IBlock? block) => (block as ISlabTyped)?.Type;

    private static StairShape? Shape(IBlock? block) => (block as IStairShaped)?.Shape;

    /// <summary>
    /// A slab is only doubled from the side it has room on. Clicking the exposed side of one puts a
    /// new slab beside it, which is what a player expects and what the game does.
    /// <p/>
    /// This is the test for vanilla's <c>replaceClicked</c> starting <b>true</b>. The constructor asks
    /// the slab whether it can be replaced, and because the field already reads true the slab takes
    /// its geometric branch and answers no. Start the field false instead and it takes the plain
    /// "yes" at the bottom of the method, every side click doubles, and nothing else in the suite
    /// notices.
    /// </summary>
    [Test]
    public void ASlabClickedOnItsSideIsPlacedBesideIt() {
        PlacementScene scene = new();
        Vec3<int> pos = scene.Above(0, 0);

        // A bottom slab fills the lower half, so a click on its side lands below the middle.
        scene.Set(pos, ((ISlabTyped)Block.OakSlab).WithType(SlabType.Bottom));
        Assert.Multiple(() => {
            Assert.That(scene.PlacePosFor(pos, BlockFace.NegX, Item.OakSlab, 0.25),
                Is.EqualTo(pos.GetBlockTowards(BlockFace.NegX)), "bottom slab, clicked on the side");
            Assert.That(scene.PlacePosFor(pos, BlockFace.NegY, Item.OakSlab),
                Is.EqualTo(pos.GetBlockTowards(BlockFace.NegY)), "bottom slab, clicked underneath");
        });

        // A top slab fills the upper half, so a click on its side lands above the middle. The two
        // branches are mirror images and both have to be the right way round.
        scene.Set(pos, ((ISlabTyped)Block.OakSlab).WithType(SlabType.Top));
        Assert.Multiple(() => {
            Assert.That(scene.PlacePosFor(pos, BlockFace.NegX, Item.OakSlab, 0.75),
                Is.EqualTo(pos.GetBlockTowards(BlockFace.NegX)), "top slab, clicked on the side");
            Assert.That(scene.PlacePosFor(pos, BlockFace.NegY, Item.OakSlab),
                Is.EqualTo(pos), "top slab, clicked underneath, doubles");
        });
    }

    /// <summary>
    /// The same field, through the other block that reads it. Snow adds a layer when clicked on top
    /// and is placed beside when clicked on the side.
    /// </summary>
    [Test]
    public void SnowClickedOnItsSideIsPlacedBesideIt() {
        PlacementScene scene = new();
        Vec3<int> pos = scene.Above(0, 0);
        scene.Set(pos, Block.Snow);

        Assert.Multiple(() => {
            Assert.That(scene.PlacePosFor(pos, BlockFace.PosY, Item.Snow), Is.EqualTo(pos),
                "clicked on top, adds a layer");
            Assert.That(scene.PlacePosFor(pos, BlockFace.NegX, Item.Snow),
                Is.EqualTo(pos.GetBlockTowards(BlockFace.NegX)), "clicked on the side");
        });
    }

    /// <summary>
    /// A ladder needs a whole face behind it, so it goes on stone and not on the side of a slab.
    /// <p/>
    /// The rule reads <c>isFaceSturdy</c>, which used to be "blocks motion and occludes". A slab
    /// answers yes to both, so every ladder, button, lever and torch would attach to one.
    /// </summary>
    [Test]
    public void ALadderNeedsAWholeFaceBehindIt() {
        PlacementScene scene = new();
        Vec3<int> support = scene.Above(0, 0);
        Vec3<int> ladderPos = scene.Above(1, 0);
        IBlock ladder = ((IHorizontalFacing)Block.Ladder).WithFacing(Direction.East);
        LadderPlacementRule rule = new();

        scene.Set(support, Block.Stone);
        Assert.That(rule.CanSurvive(ladder, scene.World, ladderPos), Is.True, "against stone");

        scene.Set(support, ((ISlabTyped)Block.OakSlab).WithType(SlabType.Bottom));
        Assert.That(rule.CanSurvive(ladder, scene.World, ladderPos), Is.False, "against a slab");
    }
}
