using ManagedServer.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Placement;

/// <summary>
/// The rules that read the world rather than the player: what a block's state comes out as given
/// what is around it.
/// <p/>
/// <c>PlacementRuleSweepTest</c> only says nothing threw. These say the answers are the right ones,
/// and each case is one where getting it wrong is invisible from this side: a note block that plays
/// the wrong instrument, a leaf block that never decays because its distance was seven, a scaffold
/// tower that will not come down.
/// </summary>
[TestFixture]
public class PlacementStateTest {
    private static string Property(IBlock block, string name) {
        return PlacementHelpers.PropertyOf(block, name);
    }

    [Test]
    public void GrassTakesItsSnowyFlagFromTheBlockAbove() {
        PlacementScene scene = new();
        Vec3<int> grass = scene.Above(0, 0);
        scene.Set(grass, Block.GrassBlock);

        Assert.That(Property(scene.World.GetBlock(grass), "snowy"), Is.EqualTo("false"));

        scene.Set(grass.WithY(grass.Y + 1), Block.SnowBlock);
        Assert.That(Property(scene.World.GetBlock(grass), "snowy"), Is.EqualTo("true"),
            "the cascade told the grass about the snow");

        scene.Set(grass.WithY(grass.Y + 1), Block.Air);
        Assert.That(Property(scene.World.GetBlock(grass), "snowy"), Is.EqualTo("false"));
    }

    /// <summary>
    /// The instrument comes from above when the block above is a mob head, and from below otherwise.
    /// A mob head below is the case that reads wrong if the rule is paraphrased: it gives a harp, not
    /// the skeleton sound.
    /// </summary>
    [Test]
    public void ANoteBlockTakesItsInstrumentFromAboveThenBelow() {
        PlacementScene scene = new();
        Vec3<int> pos = scene.Above(0, 0);

        // Stone below, nothing above: basedrum, the stone instrument.
        IBlock plain = scene.StateFor(Block.NoteBlock, scene.Floor(0, 0), BlockFace.PosY)!;
        Assert.That(Property(plain, "instrument"), Is.EqualTo("basedrum"));

        scene.Set(pos.WithY(pos.Y + 1), Block.SkeletonSkull);
        IBlock underSkull = scene.StateFor(Block.NoteBlock, scene.Floor(0, 0), BlockFace.PosY)!;
        Assert.That(Property(underSkull, "instrument"), Is.EqualTo("skeleton"),
            "a mob head above wins outright");

        scene.Set(pos.WithY(pos.Y + 1), Block.Air);
        scene.Set(scene.Floor(0, 0), Block.SkeletonSkull);
        IBlock overSkull = scene.StateFor(Block.NoteBlock, scene.Floor(0, 0), BlockFace.PosY)!;
        Assert.That(Property(overSkull, "instrument"), Is.EqualTo("harp"),
            "a mob head below is ignored and falls back to harp, not to skeleton");
    }

    [Test]
    public void LeavesArePersistentAndCountFromTheNearestLog() {
        PlacementScene scene = new();

        IBlock alone = scene.StateFor(Block.OakLeaves, scene.Floor(0, 0), BlockFace.PosY)!;
        Assert.Multiple(() => {
            Assert.That(Property(alone, "persistent"), Is.EqualTo("true"), "placed leaves never decay");
            Assert.That(Property(alone, "distance"), Is.EqualTo("7"));
        });

        scene.Set(scene.Above(1, 0), Block.OakLog);
        IBlock besideLog = scene.StateFor(Block.OakLeaves, scene.Floor(0, 0), BlockFace.PosY)!;
        Assert.That(Property(besideLog, "distance"), Is.EqualTo("1"), "a log reads as distance zero");
    }

    [Test]
    public void ConcretePowderSetsInWater() {
        PlacementScene scene = new();
        Vec3<int> into = scene.Above(0, 0);

        IBlock dry = scene.StateFor(Block.WhiteConcretePowder, scene.Floor(0, 0), BlockFace.PosY)!;
        Assert.That(dry.Identifier, Is.EqualTo(Block.WhiteConcretePowder.Identifier));

        scene.Set(into, Block.Water);
        IBlock wet = scene.StateFor(Block.WhiteConcretePowder, scene.Floor(0, 0), BlockFace.PosY)!;
        Assert.That(wet.Identifier, Is.EqualTo(Block.WhiteConcrete.Identifier));
    }

