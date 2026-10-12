using Minecraft.Fluids;
using Minecraft.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace Minecraft.Placement.Rules;

/// <summary>
/// The head and body halves of a growing plant: kelp, cave vines, twisting vines and weeping vines.
/// <p/>
/// Each family is two blocks. The <b>head</b> is the growing tip and carries an age; the <b>body</b>
/// is the stalk behind it. Placing the item always places the head unless the cell it is growing into
/// already holds part of the same plant, in which case what you place is a body, because you are
/// extending a stalk rather than starting one.
/// <p/>
/// Which way a family grows and which two blocks it is made of are <b>constructor arguments</b> in
/// <c>Blocks.java</c>, not anything the class or the state carries, so <see cref="Families"/> is a
/// table for the same reason <c>GrownFromTagPlacementRule</c>'s is, and
/// <c>VegetationSupportTableTest</c> covers it the same way.
/// </summary>
public sealed class GrowingPlantPlacementRule(BlockClass vanillaClass) : IBlockPlacementRule {
    /// <param name="Head">The tip, which is what an item places into open space.</param>
    /// <param name="Body">The stalk behind the tip.</param>
    /// <param name="Growth">Which way the plant grows, ie. where the tip is relative to the stalk.</param>
    public readonly record struct Family(Identifier Head, Identifier Body, BlockFace Growth);

    /// <summary>
    /// One entry per block of both classes, keyed by either half, from the four
    /// <c>GrowingPlantHeadBlock</c> constructor calls.
    /// </summary>
    public static readonly IReadOnlyDictionary<Identifier, Family> Families = Build([
        new Family("minecraft:kelp", "minecraft:kelp_plant", BlockFace.PosY),
        new Family("minecraft:twisting_vines", "minecraft:twisting_vines_plant", BlockFace.PosY),
        new Family("minecraft:cave_vines", "minecraft:cave_vines_plant", BlockFace.NegY),
        new Family("minecraft:weeping_vines", "minecraft:weeping_vines_plant", BlockFace.NegY)
    ]);

    public static readonly BlockClass[] Classes = [
        BlockClass.GrowingPlantHeadBlock, BlockClass.GrowingPlantBodyBlock
    ];

    private static readonly Identifier CannotSupportKelp = "minecraft:cannot_support_kelp";

    private static IReadOnlyDictionary<Identifier, Family> Build(Family[] families) {
        Dictionary<Identifier, Family> byBlock = [];
        foreach (Family family in families) {
            byBlock[family.Head] = family;
            byBlock[family.Body] = family;
        }

        return byBlock;
    }

    public BlockClass VanillaClass => vanillaClass;

    /// <summary>
    /// Growing into more of the same plant gives a body; anything else gives the head.
    /// <p/>
    /// Vanilla's head also takes a random age here (<c>random.nextInt(25)</c>), which decides how
    /// soon it next grows. That is dropped: there is no growth tick to consume it, so it would be a
    /// visible difference from the client's prediction bought for nothing.
    /// </summary>
    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (!Families.TryGetValue(block.Identifier, out Family family)) {
            return block;
        }

