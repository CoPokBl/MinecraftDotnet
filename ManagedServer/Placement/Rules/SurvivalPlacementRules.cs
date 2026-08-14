using ManagedServer.Fluids;
using ManagedServer.Placement.Helpers;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Placement.Rules;

//
// The classes that override canSurvive and nothing about the state they are placed in.
//
// They are rules for the reason CLAUDE.md gives: a missing canSurvive reads as permissive
// rather than as unimplemented, so the block goes down, the client draws it, and it stays. Every one
// of these asks a materially different question, which is why they are separate transcriptions and
// not one "needs something below it" helper.
//
// Several of them also override updateShape to do nothing but schedule a tick. There is no
// block tick scheduler here, so those have no UpdateShape: the shape hook itself returns the
// state unchanged upstream too, and inventing an immediate break would be a divergence in the other
// direction. A cactus with its sand mined stays put until something writes over it.
//
// The VegetationBlock family is next door in VegetationPlacementRules.cs, because its
// members differ in mayPlaceOn rather than in canSurvive and that is a different shape
// of transcription.
//

/// <summary>
/// <c>BaseTorchBlock</c>: the standing torch, the soul torch and the redstone torch. The centre
/// column of the face below, which is why a torch stands on a fence post and not on a bottom slab.
/// </summary>
public sealed class BaseTorchPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.BaseTorchBlock;

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return PlacementHelpers.SupportsCenter(world, pos.WithY(pos.Y - 1), BlockFace.PosY);
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return toNeighbour == BlockFace.NegY && !CanSurvive(block, world, pos) ? Block.Air : block;
    }
}

/// <summary>
/// <c>BasePressurePlateBlock</c>. Either support question will do: the rigid frame a rail wants
/// <b>or</b> the centre column a torch wants. That is wider than both, so a plate goes on a fence
/// post and on a hopper alike.
/// </summary>
public sealed class BasePressurePlatePlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.BasePressurePlateBlock;

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        Vec3<int> below = pos.WithY(pos.Y - 1);
        return PlacementHelpers.SupportsRigid(world, below)
               || PlacementHelpers.SupportsCenter(world, below, BlockFace.PosY);
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return toNeighbour == BlockFace.NegY && !CanSurvive(block, world, pos) ? Block.Air : block;
    }
}

/// <summary>
/// <c>CarpetBlock</c>. The weakest survival test in the game: anything at all below, air excepted.
/// No shape, no tag, no solidity, so a carpet lies on a torch.
/// </summary>
public sealed class CarpetPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.CarpetBlock;

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return !world.GetBlock(pos.WithY(pos.Y - 1)).Air;
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return CanSurvive(block, world, pos) ? block : Block.Air;
    }
}

/// <summary>
/// <c>CakeBlock</c> and <c>CandleCakeBlock</c>, which have the same body: plain <c>isSolid()</c>
/// below, like a standing sign.
/// </summary>
public sealed class CakePlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.CakeBlock;

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return world.GetBlock(pos.WithY(pos.Y - 1)).Solid;
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return toNeighbour == BlockFace.NegY && !CanSurvive(block, world, pos) ? Block.Air : block;
    }
}

/// <summary>
/// <c>CandleCakeBlock</c>. Not a subclass of <c>CakeBlock</c> upstream despite the identical body, so
/// it cannot reach that rule through the class chain and needs its own.
/// </summary>
public sealed class CandleCakePlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.CandleCakeBlock;

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return world.GetBlock(pos.WithY(pos.Y - 1)).Solid;
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return toNeighbour == BlockFace.NegY && !CanSurvive(block, world, pos) ? Block.Air : block;
    }
}

/// <summary>
/// <c>GrindstoneBlock</c>. Overrides <c>canSurvive</c> to <b>true</b>, so it does not fall off the
/// wall it was hung on. Without this rule it would inherit
/// <see cref="FaceAttachedPlacementRule"/>'s and a grindstone would be unplaceable in mid air and
/// would break when its wall went.
/// <p/>
/// Its <c>getStateForPlacement</c> is still the inherited one, so this delegates rather than
/// repeating it.
/// </summary>
public sealed class GrindstonePlacementRule : IBlockPlacementRule {
    private static readonly FaceAttachedPlacementRule Attached = new();