    /// <summary>
    /// Distance zero standing on the ground, and one more per block out from the tower, which is what
    /// limits how far a walkway can be run. The <c>bottom</c> flag is the drawn legs and is only on
    /// for a piece held sideways.
    /// </summary>
    [Test]
    public void ScaffoldingCountsItsDistanceSideways() {
        PlacementScene scene = new();
        Vec3<int> onGround = scene.Above(0, 0);

        IBlock first = scene.StateFor(Block.Scaffolding, scene.Floor(0, 0), BlockFace.PosY)!;
        Assert.Multiple(() => {
            Assert.That(Property(first, "distance"), Is.EqualTo("0"));
            Assert.That(Property(first, "bottom"), Is.EqualTo("false"));
        });

        scene.Set(onGround, first);
        Vec3<int> outwards = scene.Above(1, 0).WithY(onGround.Y + 1);
        scene.Set(scene.Above(0, 0).WithY(onGround.Y + 1), first);

        IBlock arm = scene.StateFor(Block.Scaffolding, outwards, BlockFace.PosY)!;
        Assert.Multiple(() => {
            Assert.That(Property(arm, "distance"), Is.EqualTo("1"), "one out from the tower");
            Assert.That(Property(arm, "bottom"), Is.EqualTo("true"), "nothing under it, so it grows legs");
        });
    }

    /// <summary>
    /// The scaffold is the one block whose rule recomputes in the cascade rather than on a scheduled
    /// tick, so a tower whose base goes has to come down in the same write.
    /// </summary>
    [Test]
    public void AScaffoldTowerFallsWhenItsBaseGoes() {
        PlacementScene scene = new();
        Vec3<int> bottom = scene.Above(0, 0);

        for (int y = 0; y < 3; y++) {
            IBlock state = scene.StateFor(Block.Scaffolding, bottom.WithY(bottom.Y + y - 1),
                BlockFace.PosY)!;
            scene.Set(bottom.WithY(bottom.Y + y), state);
        }

        Assert.That(scene.World.GetBlock(bottom.WithY(bottom.Y + 2)).Identifier,
            Is.EqualTo(Block.Scaffolding.Identifier));

        scene.Set(scene.Floor(0, 0), Block.Air);
        Assert.That(scene.World.GetBlock(bottom).Air, Is.True, "the base lost its footing");
        Assert.That(scene.World.GetBlock(bottom.WithY(bottom.Y + 2)).Air, Is.True,
            "and the cascade took the rest of the tower with it");
    }

    /// <summary>
    /// Two chests side by side facing the same way become a pair, and both halves say so. The second
    /// half is written by the cascade rather than by the placement, which is what
    /// <c>updateShape</c> is for here.
    /// </summary>
    [Test]
    public void TwoChestsPairUpAndComeApart() {
        PlacementScene scene = new();
        Vec3<int> left = scene.Above(0, 0);
        Vec3<int> right = scene.Above(1, 0);

        IBlock south = ((IHorizontalFacing)Block.Chest).WithFacing(Direction.South);
        scene.Set(left, south);

        IBlock placed = scene.StateFor(Block.Chest, scene.Floor(1, 0), BlockFace.PosY, item: Item.Chest)!;
        Assert.That(Property(placed, "type"), Is.EqualTo("left"),
            "the new chest takes the left half, with its partner clockwise of its facing");

        scene.Set(right, placed);
        Assert.That(Property(scene.World.GetBlock(left), "type"), Is.EqualTo("right"),
            "and the cascade made the old one the other half");

        scene.Set(right, Block.Air);
        Assert.That(Property(scene.World.GetBlock(left), "type"), Is.EqualTo("single"),
            "breaking one leaves the other single");
    }

    /// <summary>
    /// A dripstone hung from a ceiling points down and is a tip; a second one under it makes the
    /// first a frustum. <c>thickness</c> is a position in the column, not a size.
    /// </summary>
    [Test]
    public void DripstoneHangsAndThickensAsTheColumnGrows() {
        PlacementScene scene = new();
        Vec3<int> ceiling = scene.Above(0, 0).WithY(scene.FloorY + 4);
        scene.Set(ceiling, Block.Stone);

        Vec3<int> first = ceiling.WithY(ceiling.Y - 1);
        IBlock tip = scene.StateFor(Block.PointedDripstone, ceiling, BlockFace.NegY)!;
        Assert.Multiple(() => {
            Assert.That(Property(tip, "vertical_direction"), Is.EqualTo("down"));
            Assert.That(Property(tip, "thickness"), Is.EqualTo("tip"));
        });

        scene.Set(first, tip);
        IBlock second = scene.StateFor(Block.PointedDripstone, first, BlockFace.NegY)!;
        Assert.That(Property(second, "thickness"), Is.EqualTo("tip"));

        scene.Set(first.WithY(first.Y - 1), second);
        Assert.That(Property(scene.World.GetBlock(first), "thickness"), Is.EqualTo("frustum"),
            "the piece above a tip is a frustum");
    }

