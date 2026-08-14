using ManagedServer.Placement.Helpers;
using ManagedServer.Placement.Rules;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Placement;

/// <summary>
/// <c>canSurvive</c>, the half of placement that says no.
/// <p/>
/// A rule with no survival check does not look broken, it looks permissive: the block goes down, the
/// client draws it, and it stays there. So each case here is one where the answer has to be no, and
/// is paired with the nearest case where it has to be yes, because a rule that refuses everything
/// passes a test that only checks refusals.
/// <p/>
/// What separates the pairs is which question the block asks. Three of them ask for a different
/// support type, two ask for a tag, two ask plain <c>isSolid</c>, and one asks about the collision
/// shape rather than the support shape. Getting the question wrong rather than the answer is the
/// failure these are shaped around.
/// </summary>
[TestFixture]
public class PlacementSurvivalTest {
    private static IBlock Slab(SlabType type) => ((ISlabTyped)Block.OakSlab).WithType(type);

    /// <summary>
    /// A repeater and a rail ask for <c>RIGID</c>, the outer frame of the up face. A fence post is
    /// the case that separates it from <c>CENTER</c>: it holds a torch and not a repeater.
    /// </summary>
    [Test]
    public void ARepeaterAndARailWantTheOuterFrame() {
        PlacementScene scene = new();
        Vec3<int> below = scene.Above(0, 0);
        Vec3<int> on = below.WithY(below.Y + 1);
        DiodePlacementRule repeater = new();
        BaseRailPlacementRule rail = new();

        scene.Set(below, Block.Stone);
        Assert.Multiple(() => {
            Assert.That(repeater.CanSurvive(Block.Repeater, scene.World, on), Is.True, "repeater on stone");
            Assert.That(rail.CanSurvive(Block.Rail, scene.World, on), Is.True, "rail on stone");
        });

        scene.Set(below, Block.OakFence);
        Assert.Multiple(() => {
            Assert.That(repeater.CanSurvive(Block.Repeater, scene.World, on), Is.False, "repeater on a fence");
            Assert.That(rail.CanSurvive(Block.Rail, scene.World, on), Is.False, "rail on a fence");
            Assert.That(PlacementHelpers.SupportsCenter(scene.World, below, BlockFace.PosY), Is.True,
                "and the same fence still holds a torch");
        });
    }

    /// <summary>
    /// A candle asks for <c>CENTER</c>, so it stands on a fence post and not on the underside of
    /// anything. It has no shape update to match, so this is only about placement.
    /// </summary>
    [Test]
    public void ACandleWantsTheCentreColumn() {
        PlacementScene scene = new();
        Vec3<int> below = scene.Above(0, 0);
        Vec3<int> on = below.WithY(below.Y + 1);
        CandlePlacementRule rule = new();

        scene.Set(below, Block.OakFence);
        Assert.That(rule.CanSurvive(Block.Candle, scene.World, on), Is.True, "on a fence post");

        scene.Set(below, Block.Air);
        Assert.That(rule.CanSurvive(Block.Candle, scene.World, on), Is.False, "on nothing");
    }

    /// <summary>
    /// A standing sign and a banner use plain <c>isSolid()</c>, not a face test. A bottom slab is
    /// solid, so a sign stands on one even though nothing attaches to its up face, and that gap
    /// between the two tests is the whole point of the rule being written this way.
    /// </summary>
    [Test]
    public void ASignStandsOnAnythingSolid() {
        PlacementScene scene = new();
        Vec3<int> below = scene.Above(0, 0);
        Vec3<int> on = below.WithY(below.Y + 1);
        StandingSignPlacementRule sign = new();
        BannerPlacementRule banner = new();

        scene.Set(below, Slab(SlabType.Bottom));
        Assert.Multiple(() => {
            Assert.That(sign.CanSurvive(Block.OakSign, scene.World, on), Is.True, "sign on a bottom slab");
            Assert.That(banner.CanSurvive(Block.WhiteBanner, scene.World, on), Is.True, "banner too");
            Assert.That(ShapeSupport.IsFaceSturdy(Slab(SlabType.Bottom), BlockFace.PosY), Is.False,
                "though its up face is empty");
        });

        scene.Set(below, Block.Torch);
        Assert.Multiple(() => {
            Assert.That(sign.CanSurvive(Block.OakSign, scene.World, on), Is.False, "not on a torch");
            Assert.That(banner.CanSurvive(Block.WhiteBanner, scene.World, on), Is.False, "banner neither");
        });
    }

