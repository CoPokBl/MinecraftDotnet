using ManagedServer.Fluids;
using ManagedServer.Placement.Helpers;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Placement.Rules;

//
// The VegetationBlock family: everything that grows out of the ground and dies when the ground goes.
//
// Vanilla splits it in an unusual way. VegetationBlock.canSurvive is one line, "mayPlaceOn the block
// below", and almost nothing overrides canSurvive; what the twenty odd subclasses override is
// mayPlaceOn, and each one names a different tag. So these rules all have the same shape and differ
// only in the question. That is the granularity to keep: a consumer replacing what wither roses
// grow on does not touch what azaleas grow on.
//
// VegetationBlock.updateShape is "die the moment you cannot survive", whichever neighbour changed,
// and every rule here inherits it.
//

/// <summary>
/// The shared body: <c>canSurvive</c> is <c>mayPlaceOn(below)</c>, <c>updateShape</c> is death.
/// Subclasses supply the question.
/// </summary>
public abstract class VegetationPlacementRuleBase : IBlockPlacementRule {
    public abstract BlockClass VanillaClass { get; }

    /// <summary>
    /// <c>mayPlaceOn</c>, asked of the block below. It takes the plant as well because vanilla's is
    /// an instance method, and two of the subclasses read a field off the block rather than deciding
    /// from the class alone.
    /// </summary>
    protected abstract bool MayPlaceOn(IBlock plant, IBlock below, World world, Vec3<int> belowPos);

    /// <summary>
    /// Virtual only so a subclass can be dispatched to: this class fixes the interface mapping, so a
    /// subclass declaring the hook without <c>override</c> writes a method nobody calls.
    /// </summary>
    public virtual IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) => block;

    /// <inheritdoc cref="GetStateForPlacement"/>
    public virtual bool CanBeReplaced(IBlock existing, IBlockPlaceContext context) {
        return IBlockPlacementRule.DefaultCanBeReplaced(existing, context);
    }

    /// <inheritdoc cref="GetStateForPlacement"/>
    public virtual void OnPlaced(IBlock placed, IBlockPlaceContext context) { }

    public virtual bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        Vec3<int> below = pos.WithY(pos.Y - 1);
        return MayPlaceOn(block, world.GetBlock(below), world, below);
    }

    public virtual IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return CanSurvive(block, world, pos) ? block : Block.Air;
    }
}

/// <summary>
/// A subclass whose whole <c>mayPlaceOn</c> is one block tag.
/// </summary>
public abstract class TagVegetationPlacementRule(Identifier tag) : VegetationPlacementRuleBase {
    protected override bool MayPlaceOn(IBlock plant, IBlock below, World world, Vec3<int> belowPos) {
        return PlacementHelpers.InTag(world.Server.Registry, tag, below.Identifier);
    }
}

/// <summary>
/// <c>VegetationBlock</c> itself: flowers, saplings, dead bushes, tall grass, sweet berry bushes and
/// everything else that did not need its own answer. The <c>supports_vegetation</c> tag.
/// </summary>
public sealed class VegetationPlacementRule() : TagVegetationPlacementRule("minecraft:supports_vegetation") {
    public override BlockClass VanillaClass => BlockClass.VegetationBlock;
}

/// <summary>
/// <c>CropBlock</c>: wheat, carrots, potatoes, beetroot. The <c>supports_crops</c> tag, plus light.
/// <p/>
/// <b>Documented divergence in the light half.</b> Vanilla also wants
/// <c>level.getRawBrightness(pos, 0) &gt;= 8</c>. Lighting here is computed per chunk for sending to
/// the client and there is no per position query, so the light is treated as sufficient. That is
/// wrong for a crop planted in the dark, which vanilla refuses and this allows, and right everywhere
/// else. The tag half is what stops crops being planted on plain dirt.
/// </summary>
public sealed class CropPlacementRule() : TagVegetationPlacementRule("minecraft:supports_crops") {
    public override BlockClass VanillaClass => BlockClass.CropBlock;
}

