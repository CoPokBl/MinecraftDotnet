using Minecraft.Placement.Helpers;
using ManagedServer.Terrain.Data;
using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;
using Minecraft.Placement;

namespace ManagedServer.Terrain.Structures.Templates;

/// <summary>
/// One entry of a <c>rule</c> processor: three predicates and what to write when all three hold.
/// </summary>
/// <remarks>
/// The predicates are asked in order and Java short circuits, so a later one only draws when the
/// earlier ones passed. Several of them draw, which makes the order part of the world rather than a
/// detail.
/// </remarks>
public sealed record ProcessorRule(
    IRuleTest InputPredicate,
    IRuleTest LocationPredicate,
    IPosRuleTest PositionPredicate,
    uint OutputState,
    IRuleBlockEntityModifier BlockEntityModifier) {

    public bool Test(IFeatureLevel level, uint inputState, Vec3<int> inTemplate, Vec3<int> world,
        Vec3<int> reference, RandomSource random) {

        return InputPredicate.Test(inputState, world, random, level)
            && LocationPredicate.TestAgainstWorld(level, world, random)
            && PositionPredicate.Test(inTemplate, world, reference, random);
    }
}

/// <summary>
/// <c>RuleBlockEntityModifier</c>: what a matched rule does to the block entity tag it replaces.
/// </summary>
/// <remarks>
/// Nothing here reads a block entity's contents, so what these change is only whether a tag is present
/// at all, and <c>append_loot</c>'s draw. Both still matter: the presence is what decides whether a
/// loot seed is drawn when the block goes down, and skipping a draw moves everything after it.
/// </remarks>
public interface IRuleBlockEntityModifier {
    CompoundTag? Apply(RandomSource random, CompoundTag? existing);

    public sealed class Passthrough : IRuleBlockEntityModifier {
        public static readonly Passthrough Instance = new();

        public CompoundTag? Apply(RandomSource random, CompoundTag? existing) => existing;
    }

    public sealed class Clear : IRuleBlockEntityModifier {
        public static readonly Clear Instance = new();

        public CompoundTag Apply(RandomSource random, CompoundTag? existing) => new();
    }

    public sealed class AppendLoot(Identifier lootTable) : IRuleBlockEntityModifier {
        public Identifier LootTable => lootTable;

        public CompoundTag Apply(RandomSource random, CompoundTag? existing) {
            CompoundTag result = existing ?? new CompoundTag();
            return result.WithChild("LootTableSeed", new LongTag(random.NextLong()));
        }
    }

}

/// <summary>
/// <c>RuleProcessor</c>: the general replacement, and 35 of the 41 processors the vanilla lists use.
/// </summary>
/// <remarks>
/// <b>The random is per position and not the placement's.</b> <c>RandomSource.create(Mth.getSeed(pos))</c>
/// is a fresh sequence seeded from where the block landed, so the rules answer the same way however
/// many blocks came before and whichever chunk is being written. That is what lets a piece straddling
/// a border crack the same bricks in both halves.
/// </remarks>
public sealed class RuleProcessor(IReadOnlyList<ProcessorRule> rules) : IStructureProcessor {
    public TemplateBlockInfo? ProcessBlock(IFeatureLevel level, Vec3<int> targetPosition,
        Vec3<int> referencePos, Vec3<int> templateRelativePos, TemplateBlockInfo block,
        StructurePlaceSettings settings) {

        RandomSource random = new LegacyRandomSource(
            Mth.GetSeed(block.Pos.X, block.Pos.Y, block.Pos.Z));

        foreach (ProcessorRule rule in rules) {
            if (!rule.Test(level, block.StateId, templateRelativePos, block.Pos, referencePos,
                random)) {

                continue;
            }

            return new TemplateBlockInfo(block.Pos, rule.OutputState,
                rule.BlockEntityModifier.Apply(random, block.Nbt));
        }

        return block;
    }
}

