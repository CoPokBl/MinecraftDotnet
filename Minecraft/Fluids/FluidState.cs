using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;

namespace Minecraft.Fluids;

/// <summary>
/// Vanilla's <c>FluidState</c>: how much fluid sits in a block and whether it is falling.
/// <p/>
/// The world only ever stores the legacy <c>level</c> property of a water or lava block, which packs
/// the amount and the falling flag into one number and cannot represent everything a fluid state can
/// (a source and <c>getFlowing(8, false)</c> both round trip to different levels). Conversion goes
/// through <see cref="ToLegacyLevel"/> and <see cref="FromLegacyLevel"/>, which are
/// <c>FlowingFluid.getLegacyLevel</c> and <c>LiquidBlock</c>'s state cache respectively.
/// </summary>
/// <param name="Source">
/// Whether this is the source form of the fluid. Not derivable from <paramref name="Amount"/>: a
/// falling flowing fluid is also full.
/// </param>
/// <param name="Amount">Ninths of a block, 1 to 8.</param>
public readonly record struct FluidState(FluidKind Kind, bool Source, int Amount, bool Falling) {
    public static readonly FluidState Empty = new(FluidKind.Empty, false, 0, false);

    public bool IsEmpty => Kind == FluidKind.Empty;

    /// <summary><c>FluidState.getOwnHeight</c>: how tall this state is on its own.</summary>
    public float OwnHeight => Amount / 9f;

    /// <summary><c>Fluid.isSame</c>: source and flowing water are the same fluid.</summary>
    public bool IsSame(FluidKind other) => Kind != FluidKind.Empty && Kind == other;

    public static FluidState Flowing(FluidKind kind, int amount, bool falling) => new(kind, false, amount, falling);

    public static FluidState SourceOf(FluidKind kind, bool falling) => new(kind, true, 8, falling);

    /// <summary><c>FlowingFluid.getLegacyLevel</c>.</summary>
    public int ToLegacyLevel => Source ? 0 : 8 - Math.Min(Amount, 8) + (Falling ? 8 : 0);

    /// <summary><c>LiquidBlock.getFluidState</c>, which reads the same cache back out.</summary>
    public static FluidState FromLegacyLevel(FluidKind kind, int level) {
        int index = Math.Min(level, 8);
        return index switch {
            0 => SourceOf(kind, false),
            8 => Flowing(kind, 8, true),
            _ => Flowing(kind, 8 - index, false)
        };
    }

    /// <summary><c>BlockState.getFluidState</c>.</summary>
    public static FluidState Of(IBlock block) {
        return block switch {
            WaterBlock water => FromLegacyLevel(FluidKind.Water, water.Level),
            LavaBlock lava => FromLegacyLevel(FluidKind.Lava, lava.Level),
            // Everything else that carries a fluid is waterlogged, and waterlogging only holds a source.
            _ => block.Fluid == null ? Empty : SourceOf(FluidKind.Water, false)
        };
    }

    /// <summary><c>FluidState.createLegacyBlock</c>.</summary>
    public IBlock ToBlock() {
        return Kind switch {
            FluidKind.Water => Block.Water with { Level = ToLegacyLevel },
            FluidKind.Lava => Block.Lava with { Level = ToLegacyLevel },
            _ => Block.Air
        };
    }
}