/// <summary>
/// <c>MushroomBlock</c>: the two small mushrooms. The one member of the family that overrides
/// <c>canSurvive</c> as well, because the tag it reads overrules the light rather than answering the
/// support question: mycelium, podzol and the two nyliums grow mushrooms in daylight, everything else
/// needs the dark.
/// <p/>
/// <b>The light half is the same divergence <see cref="CropPlacementRule"/> records</b>, and it bites
/// the other way round here: vanilla refuses a mushroom in daylight and this allows one. The
/// <c>mayPlaceOn</c> half is exact and is not the same test as anything else in these rules. It is
/// <c>isSolidRender</c>, ie. <c>isShapeFullBlock</c> over the <b>occlusion</b> shape, so a mushroom
/// sits on a barrel and not on a slab or on glass.
/// </summary>
public sealed class MushroomPlacementRule : VegetationPlacementRuleBase {
    private static readonly Identifier OverridesLight = "minecraft:overrides_mushroom_light_requirement";

    public override BlockClass VanillaClass => BlockClass.MushroomBlock;

    public override bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        Vec3<int> belowPos = pos.WithY(pos.Y - 1);
        IBlock below = world.GetBlock(belowPos);
        return PlacementHelpers.InTag(world.Server.Registry, OverridesLight, below.Identifier)
               || MayPlaceOn(block, below, world, belowPos);
    }

    protected override bool MayPlaceOn(IBlock plant, IBlock below, World world, Vec3<int> belowPos) {
        return ShapeSupport.IsShapeFullBlock(below.OcclusionShape);
    }
}

/// <summary><c>AzaleaBlock</c>. The <c>supports_azalea</c> tag, which is wider than vegetation.</summary>
public sealed class AzaleaPlacementRule() : TagVegetationPlacementRule("minecraft:supports_azalea") {
    public override BlockClass VanillaClass => BlockClass.AzaleaBlock;
}

/// <summary><c>DryVegetationBlock</c>: dead bushes and the short dry grasses.</summary>
public sealed class DryVegetationPlacementRule()
    : TagVegetationPlacementRule("minecraft:supports_dry_vegetation") {
    public override BlockClass VanillaClass => BlockClass.DryVegetationBlock;
}

/// <summary><c>NetherSproutsBlock</c>.</summary>
public sealed class NetherSproutsPlacementRule()
    : TagVegetationPlacementRule("minecraft:supports_nether_sprouts") {
    public override BlockClass VanillaClass => BlockClass.NetherSproutsBlock;
}

/// <summary><c>NetherWartBlock</c>: soul sand alone.</summary>
public sealed class NetherWartPlacementRule()
    : TagVegetationPlacementRule("minecraft:supports_nether_wart") {
    public override BlockClass VanillaClass => BlockClass.NetherWartBlock;
}

/// <summary><c>WitherRoseBlock</c>: vegetation, plus the two soul blocks.</summary>
public sealed class WitherRosePlacementRule()
    : TagVegetationPlacementRule("minecraft:supports_wither_rose") {
    public override BlockClass VanillaClass => BlockClass.WitherRoseBlock;
}

/// <summary>
/// <c>SeagrassBlock</c>. A sturdy face below that is not in <c>cannot_support_seagrass</c>, and a
/// full water cell to be placed into at all.
/// </summary>
public sealed class SeagrassPlacementRule : VegetationPlacementRuleBase {
    private static readonly Identifier CannotSupport = "minecraft:cannot_support_seagrass";

    public override BlockClass VanillaClass => BlockClass.SeagrassBlock;

    public override IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return PlacementHelpers.IsFullWaterAt(context.World, context.PlacePos) ? block : null;
    }

    protected override bool MayPlaceOn(IBlock plant, IBlock below, World world, Vec3<int> belowPos) {
        return ShapeSupport.IsFaceSturdy(below, BlockFace.PosY)
               && !PlacementHelpers.InTag(world.Server.Registry, CannotSupport, below.Identifier);
    }
}

/// <summary>
/// <c>TallSeagrassBlock</c>. The double plant shape, with water demanded in both cells: the lower
/// half checks its own, and placement checks the cell above as well so a two tall plant is never put
/// half out of the water.
/// </summary>
public sealed class TallSeagrassPlacementRule : DoublePlantPlacementRule {
    private static readonly Identifier CannotSupportSeagrass = "minecraft:cannot_support_seagrass";