    /// <summary>
    /// A flower bed and a tall plant both ask for the <c>supports_vegetation</c> tag, which is about
    /// what the block <b>is</b> rather than what shape it has. Stone is as solid as dirt and holds
    /// neither.
    /// </summary>
    [Test]
    public void PlantsWantSoilRatherThanASolidFace() {
        PlacementScene scene = new();
        Vec3<int> below = scene.Above(0, 0);
        Vec3<int> on = below.WithY(below.Y + 1);
        FlowerBedPlacementRule petals = new();
        DoublePlantPlacementRule tall = new();

        scene.Set(below, Block.GrassBlock);
        Assert.Multiple(() => {
            Assert.That(petals.CanSurvive(Block.PinkPetals, scene.World, on), Is.True, "petals on grass");
            Assert.That(tall.CanSurvive(Block.Sunflower, scene.World, on), Is.True, "a sunflower on grass");
        });

        scene.Set(below, Block.Stone);
        Assert.Multiple(() => {
            Assert.That(petals.CanSurvive(Block.PinkPetals, scene.World, on), Is.False, "petals on stone");
            Assert.That(tall.CanSurvive(Block.Sunflower, scene.World, on), Is.False, "a sunflower on stone");
        });
    }

    /// <summary>
    /// Leaf litter is the exception inside that family: it overrides the tag test with a shape one,
    /// so it goes on stone and not on a bottom slab, the other way round from a sign.
    /// </summary>
    [Test]
    public void LeafLitterWantsAWholeFaceInsteadOfTheTag() {
        PlacementScene scene = new();
        Vec3<int> below = scene.Above(0, 0);
        Vec3<int> on = below.WithY(below.Y + 1);
        LeafLitterPlacementRule rule = new();

        scene.Set(below, Block.Stone);
        Assert.That(rule.CanSurvive(Block.LeafLitter, scene.World, on), Is.True, "on stone");

        scene.Set(below, Slab(SlabType.Bottom));
        Assert.That(rule.CanSurvive(Block.LeafLitter, scene.World, on), Is.False, "on a bottom slab");
    }

    /// <summary>
    /// A sea pickle takes either half of an or, and the loose half is what makes it different: it is
    /// enough for the collision shape below to reach the block boundary at all, whole face or not. A
    /// fence post reaches it with four pixels and holds a pickle; a bottom slab never gets there and
    /// does not.
    /// </summary>
    [Test]
    public void ASeaPickleTakesEitherHalfOfItsTest() {
        PlacementScene scene = new();
        Vec3<int> below = scene.Above(0, 0);
        Vec3<int> on = below.WithY(below.Y + 1);
        SeaPicklePlacementRule rule = new();

        scene.Set(below, Block.OakFence);
        Assert.Multiple(() => {
            Assert.That(rule.CanSurvive(Block.SeaPickle, scene.World, on), Is.True, "on a fence post");
            Assert.That(ShapeSupport.IsFaceSturdy(Block.OakFence, BlockFace.PosY), Is.False,
                "which is not a sturdy face, so the loose clause is what carried it");
        });

        scene.Set(below, Slab(SlabType.Bottom));
        Assert.That(rule.CanSurvive(Block.SeaPickle, scene.World, on), Is.False, "on a bottom slab");
    }

    /// <summary>
    /// Snow reads the <b>collision</b> shape, alone among the blocks that stand on things. Leaves are
    /// the case that shows it: they collide as a whole cube and support nothing, so snow settles on
    /// leaves and leaf litter does not.
    /// </summary>
    [Test]
    public void SnowReadsTheCollisionShapeAndTwoTags() {
        PlacementScene scene = new();
        Vec3<int> below = scene.Above(0, 0);
        Vec3<int> on = below.WithY(below.Y + 1);
        SnowLayerPlacementRule snow = new();
        LeafLitterPlacementRule litter = new();

        scene.Set(below, Block.OakLeaves);
        Assert.Multiple(() => {
            Assert.That(snow.CanSurvive(Block.Snow, scene.World, on), Is.True, "snow on leaves");
            Assert.That(litter.CanSurvive(Block.LeafLitter, scene.World, on), Is.False,
                "and leaf litter, asking the support shape, refuses the same block");
        });

        // Both tags overrule the shape test, in opposite directions, which is why they are checked
        // first and why the order between them is not decoration.
        scene.Set(below, Block.SoulSand);
        Assert.That(snow.CanSurvive(Block.Snow, scene.World, on), Is.True,
            "soul sand collides short and is in support_override_snow_layer");

        scene.Set(below, Block.Ice);
        Assert.That(snow.CanSurvive(Block.Snow, scene.World, on), Is.False,
            "ice is a whole cube and is in cannot_support_snow_layer");

        scene.Set(below, Block.Air);
        Assert.That(snow.CanSurvive(Block.Snow, scene.World, on), Is.False, "snow on nothing");
    }

