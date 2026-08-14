using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Data.Blocks;

/// <summary>
/// Which of a block's shapes move with the position it sits at, as flags on
/// <see cref="BlockInfo.ShapeOffsets"/>.
/// <p/>
/// Having an offset at all is not the same as every shape using it: <c>short_grass</c> has an offset
/// function, <c>getOffset</c> returns a real vector for it, and <c>getShape</c> hands back the unmoved
/// shape anyway, because only some blocks' overrides call <c>.move(state.getOffset(pos))</c>. A moved
/// shape and an unmoved one look the same in the data, so which is which has to be recorded.
/// </summary>
[Flags]
public enum BlockShapeOffsets {
    None = 0,
    Block = 1,
    Collision = 2,
    Interaction = 4,
    Occlusion = 8,
    Visual = 16
}

/// <summary>How a block's shape is moved by the position it sits at.</summary>
public enum BlockOffsetType {
    None,

    /// <summary>Moved horizontally, which is what stops a field of flowers looking like a grid.</summary>
    Xz,

    /// <summary>Moved horizontally and sunk into the ground, as the hanging plants are.</summary>
    Xyz
}

/// <summary>
/// Everything about a block that is the same for all of its states.
/// <p/>
/// The split matters: two thirds of the block states in the game differ from their block's default
/// in at least their shape, so anything that can vary lives on <see cref="BlockStateInfo"/> instead.
/// </summary>
/// <param name="BounceRestitution">
/// How much of the velocity a landing keeps, see <c>Entity.restituteMovementAfterCollisions</c>.
/// Zero for everything but slime blocks and beds.
/// </param>
/// <param name="Gravity">Whether the block falls when the one under it goes, as sand does.</param>
/// <param name="DynamicShape">
/// Whether the block works its shape out per position rather than caching one per state. Vanilla
/// uses it to decide what it can precompute; it is here because a shape in the generated data is
/// the one an empty world gives back, which for these blocks is only the starting point.
/// </param>
/// <param name="RequiredFeatures">
/// The feature flags a world has to have on for the block to exist at all. Everything in 26.2 is
/// plain <c>minecraft:vanilla</c>; an experiment gated block would carry its flag here.
/// </param>
/// <param name="LootTable">
/// Which loot table the block drops from, <c>Block.getLootTable</c>. Null for the blocks vanilla
/// gives <c>noLootTable()</c>: air, bedrock, barriers, the command blocks, the fluids.
/// <p/>
/// <b>Not derivable from the block's name.</b> 83 blocks have no table named after them, and they
/// are two different things: a wall sign <c>dropsLike</c> its standing form and lands on
/// <c>minecraft:blocks/oak_sign</c>, while bedrock has no table at all. Reading the key is what
/// keeps those apart.
/// </param>
public sealed record BlockInfo(
    Identifier Category,
    string TranslationKey,
    float ExplosionResistance,
    float Friction,
    float SpeedFactor,
    float JumpFactor,
    float BounceRestitution,
    bool Gravity,
    bool DynamicShape,
    BlockOffsetType OffsetType,
    float MaxHorizontalOffset,
    float MaxVerticalOffset,
    Identifier? BlockEntity,
    Identifier? Item,
    Identifier[] RequiredFeatures,
    Identifier? LootTable = null) {

    /// <summary>The flags every block that is not behind an experiment needs, which is all of them.</summary>
    public static readonly Identifier[] VanillaOnly = ["minecraft:vanilla"];

    /// <summary>
    /// How much experience the block drops when broken, <c>DropExperienceBlock</c>'s <c>xpRange</c>,
    /// inclusive at both ends. Null for everything that is not one of the seventeen ores or
    /// <c>sculk</c>.
    /// <p/>
    /// Not a constructor argument because it is null for all but eighteen blocks. The other five
    /// classes that drop experience pass a literal inside <c>spawnAfterBreak</c> with no field behind
    /// it, so they are a table in <c>BlockExperienceFeature</c> rather than data.
    /// </summary>
    public (int Min, int Max)? Experience { get; init; }

    /// <summary>
    /// Which shapes <see cref="ShapeOffset"/> applies to. Not a constructor argument because it is
    /// <see cref="BlockShapeOffsets.None"/> for all but the forty odd blocks that have an offset at all.
    /// </summary>
    public BlockShapeOffsets ShapeOffsets { get; init; }

    /// <summary>
    /// Whether the given shape of this block is one the generated data has taken the offset out of, so
    /// the caller has to put it back. Asking this rather than <see cref="OffsetType"/> is the
    /// difference between bamboo, whose outline moves, and short grass, whose does not.
    /// </summary>
    public bool Offsets(BlockShapeOffsets shape) => (ShapeOffsets & shape) != 0;

    /// <summary>
    /// How far the block's shapes are moved at <paramref name="position"/>, from
    /// <c>BlockBehaviour.Properties.offsetType</c>. The shapes in the generated data have this taken
    /// back out of them, so anything colliding with a block that has an offset has to add it again.
    /// <p/>
    /// The bounds are floats because vanilla's are, and they get widened partway through the
    /// arithmetic: taking them as doubles moves the last few bits of the result.
    /// </summary>
    public Vec3<double> ShapeOffset(Vec3<int> position) {
        if (OffsetType == BlockOffsetType.None) {
            return Vec3<double>.Zero;
        }

        long seed = Seed(position.X, position.Z);
        double y = OffsetType == BlockOffsetType.Xyz
            ? ((seed >> 4 & 15L) / 15.0f - 1.0) * MaxVerticalOffset
            : 0.0;

        return new Vec3<double>(Spread(seed & 15L, MaxHorizontalOffset), y, Spread(seed >> 8 & 15L, MaxHorizontalOffset));
    }

    /// <summary>
    /// <c>Mth.getSeed</c> at y zero. The horizontal terms overflow an int in vanilla, so the
    /// multiplication has to stay unchecked and stay 32 bit.
    /// </summary>
    private static long Seed(int x, int z) {
        long seed = unchecked(x * 3129871) ^ z * 116129781L;
        return seed * seed * 42317861L + seed * 11L >> 16;
    }

    /// <summary>
    /// One of sixteen offsets spread over half a block, clamped to the block's own maximum. Vanilla
    /// divides in float before widening, so the division has to as well.
    /// </summary>
    private static double Spread(long bits, double max) {
        return Math.Clamp((bits / 15.0f - 0.5) * 0.5, -max, max);
    }
}