    public override BlockClass VanillaClass => BlockClass.TallSeagrassBlock;

    /// <summary>
    /// The same question <c>SeagrassBlock</c> asks, and it is a copy upstream too: tall seagrass
    /// extends <c>DoublePlantBlock</c> rather than <c>SeagrassBlock</c>, so the two share nothing but
    /// the line.
    /// </summary>
    protected override bool MayPlaceOn(IBlock plant, IBlock below, World world, Vec3<int> belowPos) {
        return ShapeSupport.IsFaceSturdy(below, BlockFace.PosY)
               && !PlacementHelpers.InTag(world.Server.Registry, CannotSupportSeagrass, below.Identifier);
    }

    public override IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock? state = base.GetStateForPlacement(block, context);
        if (state is null) {
            return null;
        }

        Vec3<int> above = context.PlacePos.WithY(context.PlacePos.Y + 1);
        return PlacementHelpers.IsFullWaterAt(context.World, above) ? state : null;
    }

    /// <summary>
    /// The upper half wants its own lower half, exactly as any double plant does. The lower half adds
    /// the water test, which is why breaking the water column takes the plant.
    /// </summary>
    public override bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        if (block is IDoubleHalved { Half: BlockHalf.Upper }) {
            return base.CanSurvive(block, world, pos);
        }

        return base.CanSurvive(block, world, pos) && PlacementHelpers.IsFullWaterAt(world, pos);
    }
}

/// <summary>
/// <c>LilyPadBlock</c>. Floats: water below, and nothing fluid in its own cell.
/// </summary>
public sealed class LilyPadPlacementRule : VegetationPlacementRuleBase {
    private static readonly Identifier SupportsLilyPad = "minecraft:supports_lily_pad";

    public override BlockClass VanillaClass => BlockClass.LilyPadBlock;

    protected override bool MayPlaceOn(IBlock plant, IBlock below, World world, Vec3<int> belowPos) {
        // FluidTags.SUPPORTS_LILY_PAD is #minecraft:water, ie. FluidKind.Water exactly. The block tag
        // beside it catches the frozen surfaces.
        bool onWater = FluidState.Of(below).Kind == FluidKind.Water
                       || PlacementHelpers.InTag(world.Server.Registry, SupportsLilyPad, below.Identifier);
        return onWater && FluidState.Of(world.GetBlock(belowPos.WithY(belowPos.Y + 1))).IsEmpty;
    }
}

/// <summary>
/// <c>CactusFlowerBlock</c>. Asks the <b>centre</b> column of the face below, with a tag that
/// overrules it, so a flower sits on a cactus and on a fence post and not on a bottom slab.
/// </summary>
public sealed class CactusFlowerPlacementRule : VegetationPlacementRuleBase {
    private static readonly Identifier SupportOverride = "minecraft:support_override_cactus_flower";

    public override BlockClass VanillaClass => BlockClass.CactusFlowerBlock;

    protected override bool MayPlaceOn(IBlock plant, IBlock below, World world, Vec3<int> belowPos) {
        return PlacementHelpers.InTag(world.Server.Registry, SupportOverride, below.Identifier)
               || ShapeSupport.IsFaceSturdy(below, BlockFace.PosY, SupportType.Center);
    }
}