/// <summary>
/// <c>ProtectedBlockProcessor</c>: leaves what is already there where it is one of a named set.
/// </summary>
/// <remarks>
/// The test is on the <b>world</b> block rather than the template's, so this is a structure declining
/// to overwrite something rather than declining to place something. The seven vanilla lists that use
/// it all protect <c>features_cannot_replace</c>, which is what stops a village path eating a portal
/// frame.
/// </remarks>
public sealed class ProtectedBlockProcessor(Identifier cannotReplaceTag) : IStructureProcessor {
    public TemplateBlockInfo? ProcessBlock(IFeatureLevel level, Vec3<int> targetPosition,
        Vec3<int> referencePos, Vec3<int> templateRelativePos, TemplateBlockInfo block,
        StructurePlaceSettings settings) {

        uint existing = level.GetState(block.Pos.X, block.Pos.Y, block.Pos.Z);

        return level.Blocks.IsIn(cannotReplaceTag, existing) ? null : block;
    }
}

/// <summary>
/// <c>BlockRotProcessor</c>: drops blocks at random, which is what makes a ruin a ruin.
/// </summary>
/// <remarks>
/// <b>The comparison is not the obvious way round.</b> A block is kept when the draw is at or below
/// the integrity, so an integrity of one keeps everything and of zero keeps almost nothing. And a
/// block outside the rottable set is kept <b>without drawing</b>, so adding a set changes how many
/// numbers the placement consumes as well as what it keeps.
/// <p/>
/// The random is the placement's rather than a fresh one, so a piece rots differently each time the
/// structure is laid out but the same way for a given seed.
/// </remarks>
public sealed class BlockRotProcessor(Identifier? rottableTag, float integrity)
    : IStructureProcessor {

    public TemplateBlockInfo? ProcessBlock(IFeatureLevel level, Vec3<int> targetPosition,
        Vec3<int> referencePos, Vec3<int> templateRelativePos, TemplateBlockInfo block,
        StructurePlaceSettings settings) {

        RandomSource random = settings.RandomFor(block.Pos);

        bool rottable = rottableTag is null
            || level.Blocks.IsIn(rottableTag.Value, block.StateId);

        return rottable && !(random.NextFloat() <= integrity) ? null : block;
    }
}

/// <summary>
/// <c>CappedProcessor</c>: runs another processor over at most a drawn number of the piece's blocks.
/// </summary>
/// <remarks>
/// The count is over the <b>whole piece</b>, which is why this is the one processor that
/// <see cref="IStructureProcessor.EvaluatesEntirePieceState"/> is true for: choosing five blocks out
/// of a piece has to choose from all of it, not from the part that fell in this chunk.
/// <p/>
/// Only an <b>altered</b> block counts against the limit, so a delegate that answers the block
/// unchanged spends an index without spending a replacement. That is what makes the four vanilla
/// lists using this replace up to their limit rather than exactly it.
/// </remarks>
public sealed class CappedProcessor(IStructureProcessor delegated, IIntProvider limit)
    : IStructureProcessor {

    public bool EvaluatesEntirePieceState => true;

    public List<TemplateBlockInfo> FinalizeProcessing(IFeatureLevel level, Vec3<int> position,
        Vec3<int> referencePos, IReadOnlyList<TemplateBlockInfo> original,
        List<TemplateBlockInfo> processed, StructurePlaceSettings settings) {

        if (limit.MaxInclusive == 0 || processed.Count == 0
            || original.Count != processed.Count) {

            return processed;
        }

        RandomSource random = new LegacyRandomSource(level.Seed).ForkPositional()
            .At(position.X, position.Y, position.Z);

        int maxToReplace = Math.Min(limit.Sample(random), processed.Count);

        if (maxToReplace < 1) {
            return processed;
        }

        List<int> indices = [..Enumerable.Range(0, processed.Count)];
        StructurePiece.Shuffle(indices, random);

        int replaced = 0;

        foreach (int index in indices) {
            if (replaced >= maxToReplace) {
                break;
            }

            TemplateBlockInfo? altered = delegated.ProcessBlock(level, position, referencePos,
                original[index].Pos, processed[index], settings);

            if (altered is null || altered.Value.Equals(processed[index])) {
                continue;
            }

            replaced++;
            processed[index] = altered.Value;
        }

        return processed;
    }

}