    public BlockClass VanillaClass => BlockClass.GrindstoneBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return Attached.GetStateForPlacement(block, context);
    }
}

/// <summary>
/// <c>CactusBlock</c>. Nothing solid and no lava beside it on any of the four horizontals, sand or
/// another cactus below, and nothing liquid above.
/// </summary>
public sealed class CactusPlacementRule : IBlockPlacementRule {
    private static readonly Identifier SupportsCactus = "minecraft:supports_cactus";

    public BlockClass VanillaClass => BlockClass.CactusBlock;

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        foreach (BlockFace face in Directions.Horizontal) {
            IBlock neighbour = world.GetBlock(pos.GetBlockTowards(face));
            if (neighbour.Solid || FluidState.Of(neighbour).Kind == FluidKind.Lava) {
                return false;
            }
        }

        IBlock below = world.GetBlock(pos.WithY(pos.Y - 1));
        bool rooted = IBlock.SimilarTo(below, block)
                      || PlacementHelpers.InTag(world.Server.Registry, SupportsCactus, below.Identifier);
        return rooted && !world.GetBlock(pos.WithY(pos.Y + 1)).Liquid;
    }
}

/// <summary>
/// <c>SugarCaneBlock</c>. Another cane below, or a supporting block below with water beside
/// <b>that</b> block rather than beside the cane, which is why a cane grows one block back from the
/// water's edge and no further.
/// </summary>
public sealed class SugarCanePlacementRule : IBlockPlacementRule {
    private static readonly Identifier SupportsSugarCane = "minecraft:supports_sugar_cane";
    private static readonly Identifier SupportsAdjacently = "minecraft:supports_sugar_cane_adjacently";

    public BlockClass VanillaClass => BlockClass.SugarCaneBlock;

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        Vec3<int> belowPos = pos.WithY(pos.Y - 1);
        IBlock below = world.GetBlock(belowPos);
        if (IBlock.SimilarTo(below, block)) {
            return true;
        }

        if (!PlacementHelpers.InTag(world.Server.Registry, SupportsSugarCane, below.Identifier)) {
            return false;
        }

        foreach (BlockFace face in Directions.Horizontal) {
            IBlock beside = world.GetBlock(belowPos.GetBlockTowards(face));

            // The fluid half is FluidTags.SUPPORTS_SUGAR_CANE_ADJACENTLY, whose only entry is
            // #minecraft:water, ie. the source and the flow. That is exactly FluidKind.Water, so this
            // is a transcription rather than an approximation. There is no fluid tag registry to ask.
            if (FluidState.Of(beside).Kind == FluidKind.Water) {
                return true;
            }

            if (PlacementHelpers.InTag(world.Server.Registry, SupportsAdjacently, beside.Identifier)) {
                return true;
            }
        }

        return false;
    }
}

/// <summary>
/// <c>SporeBlossomBlock</c>. Hangs from the centre column above, and refuses to be underwater.
/// </summary>
public sealed class SporeBlossomPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.SporeBlossomBlock;

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return PlacementHelpers.SupportsCenter(world, pos.WithY(pos.Y + 1), BlockFace.NegY)
               && !PlacementHelpers.IsWaterAt(world, pos);
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return toNeighbour == BlockFace.PosY && !CanSurvive(block, world, pos) ? Block.Air : block;
    }
}

/// <summary>
/// <c>HangingMossBlock</c>. Hangs off a full face above, or off more hanging moss, and carries a
/// <c>tip</c> flag that is on when nothing of its own kind hangs below it.
/// </summary>
public sealed class HangingMossPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.HangingMossBlock;

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        Vec3<int> above = pos.WithY(pos.Y + 1);
        return PlacementHelpers.CanAttachTo(world, pos, BlockFace.PosY)
               || IBlock.SimilarTo(world.GetBlock(above), block);
    }

    /// <summary>
    /// Vanilla schedules the break and returns the retipped state, so the tip flag is recomputed on
    /// every neighbour change whether or not the moss can survive. Only the scheduling is missing.
    /// </summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        bool tip = !IBlock.SimilarTo(world.GetBlock(pos.WithY(pos.Y - 1)), block);
        return block is ITipped strand ? strand.WithTip(tip) : block;
    }
}