/// <summary>
/// <c>StemBlock</c>, <c>AttachedStemBlock</c>, <c>NetherFungusBlock</c> and <c>NetherRootsBlock</c>.
/// <p/>
/// These four take the tag they grow on as a <b>constructor argument</b> rather than deciding it in
/// the class, so which tag applies is per block and not per class. Nothing in the generated data
/// carries it: the dumper reflects over <c>BlockBehaviour.Properties</c> and <c>BlockState</c>, and
/// this lives on the <c>Block</c> instance's own fields. So it is a table here, and
/// <c>VegetationSupportTableTest</c> asserts the table covers every block of these four classes, so a
/// fifth one added upstream fails a test rather than becoming a plant that can never be placed.
/// </summary>
public class GrownFromTagPlacementRule(BlockClass vanillaClass) : VegetationPlacementRuleBase {
    /// <summary>The constructor arguments from <c>Blocks.java</c>, block by block.</summary>
    public static readonly IReadOnlyDictionary<Identifier, Identifier> Tags =
        new Dictionary<Identifier, Identifier> {
            ["minecraft:pumpkin_stem"] = "minecraft:supports_pumpkin_stem",
            ["minecraft:attached_pumpkin_stem"] = "minecraft:supports_pumpkin_stem",
            ["minecraft:melon_stem"] = "minecraft:supports_melon_stem",
            ["minecraft:attached_melon_stem"] = "minecraft:supports_melon_stem",
            ["minecraft:crimson_fungus"] = "minecraft:supports_crimson_fungus",
            ["minecraft:warped_fungus"] = "minecraft:supports_warped_fungus",
            ["minecraft:crimson_roots"] = "minecraft:supports_crimson_roots",
            ["minecraft:warped_roots"] = "minecraft:supports_warped_roots"
        };

    public static readonly BlockClass[] Classes = [
        BlockClass.StemBlock, BlockClass.AttachedStemBlock,
        BlockClass.NetherFungusBlock, BlockClass.NetherRootsBlock
    ];

    public override BlockClass VanillaClass => vanillaClass;

    /// <summary>
    /// The plant's own identifier decides the tag, so this is the one rule that reads the block being
    /// placed and not only what is under it.
    /// </summary>
    protected override bool MayPlaceOn(IBlock plant, IBlock below, World world, Vec3<int> belowPos) {
        if (!Tags.TryGetValue(plant.Identifier, out Identifier tag)) {
            // Unknown member of the class: fall back to the base class answer rather than refusing,
            // since a plant that can never be placed is the worse failure. The test catches it.
            return PlacementHelpers.InTag(world.Server.Registry, "minecraft:supports_vegetation",
                below.Identifier);
        }

        return PlacementHelpers.InTag(world.Server.Registry, tag, below.Identifier);
    }
}

/// <summary>
/// <c>AttachedStemBlock</c>, the short stem bent towards a pumpkin or a melon. It grows the tag rule
/// above and adds the one thing that makes it a separate class: losing its fruit turns it back into
/// an ordinary stem.
/// <p/>
/// Which fruit and which stem are <b>constructor arguments</b> in <c>Blocks.java</c> for the same
/// reason the tag is, so <see cref="Grown"/> is a table beside <see cref="GrownFromTagPlacementRule.Tags"/>
/// and <c>VegetationSupportTableTest</c> covers it the same way.
/// </summary>
public sealed class AttachedStemPlacementRule()
    : GrownFromTagPlacementRule(BlockClass.AttachedStemBlock) {
    /// <param name="Stem">What the attached stem reverts to.</param>
    /// <param name="Fruit">The block whose disappearance makes it revert.</param>
    public readonly record struct Attachment(Identifier Stem, Identifier Fruit);

    public static readonly IReadOnlyDictionary<Identifier, Attachment> Grown =
        new Dictionary<Identifier, Attachment> {
            ["minecraft:attached_pumpkin_stem"] =
                new Attachment("minecraft:pumpkin_stem", "minecraft:pumpkin"),
            ["minecraft:attached_melon_stem"] =
                new Attachment("minecraft:melon_stem", "minecraft:melon")
        };

    /// <summary>
    /// Only the cell the stem is bent towards can do it, and the stem comes back fully grown at age
    /// seven rather than starting over, so a broken pumpkin regrows from the same stem.
    /// </summary>
    public override IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (Grown.TryGetValue(block.Identifier, out Attachment attachment)
            && block is IHorizontalFacing stem && toNeighbour == stem.Facing.ToFace()
            && neighbourState.Identifier != attachment.Fruit) {
            return ((IAged)world.Server.Registry.Blocks[attachment.Stem]).WithAge(7);
        }

        return base.UpdateShape(block, world, pos, toNeighbour, neighbourPos, neighbourState);
    }
}