/// <summary>
/// <c>BlockIgnoreProcessor</c>: drops the named blocks outright, and the commonest processor a piece
/// adds in code.
/// </summary>
/// <remarks>
/// The two that matter are the structure block, which is only ever a data marker and must never be
/// written, and air: dropping air is what makes a template sit <b>into</b> the terrain rather than
/// carving a box out of it.
/// </remarks>
public sealed class BlockIgnoreProcessor(params Identifier[] toIgnore) : IStructureProcessor {
    public static readonly BlockIgnoreProcessor StructureBlock =
        new(Block.StructureBlock.Identifier);

    public static readonly BlockIgnoreProcessor Air = new(Block.Air.Identifier);

    public static readonly BlockIgnoreProcessor StructureAndAir =
        new(Block.Air.Identifier, Block.StructureBlock.Identifier);

    public TemplateBlockInfo? ProcessBlock(IFeatureLevel level, Vec3<int> targetPosition,
        Vec3<int> referencePos, Vec3<int> templateRelativePos, TemplateBlockInfo block,
        StructurePlaceSettings settings) {

        Identifier id = level.Registry.Blocks.GetByStateId(block.StateId).Identifier;

        return toIgnore.Contains(id) ? null : block;
    }
}

/// <summary>
/// <c>GravityProcessor</c>: drops every block of the piece onto the terrain, keeping its height inside
/// the template.
/// </summary>
/// <remarks>
/// This is what makes a ruined portal follow the ground it landed on rather than standing on a shelf.
/// The offset added to the template's own y is read from the <b>template relative</b> position, so a
/// block two above the template's floor stays two above wherever the column it is over turned out to
/// be.
/// <p/>
/// Vanilla swaps the two worldgen heightmaps for their live counterparts on a real level. This runs
/// during generation, where the <c>_WG</c> pair is the raw terrain surface and is what is wanted, so
/// the heightmap is used as named.
/// </remarks>
public sealed class GravityProcessor(HeightmapType heightmap, int offset) : IStructureProcessor {
    public TemplateBlockInfo? ProcessBlock(IFeatureLevel level, Vec3<int> targetPosition,
        Vec3<int> referencePos, Vec3<int> templateRelativePos, TemplateBlockInfo block,
        StructurePlaceSettings settings) {

        int height = level.GetHeight(heightmap, block.Pos.X, block.Pos.Z) + offset;

        return block with {
            Pos = new Vec3<int>(block.Pos.X, height + templateRelativePos.Y, block.Pos.Z)
        };
    }
}

/// <summary>
/// <c>LavaSubmergedBlockProcessor</c>: puts the lava back around anything that does not fill its cell.
/// </summary>
/// <remarks>
/// The shape read is the <b>outline</b>, so a slab or a stair written into a lava lake is replaced by
/// lava rather than leaving an air pocket around itself, and a full cube keeps the block.
/// </remarks>
public sealed class LavaSubmergedBlockProcessor : IStructureProcessor {
    public static readonly LavaSubmergedBlockProcessor Instance = new();

    public TemplateBlockInfo? ProcessBlock(IFeatureLevel level, Vec3<int> targetPosition,
        Vec3<int> referencePos, Vec3<int> templateRelativePos, TemplateBlockInfo block,
        StructurePlaceSettings settings) {

        uint existing = level.GetState(block.Pos.X, block.Pos.Y, block.Pos.Z);

        bool wasLava = level.Registry.Blocks.GetByStateId(existing).Identifier
            .Equals(Block.Lava.Identifier);

        if (!wasLava) {
            return block;
        }

        IBlock placed = level.Registry.Blocks.GetByStateId(block.StateId);

        return ShapeSupport.IsShapeFullBlock(placed.BlockShape)
            ? block
            : block with { StateId = Block.Lava.StateId };
    }
}