        IBlock ahead = context.World.GetBlock(context.PlacePos.GetBlockTowards(family.Growth));
        return IsPartOf(ahead, family)
            ? context.World.Registry.Blocks[family.Body]
            : block;
    }

    /// <summary>
    /// Held from behind: by more of its own plant, or by a sturdy face pointing the way it grows.
    /// Kelp adds a tag of things it will not grow off whatever their shape.
    /// </summary>
    public bool CanSurvive(IBlock block, IPlacementLevel world, Vec3<int> pos) {
        if (!Families.TryGetValue(block.Identifier, out Family family)) {
            return true;
        }

        BlockFace behind = family.Growth.Opposite();
        Vec3<int> attachedPos = pos.GetBlockTowards(behind);
        IBlock attached = world.GetBlock(attachedPos);

        if (family.Head == "minecraft:kelp"
            && world.IsInBlockTag(CannotSupportKelp, attached.Identifier)) {
            return false;
        }

        return IsPartOf(attached, family)
               || PlacementHelpers.FaceSturdy(world, attachedPos, family.Growth);
    }

    /// <summary>
    /// The half that converts. A body whose tip has gone becomes the head; a head that has grown a
    /// neighbour ahead of it becomes a body. Vanilla schedules the break for a plant that has lost
    /// its footing, which is the part with no equivalent here, so a severed stalk stays.
    /// <p/>
    /// The head has <b>two</b> paths into a body, and only one of them is told about the cell ahead.
    /// The other fires when the block <b>behind</b> changes: a head still standing but with its own
    /// plant now in front of it is a head in the middle of a stalk, and turns into one. Missing that
    /// leaves a growing tip buried inside the plant.
    /// <p/>
    /// <b>Documented divergence in the body's answer.</b> Vanilla converts a body with
    /// <c>headBlock.getStateForPlacement(random)</c>, ie. the head at <c>random.nextInt(25)</c>, and
    /// the head written here is the default age instead. It is the same choice
    /// <see cref="GetStateForPlacement"/> makes and for the same reason: there is no growth tick to
    /// consume an age. Vanilla's own client and server roll this separately in any case.
    /// </summary>
    public IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (!Families.TryGetValue(block.Identifier, out Family family)) {
            return block;
        }

        bool isHead = block.Identifier == family.Head;
        IBlock body = world.Registry.Blocks[family.Body];

        if (isHead && toNeighbour == family.Growth.Opposite() && CanSurvive(block, world, pos)
            && IsPartOf(world.GetBlock(pos.GetBlockTowards(family.Growth)), family)) {
            return CarryOver(block, body, family);
        }

        if (toNeighbour != family.Growth) {
            return block;
        }

        bool aheadIsPlant = IsPartOf(neighbourState, family);

        if (isHead && aheadIsPlant) {
            return CarryOver(block, body, family);
        }

        if (!isHead && !aheadIsPlant) {
            return CarryOver(block, world.Registry.Blocks[family.Head], family);
        }

        return block;
    }

    /// <summary>
    /// <c>updateBodyAfterConvertedFromHead</c> and <c>updateHeadAfterConvertedFromBody</c>. Both are
    /// the identity for three of the four families; cave vines override both to carry the
    /// <c>berries</c> flag across, so a stalk converting either way keeps its glow berries.
    /// </summary>
    private static IBlock CarryOver(IBlock from, IBlock to, Family family) {
        return family.Head == "minecraft:cave_vines"
            ? ((IBerried)to).WithBerries(((IBerried)from).Berries)
            : to;
    }


    private static bool IsPartOf(IBlock block, Family family) {
        return block.Identifier == family.Head || block.Identifier == family.Body;
    }
}

/// <summary>
/// <c>BambooStalkBlock</c>. Refuses water outright, and reads the bamboo around it to decide whether
/// what goes down is a stalk of age zero, a stalk of age one, or a shoot.
/// </summary>
public sealed class BambooStalkPlacementRule : IBlockPlacementRule {
    private static readonly Identifier SupportsBamboo = "minecraft:supports_bamboo";

    public BlockClass VanillaClass => BlockClass.BambooStalkBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IPlacementLevel world = context.World;
        Vec3<int> pos = context.PlacePos;

        // Any fluid at all refuses, not only a full one: bamboo will not go into a thinning flow.
        if (!FluidState.Of(world.GetBlock(pos)).IsEmpty) {
            return null;
        }

        IBlock below = world.GetBlock(pos.WithY(pos.Y - 1));
        if (!world.IsInBlockTag(SupportsBamboo, below.Identifier)) {
            return null;
        }

        if (IBlock.SimilarTo(below, Block.BambooSapling)) {
            return WithAge(block, 0);
        }

        if (IBlock.SimilarTo(below, block)) {
            // One stalk of leafless bamboo above a leafy one, so a hand planted stalk looks grown.
            return WithAge(block, below is IAged stalk && stalk.Age > 0 ? 1 : 0);
        }

        IBlock above = world.GetBlock(pos.WithY(pos.Y + 1));
        if (IBlock.SimilarTo(above, block)) {
            return WithAge(block, above is IAged stalk ? stalk.Age : 0);
        }

        return Block.BambooSapling;
    }

    public bool CanSurvive(IBlock block, IPlacementLevel world, Vec3<int> pos) {
        return world.IsInBlockTag(SupportsBamboo,
            world.GetBlock(pos.WithY(pos.Y - 1)).Identifier);
    }

    /// <summary>
    /// The one shape update is the age catching up with the stalk above, so a stalk grown from below
    /// thickens all the way up. Losing its footing schedules a break upstream, which is the part with
    /// no equivalent here.
    /// </summary>
    public IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (toNeighbour != BlockFace.PosY || !IBlock.SimilarTo(neighbourState, block)) {
            return block;
        }

        int age = block is IAged stalk ? stalk.Age : 0;
        int aboveAge = neighbourState is IAged above ? above.Age : 0;
        return aboveAge > age ? WithAge(block, (age + 1) % 2) : block;
    }

    private static IBlock WithAge(IBlock block, int age) {
        return block is IAged stalk ? stalk.WithAge(age) : block;
    }
}