/// <summary>
/// <c>FrogspawnBlock</c>. Floats on water: the cell below is water, and the cell above is empty of
/// fluid, so spawn cannot be laid at the bottom of a pool or halfway up one.
/// </summary>
public sealed class FrogspawnPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.FrogspawnBlock;

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        Vec3<int> below = pos.WithY(pos.Y - 1);

        // FluidTags.SUPPORTS_FROGSPAWN holds minecraft:water alone, and the block tag beside it is
        // empty in 26.2, so the whole question is whether the cell below holds water.
        bool onWater = FluidState.Of(world.GetBlock(below)).Kind == FluidKind.Water;
        return onWater && FluidState.Of(world.GetBlock(pos)).IsEmpty;
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return CanSurvive(block, world, pos) ? block : Block.Air;
    }
}

/// <summary>
/// <c>ChorusFlowerBlock</c>. Either it is rooted, on chorus plant or end stone, or it is floating in
/// air with exactly one chorus plant beside it and nothing else touching it at all.
/// </summary>
public sealed class ChorusFlowerPlacementRule : IBlockPlacementRule {
    private static readonly Identifier SupportsChorusFlower = "minecraft:supports_chorus_flower";

    public BlockClass VanillaClass => BlockClass.ChorusFlowerBlock;

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        IBlock below = world.GetBlock(pos.WithY(pos.Y - 1));
        if (IsPlant(below) || PlacementHelpers.InTag(world.Server.Registry, SupportsChorusFlower, below.Identifier)) {
            return true;
        }

        if (!below.Air) {
            return false;
        }

        bool oneNeighbour = false;
        foreach (BlockFace face in Directions.Horizontal) {
            IBlock neighbour = world.GetBlock(pos.GetBlockTowards(face));
            if (IsPlant(neighbour)) {
                if (oneNeighbour) {
                    return false;
                }

                oneNeighbour = true;
            }
            else if (!neighbour.Air) {
                return false;
            }
        }

        return oneNeighbour;
    }

    private static bool IsPlant(IBlock block) {
        return BlockClasses.Is(block.Identifier, BlockClass.ChorusPlantBlock);
    }
}

/// <summary>
/// <c>BambooSaplingBlock</c>. The <c>supports_bamboo</c> tag below, and the one shape update that
/// grows a shoot into a stalk when bamboo appears above it.
/// </summary>
public sealed class BambooSaplingPlacementRule : IBlockPlacementRule {
    private static readonly Identifier SupportsBamboo = "minecraft:supports_bamboo";

    public BlockClass VanillaClass => BlockClass.BambooSaplingBlock;

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return PlacementHelpers.InTag(world.Server.Registry, SupportsBamboo,
            world.GetBlock(pos.WithY(pos.Y - 1)).Identifier);
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (!CanSurvive(block, world, pos)) {
            return Block.Air;
        }

        return toNeighbour == BlockFace.PosY && IBlock.SimilarTo(neighbourState, Block.Bamboo)
            ? Block.Bamboo
            : block;
    }
}

/// <summary>
/// <c>BigDripleafStemBlock</c>. Held at both ends: something that supports a dripleaf below, and the
/// leaf or more stem above.
/// <p/>
/// It is also one of the two blocks with a <c>waterlogged</c> property that deliberately do not
/// waterlog when placed, so it has no <c>GetStateForPlacement</c> here on purpose.
/// </summary>
public sealed class BigDripleafStemPlacementRule : IBlockPlacementRule {
    private static readonly Identifier SupportsBigDripleaf = "minecraft:supports_big_dripleaf";

    public BlockClass VanillaClass => BlockClass.BigDripleafStemBlock;

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        IBlock below = world.GetBlock(pos.WithY(pos.Y - 1));
        IBlock above = world.GetBlock(pos.WithY(pos.Y + 1));

        bool rooted = IBlock.SimilarTo(below, block)
                      || PlacementHelpers.InTag(world.Server.Registry, SupportsBigDripleaf, below.Identifier);
        bool topped = IBlock.SimilarTo(above, block)
                      || BlockClasses.Is(above.Identifier, BlockClass.BigDripleafBlock);
        return rooted && topped;
    }
}