/// <summary>
/// <c>BlackstoneReplaceProcessor</c>: the stone half of a template swapped for blackstone, which is
/// how one ruined portal template serves both dimensions.
/// </summary>
/// <remarks>
/// The replacement keeps only the three properties named upstream, so a mossy cobblestone <b>wall</b>
/// loses its connections and comes out as a default blackstone wall. That is vanilla, and the shape
/// cascade would have settled it there; there is none here, so the wall stays as the default.
/// </remarks>
public sealed class BlackstoneReplaceProcessor : IStructureProcessor {
    public static readonly BlackstoneReplaceProcessor Instance = new();

    private static readonly Dictionary<Identifier, IBlock> Replacements = new() {
        [Block.Cobblestone.Identifier] = Block.Blackstone,
        [Block.MossyCobblestone.Identifier] = Block.Blackstone,
        [Block.Stone.Identifier] = Block.PolishedBlackstone,
        [Block.StoneBricks.Identifier] = Block.PolishedBlackstoneBricks,
        [Block.MossyStoneBricks.Identifier] = Block.PolishedBlackstoneBricks,
        [Block.CobblestoneStairs.Identifier] = Block.BlackstoneStairs,
        [Block.MossyCobblestoneStairs.Identifier] = Block.BlackstoneStairs,
        [Block.StoneStairs.Identifier] = Block.PolishedBlackstoneStairs,
        [Block.StoneBrickStairs.Identifier] = Block.PolishedBlackstoneBrickStairs,
        [Block.MossyStoneBrickStairs.Identifier] = Block.PolishedBlackstoneBrickStairs,
        [Block.CobblestoneSlab.Identifier] = Block.BlackstoneSlab,
        [Block.MossyCobblestoneSlab.Identifier] = Block.BlackstoneSlab,
        [Block.SmoothStoneSlab.Identifier] = Block.PolishedBlackstoneSlab,
        [Block.StoneSlab.Identifier] = Block.PolishedBlackstoneSlab,
        [Block.StoneBrickSlab.Identifier] = Block.PolishedBlackstoneBrickSlab,
        [Block.MossyStoneBrickSlab.Identifier] = Block.PolishedBlackstoneBrickSlab,
        [Block.StoneBrickWall.Identifier] = Block.PolishedBlackstoneBrickWall,
        [Block.MossyStoneBrickWall.Identifier] = Block.PolishedBlackstoneBrickWall,
        [Block.CobblestoneWall.Identifier] = Block.BlackstoneWall,
        [Block.MossyCobblestoneWall.Identifier] = Block.BlackstoneWall,
        [Block.ChiseledStoneBricks.Identifier] = Block.ChiseledPolishedBlackstone,
        [Block.CrackedStoneBricks.Identifier] = Block.CrackedPolishedBlackstoneBricks,
        [Block.IronBars.Identifier] = Block.IronChain
    };

    public TemplateBlockInfo? ProcessBlock(IFeatureLevel level, Vec3<int> targetPosition,
        Vec3<int> referencePos, Vec3<int> templateRelativePos, TemplateBlockInfo block,
        StructurePlaceSettings settings) {

        IBlock old = level.Registry.Blocks.GetByStateId(block.StateId);

        if (!Replacements.TryGetValue(old.Identifier, out IBlock? replacement)) {
            return block;
        }

        if (old is IHorizontalFacing facing && replacement is IHorizontalFacing) {
            replacement = (IBlock)((IHorizontalFacing)replacement).WithFacing(facing.Facing);
        }

        if (old is IHalved half && replacement is IHalved) {
            replacement = ((IHalved)replacement).WithHalf(half.Half);
        }

        if (old is ISlabTyped slab && replacement is ISlabTyped) {
            replacement = ((ISlabTyped)replacement).WithType(slab.Type);
        }

        return block with { StateId = replacement.StateId };
    }
}