/// <summary>
/// <c>MangrovePropaguleBlock</c>. A sapling that also hangs: the hanging form needs a mangrove leaf
/// above it, the standing form falls through to the sapling's own vegetation test.
/// <p/>
/// Placement always writes age four, the fully grown propagule, which is why one taken from a tree
/// and put back never looks like a bud.
/// </summary>
public sealed class MangrovePropagulePlacementRule : IBlockPlacementRule {
    private static readonly Identifier SupportsHanging = "minecraft:supports_hanging_mangrove_propagule";
    private static readonly Identifier SupportsPropagule = "minecraft:supports_mangrove_propagule";

    public BlockClass VanillaClass => BlockClass.MangrovePropaguleBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock state = PlacementHelpers.Waterlog(block, context);
        return state is IAged propagule ? propagule.WithAge(4) : state;
    }

    public bool CanSurvive(IBlock block, IPlacementLevel world, Vec3<int> pos) {
        if (block is IHanging { Hanging: true }) {
            return world.IsInBlockTag(SupportsHanging,
                world.GetBlock(pos.WithY(pos.Y + 1)).Identifier);
        }

        return world.IsInBlockTag(SupportsPropagule,
            world.GetBlock(pos.WithY(pos.Y - 1)).Identifier);
    }

    /// <summary>
    /// A hanging propagule dies when the leaf above it goes; a standing one dies whenever it cannot
    /// survive, through the vegetation rule it falls back to.
    /// </summary>
    public IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        // Vanilla's up branch and the sapling's own updateShape underneath it collapse to the same
        // answer, so both halves are this one line.
        return CanSurvive(block, world, pos) ? block : Block.Air;
    }
}

/// <summary>
/// <c>BigDripleafBlock</c>. Faces away from the placer unless it is being stacked on more dripleaf,
/// in which case it copies the facing of what is below so a column stays lined up.
/// </summary>
public sealed class BigDripleafPlacementRule : IBlockPlacementRule {
    private static readonly Identifier SupportsBigDripleaf = "minecraft:supports_big_dripleaf";

    public BlockClass VanillaClass => BlockClass.BigDripleafBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock below = context.World.GetBlock(context.PlacePos.WithY(context.PlacePos.Y - 1));
        bool onDripleaf = IBlock.SimilarTo(below, block)
                          || BlockClasses.Is(below.Identifier, BlockClass.BigDripleafStemBlock);

        // A source, not merely water, unlike most of the waterlog lines.
        IBlock state = block is IWaterlogged waterloggable
            ? waterloggable.WithWaterlogged(
                PlacementHelpers.IsWaterSourceAt(context.World, context.PlacePos))
            : block;

        Direction facing = onDripleaf && below is IHorizontalFacing stem
            ? stem.Facing
            : context.HorizontalDirection.Opposite();

        return state is IHorizontalFacing leaf ? leaf.WithFacing(facing) : state;
    }

    public bool CanSurvive(IBlock block, IPlacementLevel world, Vec3<int> pos) {
        IBlock below = world.GetBlock(pos.WithY(pos.Y - 1));
        return IBlock.SimilarTo(below, block)
               || BlockClasses.Is(below.Identifier, BlockClass.BigDripleafStemBlock)
               || world.IsInBlockTag(SupportsBigDripleaf, below.Identifier);
    }

    /// <summary>
    /// The leaf turns into a stem when another leaf is put above it, which is how a column of stems
    /// with one leaf on top gets built from the bottom.
    /// </summary>
    public IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (toNeighbour == BlockFace.NegY && !CanSurvive(block, world, pos)) {
            return Block.Air;
        }

        if (toNeighbour != BlockFace.PosY || !IBlock.SimilarTo(neighbourState, block)) {
            return block;
        }

        // withPropertiesOf: the stem keeps the leaf's facing and waterlogging.
        return world.Registry.Blocks["minecraft:big_dripleaf_stem"].WithState(block.ToStateNbt());
    }
}
