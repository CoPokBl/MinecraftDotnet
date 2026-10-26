using Minecraft.Placement.Rules;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Testing.Placement;

/// <summary>
/// That a server which asked for nothing gets nothing.
/// <p/>
/// Every other fixture in here registers the vanilla rules, so they all pass whether or not the rules
/// are optional. This is the one that fails if they ever go back to loading themselves, which is the
/// mistake worth pinning: it does not look like a bug, it looks like the framework being helpful.
/// <p/>
/// The absence of a rule is not a degraded state. Vanilla's own <c>Block.getStateForPlacement</c>
/// returns the default state and its <c>updateShape</c> returns the state unchanged, so a block with
/// no rule behaves exactly as a vanilla block whose class overrides neither.
/// </summary>
[TestFixture]
public class BareServerTest {
    /// <summary>An empty rule list, so the machinery is present and has no opinions.</summary>
    private static PlacementScene Bare() => new([]);

    [Test]
    public void NothingIsRegisteredUntilSomethingRegistersIt() {
        PlacementScene bare = Bare();
        Assert.Multiple(() => {
            Assert.That(bare.Rules.IsEmpty, Is.True);
            Assert.That(bare.Rules.Registered, Is.Empty);
            Assert.That(bare.Rules.For(Block.OakStairs, bare.World), Is.Null, "no rule for stairs");
        });
    }

    /// <summary>
    /// A block still places, it just places its default state. Stairs face north whatever you were
    /// looking at, and a slab clicked on top of a slab goes beside it rather than doubling.
    /// </summary>
    [Test]
    public void ABlockPlacesItsDefaultState() {
        PlacementScene bare = Bare();
        Vec3<int> floor = bare.Floor(0, 0);

        IBlock? stairs = bare.StateFor(Block.OakStairs, floor, BlockFace.PosY, 0.9);
        Assert.Multiple(() => {
            Assert.That(((IHorizontalFacing)stairs!).Facing, Is.EqualTo(Direction.North),
                "the default facing, not one derived from the click");
            Assert.That(((IHalved)stairs!).Half, Is.EqualTo(TopBottom.Bottom));
        });

        // The replace decision falls back to the default canBeReplaced, so a slab does not double.
        bare.Set(bare.Above(0, 0), ((ISlabTyped)Block.OakSlab).WithType(SlabType.Bottom));
        Assert.That(bare.PlacePosFor(bare.Above(0, 0), BlockFace.PosY, Item.OakSlab),
            Is.EqualTo(bare.Above(0, 0).WithY(bare.FloorY + 2)), "placed above rather than doubled");
    }

    /// <summary>
    /// The cascade is inert. A fence gains no connection, and a ladder with nothing behind it stays
    /// where it was put, because nothing has an opinion about whether it should.
    /// </summary>
    [Test]
    public void NeighboursDoNotReact() {
        PlacementScene bare = Bare();
        Vec3<int> fence = bare.Above(0, 0);
        Vec3<int> beside = bare.Above(1, 0);

        bare.Set(fence, Block.OakFence);
        bare.Set(beside, Block.Stone);
        Assert.That(((IFaceConnected)bare.World.GetBlock(fence)).Connected(BlockFace.PosX), Is.False,
            "the fence did not notice");

        bare.Set(beside, ((IHorizontalFacing)Block.Ladder).WithFacing(Direction.East));
        bare.Set(fence, Block.Air);
        Assert.That(bare.World.GetBlock(beside).Identifier, Is.EqualTo(Block.Ladder.Identifier),
            "a ladder attached to nothing stays put");
    }

    /// <summary>
    /// Rules go on and come off one at a time, which is the granularity that matters: a consumer
    /// wanting vanilla stairs and their own slabs must not have to take all of it or none.
    /// </summary>
    [Test]
    public void RulesRegisterAndUnregisterIndividually() {
        PlacementScene bare = Bare();
        StairPlacementRule stairs = new();

        Action remove = bare.Rules.Add(stairs);
        Assert.Multiple(() => {
            Assert.That(bare.Rules.For(Block.OakStairs, bare.World), Is.SameAs(stairs));
            Assert.That(bare.Rules.For(Block.OakSlab, bare.World), Is.Null, "and nothing else came with it");
        });

        remove();
        Assert.That(bare.Rules.For(Block.OakStairs, bare.World), Is.Null, "and it goes back off");
    }

    /// <summary>
    /// A consumer's rule replaces one of ours by being registered after it, and putting it back is
    /// dropping the replacement rather than re-adding anything.
    /// </summary>
    [Test]
    public void AConsumerRuleShadowsAVanillaOne() {
        PlacementScene scene = new();   // the whole vanilla set
        IBlockPlacementRule vanilla = scene.Rules.For(Block.OakSlab, scene.World)!;
        Assert.That(vanilla, Is.TypeOf<SlabPlacementRule>());

        AlwaysDoubleSlabs mine = new();
        Action remove = scene.Rules.Add(mine);
        Assert.That(scene.Rules.For(Block.OakSlab, scene.World), Is.SameAs(mine));

        remove();
        Assert.That(scene.Rules.For(Block.OakSlab, scene.World), Is.SameAs(vanilla), "vanilla's is back");
    }

    /// <summary>
    /// Selecting a subset up front, for a consumer who never wants ours in the first place.
    /// </summary>
    [Test]
    public void TheVanillaSetCanBeTakenInPieces() {
        Assert.Multiple(() => {
            Assert.That(VanillaPlacementRules.Only(BlockClass.StairBlock).Select(r => r.VanillaClass),
                Is.EquivalentTo(new[] { BlockClass.StairBlock }));

            Assert.That(VanillaPlacementRules.Except(BlockClass.SlabBlock).Select(r => r.VanillaClass),
                Does.Not.Contain(BlockClass.SlabBlock));
            Assert.That(VanillaPlacementRules.Except(BlockClass.SlabBlock),
                Has.Count.EqualTo(VanillaPlacementRules.All.Count - 1));
        });
    }

    /// <summary>
    /// <c>World.ShapeUpdates</c> switches the built in cascade off for a world that does have rules,
    /// which is what a schematic loader wants without having to pass a flag on every write.
    /// </summary>
    [Test]
    public void ShapeUpdatesCanBeSwitchedOffPerWorld() {
        PlacementScene scene = new();
        scene.World.ShapeUpdates = false;

        Vec3<int> fence = scene.Above(0, 0);
        scene.Set(fence, Block.OakFence);
        scene.Set(scene.Above(1, 0), Block.Stone);

        Assert.That(((IFaceConnected)scene.World.GetBlock(fence)).Connected(BlockFace.PosX), Is.False);
    }

    private sealed class AlwaysDoubleSlabs : IBlockPlacementRule {
        public BlockClass VanillaClass => BlockClass.SlabBlock;

        public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
            return ((ISlabTyped)block).WithType(SlabType.Double);
        }
    }
}