/// <summary>
/// <c>BlockAgeProcessor</c>: cracks, mosses and breaks up stonework, which is the whole look of an
/// ocean ruin.
/// </summary>
/// <remarks>
/// Every branch draws before it decides, and several draw twice, so the number of blocks the piece
/// consumes from its random depends on what it is made of.
/// <p/>
/// The two replacement lists for a full stone block are built <b>before</b> the mossiness roll picks
/// between them, so the stair variant's facing and half are drawn either way. That is upstream's own
/// evaluation order and moving the roll first changes every ruin.
/// </remarks>
public sealed class BlockAgeProcessor(float mossiness) : IStructureProcessor {
    private const float ReplaceFullBlockChance = 0.5f;
    private const float ReplaceStairsChance = 0.5f;
    private const float ReplaceObsidianChance = 0.15f;

    private static readonly Identifier StairsTag = "minecraft:stairs";
    private static readonly Identifier SlabsTag = "minecraft:slabs";
    private static readonly Identifier WallsTag = "minecraft:walls";

    public TemplateBlockInfo? ProcessBlock(IFeatureLevel level, Vec3<int> targetPosition,
        Vec3<int> referencePos, Vec3<int> templateRelativePos, TemplateBlockInfo block,
        StructurePlaceSettings settings) {

        RandomSource random = settings.RandomFor(block.Pos);
        IBlock state = level.Registry.Blocks.GetByStateId(block.StateId);
        Identifier id = state.Identifier;

        uint? replacement;

        if (id.Equals(Block.StoneBricks.Identifier) || id.Equals(Block.Stone.Identifier)
            || id.Equals(Block.ChiseledStoneBricks.Identifier)) {

            replacement = MaybeReplaceFullStoneBlock(random);
        } else if (level.Blocks.IsIn(StairsTag, block.StateId)) {
            replacement = MaybeReplaceStairs(state, random);
        } else if (level.Blocks.IsIn(SlabsTag, block.StateId)) {
            replacement = MaybeReplaceSlab(state, random);
        } else if (level.Blocks.IsIn(WallsTag, block.StateId)) {
            replacement = MaybeReplaceWall(state, random);
        } else if (id.Equals(Block.Obsidian.Identifier)) {
            replacement = MaybeReplaceObsidian(random);
        } else {
            replacement = null;
        }

        return replacement is null ? block : block with { StateId = replacement.Value };
    }

    private uint? MaybeReplaceFullStoneBlock(RandomSource random) {
        if (random.NextFloat() >= ReplaceFullBlockChance) {
            return null;
        }

        uint[] plain = [
            Block.CrackedStoneBricks.StateId,
            RandomFacingStairs(random, Block.StoneBrickStairs)
        ];

        uint[] mossy = [
            Block.MossyStoneBricks.StateId,
            RandomFacingStairs(random, Block.MossyStoneBrickStairs)
        ];

        return PickBlock(random, plain, mossy);
    }

    private uint? MaybeReplaceStairs(IBlock state, RandomSource random) {
        if (random.NextFloat() >= ReplaceStairsChance) {
            return null;
        }

        uint[] mossy = [
            WithSameShape(Block.MossyStoneBrickStairs, state),
            Block.MossyStoneBrickSlab.StateId
        ];

        return PickBlock(random, NonMossyReplacements, mossy);
    }

    private uint? MaybeReplaceSlab(IBlock state, RandomSource random) {
        return random.NextFloat() < mossiness
            ? WithSameShape(Block.MossyStoneBrickSlab, state)
            : null;
    }

    private uint? MaybeReplaceWall(IBlock state, RandomSource random) {
        return random.NextFloat() < mossiness
            ? WithSameShape(Block.MossyStoneBrickWall, state)
            : null;
    }

    private static uint? MaybeReplaceObsidian(RandomSource random) {
        return random.NextFloat() < ReplaceObsidianChance ? Block.CryingObsidian.StateId : null;
    }

    private static readonly uint[] NonMossyReplacements =
        [Block.StoneSlab.StateId, Block.StoneBrickSlab.StateId];