    /// <summary>
    /// A mushroom block's six booleans are its skin, so a face touching another mushroom block turns
    /// off. Getting the sense the wrong way round looks fine on a single block and inside out on two.
    /// </summary>
    [Test]
    public void MushroomBlocksCapOnlyTheirOutsideFaces() {
        PlacementScene scene = new();
        Vec3<int> alone = scene.Above(0, 0);

        IBlock single = scene.StateFor(Block.BrownMushroomBlock, scene.Floor(0, 0), BlockFace.PosY)!;
        Assert.That(((IFaceConnected)single).Connected(BlockFace.PosX), Is.True, "capped all over");

        scene.Set(alone, single);
        scene.Set(scene.Above(1, 0), single);
        Assert.That(((IFaceConnected)scene.World.GetBlock(alone)).Connected(BlockFace.PosX), Is.False,
            "the face they share stopped being skin");
    }

    /// <summary>
    /// Glow lichen goes on the face it was aimed at. The cell is not otherwise occupied, so this is
    /// the first placement rather than the add-a-face one.
    /// </summary>
    [Test]
    public void GlowLichenTakesTheFaceItWasAimedAt() {
        PlacementScene scene = new();

        IBlock onFloor = scene.StateFor(Block.GlowLichen, scene.Floor(0, 0), BlockFace.PosY)!;
        Assert.Multiple(() => {
            Assert.That(((IFaceConnected)onFloor).Connected(BlockFace.NegY), Is.True,
                "aimed at the top of the floor, so it takes its own down face");
            Assert.That(((IFaceConnected)onFloor).Connected(BlockFace.PosY), Is.False);
        });

        Vec3<int> pos = scene.Above(0, 0);
        scene.Set(pos, onFloor);
        scene.Set(scene.Floor(0, 0), Block.Air);
        Assert.That(scene.World.GetBlock(pos).Air, Is.True, "the last face going is a break");
    }

    /// <summary>
    /// A cactus refuses to be placed with anything solid beside it, which is the only survival rule
    /// in the game that reads sideways rather than up or down.
    /// </summary>
    [Test]
    public void ACactusRefusesANeighbour() {
        PlacementScene scene = new();
        Vec3<int> pos = scene.Above(0, 0);
        scene.Set(scene.Floor(0, 0), Block.Sand);

        Assert.That(scene.Rules.For(Block.Cactus, scene.World)!.CanSurvive(Block.Cactus, scene.World, pos),
            Is.True);

        scene.Set(scene.Above(1, 0), Block.Stone);
        Assert.That(scene.Rules.For(Block.Cactus, scene.World)!.CanSurvive(Block.Cactus, scene.World, pos),
            Is.False, "a solid block on any horizontal is enough");
    }

    /// <summary>
    /// The vegetation tag, not the shape: a flower goes on grass and not on stone, however solid the
    /// stone is. Without this rule a flower placed on stone stays there for ever.
    /// </summary>
    [Test]
    public void AFlowerNeedsTheVegetationTagAndNotASolidFace() {
        PlacementScene scene = new();
        Vec3<int> pos = scene.Above(0, 0);
        var rule = scene.Rules.For(Block.Dandelion, scene.World)!;

        Assert.That(rule.CanSurvive(Block.Dandelion, scene.World, pos), Is.False, "stone is not soil");

        scene.Set(scene.Floor(0, 0), Block.GrassBlock);
        Assert.That(rule.CanSurvive(Block.Dandelion, scene.World, pos), Is.True);

        scene.Set(pos, Block.Dandelion);
        scene.Set(scene.Floor(0, 0), Block.Stone);
        Assert.That(scene.World.GetBlock(pos).Air, Is.True, "and it dies when the soil goes");
    }
}