    /// <summary>
    /// An amethyst cluster holds on to the block it grew out of, and to nothing else. Facing east
    /// means the block to the west is what matters, and what is under it does not.
    /// </summary>
    [Test]
    public void AnAmethystClusterOnlyCaresAboutWhatItGrewFrom() {
        PlacementScene scene = new();
        Vec3<int> behind = scene.Above(0, 0);
        Vec3<int> at = scene.Above(1, 0);
        IBlock cluster = ((IDirectional)Block.AmethystCluster).WithFacing(Cardinal.East);
        AmethystClusterPlacementRule rule = new();

        scene.Set(behind, Block.Stone);
        Assert.That(rule.CanSurvive(cluster, scene.World, at), Is.True, "grown out of stone");

        scene.Set(behind, Slab(SlabType.Bottom));
        Assert.That(rule.CanSurvive(cluster, scene.World, at), Is.False, "out of the side of a slab");
    }

    /// <summary>
    /// A bell in its two post form survives losing one post, which is the only reason the form exists
    /// as a separate state. The one post form does not.
    /// </summary>
    [Test]
    public void ATwoPostBellSurvivesLosingAPost() {
        PlacementScene scene = new();
        Vec3<int> west = scene.Above(0, 0);
        Vec3<int> at = scene.Above(1, 0);
        Vec3<int> east = scene.Above(2, 0);
        BellPlacementRule rule = new();

        scene.Set(west, Block.Stone);
        scene.Set(east, Block.Stone);

        IBlock? twoPost = scene.StateFor(Block.Bell, west, BlockFace.PosX);
        Assert.That(twoPost, Is.Not.Null);
        Assert.That(((IBellAttached)twoPost!).Attachment, Is.EqualTo(BellAttachType.DoubleWall),
            "walls both sides give the two post form");

        scene.Set(east, Block.Air);
        IBlock afterLoss = rule.UpdateShape(twoPost!, scene.World, at, BlockFace.PosX, east, Block.Air);
        Assert.Multiple(() => {
            Assert.That(afterLoss.Identifier, Is.EqualTo(Block.Bell.Identifier), "it is still a bell");
            Assert.That(((IBellAttached)afterLoss).Attachment, Is.EqualTo(BellAttachType.SingleWall),
                "and has dropped to one post");
        });

        // The remaining post going takes it with it, which the two post form was exempt from.
        scene.Set(west, Block.Air);
        IBlock afterBoth = rule.UpdateShape(afterLoss, scene.World, at, BlockFace.NegX, west, Block.Air);
        Assert.That(afterBoth.Identifier, Is.EqualTo(Block.Air.Identifier));
    }

    /// <summary>
    /// A bell aimed at a wall that turns out to be no good falls back to standing on the floor, and
    /// keeps the facing it was aimed with rather than turning to the player.
    /// </summary>
    [Test]
    public void ABellFallsBackToTheFloorKeepingItsFacing() {
        PlacementScene scene = new();
        Vec3<int> wall = scene.Above(0, 0);

        // A bottom slab has no whole side face, so the wall form cannot survive against it.
        scene.Set(wall, Slab(SlabType.Bottom));
        scene.Set(scene.Above(1, 0), Block.Air);

        IBlock? placed = scene.StateFor(Block.Bell, wall, BlockFace.PosX);
        Assert.That(placed, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(((IBellAttached)placed!).Attachment, Is.EqualTo(BellAttachType.Floor),
                "the floor below it is the stone the scene stands on");
            Assert.That(((IHorizontalFacing)placed!).Facing, Is.EqualTo(Direction.West),
                "still facing back into the wall it was aimed at");
        });
    }

    /// <summary>
    /// Breaking either half of a tall plant takes the other with it, and the rule is about the
    /// partner's cell rather than about survival, so it fires even where the ground is still fine.
    /// </summary>
    [Test]
    public void BothHalvesOfATallPlantGoTogether() {
        PlacementScene scene = new();
        Vec3<int> lower = scene.Above(0, 0);
        Vec3<int> upper = lower.WithY(lower.Y + 1);
        DoublePlantPlacementRule rule = new();
        IBlock lowerHalf = ((IDoubleHalved)Block.Sunflower).WithHalf(BlockHalf.Lower);
        IBlock upperHalf = ((IDoubleHalved)Block.Sunflower).WithHalf(BlockHalf.Upper);

        scene.Set(scene.Floor(0, 0), Block.GrassBlock);

        Assert.Multiple(() => {
            // The top going takes the bottom, though the bottom is still standing on grass.
            Assert.That(rule.UpdateShape(lowerHalf, scene.World, lower, BlockFace.PosY, upper, Block.Air)
                .Identifier, Is.EqualTo(Block.Air.Identifier), "lower half loses its top");

            Assert.That(rule.UpdateShape(upperHalf, scene.World, upper, BlockFace.NegY, lower, Block.Air)
                .Identifier, Is.EqualTo(Block.Air.Identifier), "upper half loses its bottom");

            // An intact partner leaves it alone.
            Assert.That(rule.UpdateShape(lowerHalf, scene.World, lower, BlockFace.PosY, upper, upperHalf)
                .Identifier, Is.EqualTo(Block.Sunflower.Identifier), "an intact pair stays");
        });
    }
}