    private uint PickBlock(RandomSource random, uint[] plain, uint[] mossy) {
        uint[] from = random.NextFloat() < mossiness ? mossy : plain;
        return from[random.NextInt(from.Length)];
    }

    /// <summary>
    /// A stair facing a drawn way and in a drawn half, which is two draws in a fixed order.
    /// </summary>
    private static uint RandomFacingStairs(RandomSource random, IBlock stairs) {
        IBlock facing = ((IHorizontalFacing)stairs).WithFacing(
            Directions.Horizontal[random.NextInt(Directions.Horizontal.Length)].ToDirection());

        TopBottom half = random.NextInt(2) == 0 ? TopBottom.Top : TopBottom.Bottom;

        return ((IHalved)facing).WithHalf(half).StateId;
    }

    /// <summary>
    /// <c>Block.withPropertiesOf</c> narrowed to the shape properties these replacements share.
    /// </summary>
    /// <remarks>
    /// Upstream copies every property the two blocks have in common. Stairs, slabs and walls are the
    /// only three families this is called for, so it copies exactly what those carry.
    /// </remarks>
    private static uint WithSameShape(IBlock replacement, IBlock old) {
        IBlock result = replacement;

        if (old is IHorizontalFacing facing && result is IHorizontalFacing) {
            result = ((IHorizontalFacing)result).WithFacing(facing.Facing);
        }

        if (old is IHalved half && result is IHalved) {
            result = ((IHalved)result).WithHalf(half.Half);
        }

        if (old is IStairShaped shape && result is IStairShaped) {
            result = ((IStairShaped)result).WithShape(shape.Shape);
        }

        if (old is ISlabTyped slab && result is ISlabTyped) {
            result = ((ISlabTyped)result).WithType(slab.Type);
        }

        if (old is IWallConnected wall && result is IWallConnected connected) {
            foreach (BlockFace face in Directions.Horizontal) {
                connected = (IWallConnected)connected.WithSide(face, wall.Side(face));
            }

            result = connected;
        }

        if (old is IWaterlogged waterlogged && result is IWaterlogged) {
            result = ((IWaterlogged)result).WithWaterlogged(waterlogged.Waterlogged);
        }

        return result.StateId;
    }
}

/// <summary>
/// <c>JigsawReplacementProcessor</c>: turns a jigsaw block into whatever it said it should become.
/// </summary>
/// <remarks>
/// Every single pool element adds this, and it is what makes a village door frame a door frame rather
/// than a wall of jigsaw blocks. The state comes out of the block entity tag's <c>final_state</c>,
/// which is a <b>block state string</b> and not the NBT form the palette uses, so it goes through
/// <see cref="BlockStateStrings"/>.
/// <p/>
/// A jigsaw whose final state is structure void is <b>dropped</b> rather than written, which is what
/// lets a piece leave a hole where it joins another.
/// </remarks>
public sealed class JigsawReplacementProcessor : IStructureProcessor {
    public static readonly JigsawReplacementProcessor Instance = new();

    public TemplateBlockInfo? ProcessBlock(IFeatureLevel level, Vec3<int> targetPosition,
        Vec3<int> referencePos, Vec3<int> templateRelativePos, TemplateBlockInfo block,
        StructurePlaceSettings settings) {

        if (!level.Registry.Blocks.GetByStateId(block.StateId).Identifier
            .Equals(Block.Jigsaw.Identifier)) {

            return block;
        }

        if (block.Nbt is null) {
            return block;
        }

        string written = block.Nbt.Contains("final_state")
            ? block.Nbt["final_state"].GetString()
            : "minecraft:air";

        uint state = BlockStateStrings.Parse(level.Registry, written);

        return level.Registry.Blocks.GetByStateId(state).Identifier
            .Equals(Block.StructureVoid.Identifier)
            ? null
            : new TemplateBlockInfo(block.Pos, state, null);
    }
}

/// <summary>
/// <c>NopProcessor</c>: does nothing, and exists so that a processor list can name one.
/// </summary>
public sealed class NopProcessor : IStructureProcessor {
    public static readonly NopProcessor Instance = new();
}
