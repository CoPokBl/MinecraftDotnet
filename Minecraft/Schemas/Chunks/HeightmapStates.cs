using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;

namespace Minecraft.Schemas.Chunks;

/// <summary>
/// What each client sent heightmap makes of a block state, resolved once per state id.
/// </summary>
/// <remarks>
/// Cached because the answer costs a <c>GetByStateId</c>, which allocates a record, and a walk of the
/// block's class chain. Same shape and the same reason as <c>BlockPhysicsData</c>.
/// <p/>
/// Filled lazily rather than up front: the table has tens of thousands of entries and a world uses a
/// few dozen of them. Two threads resolving the same state race to write the same byte, which is why
/// no lock is needed.
/// </remarks>
public static class HeightmapStates {
    /// <summary><c>Heightmap.NOT_AIR</c>, which is <see cref="HeightmapType.WorldSurface"/>.</summary>
    public const byte NotAir = 1;

    /// <summary><c>state.is(BLOCKS_MOTION_IN_HEIGHTMAP) || !state.getFluidState().isEmpty()</c>.</summary>
    public const byte MotionBlocking = 2;

    /// <summary>
    /// The same over <c>BLOCKS_MOTION_IN_HEIGHTMAP_NO_LEAVES</c>. The fluid half is not narrowed by it,
    /// so waterlogged leaves count.
    /// </summary>
    public const byte MotionBlockingNoLeaves = 4;

    /// <summary>Set on a cached entry so that a resolved "matches nothing" is not read as absent.</summary>
    private const byte Resolved = 8;

    private static byte[] _table = [];

    /// <summary>
    /// The three flags for a state. Never call this per position: a section's distinct values are
    /// what it is meant for, which is what <see cref="Heightmaps.Compute"/> feeds it.
    /// </summary>
    public static byte FlagsOf(uint stateId, MinecraftRegistry registry) {
        byte[] table = _table;
        if (stateId >= (uint)table.Length) {
            table = Grow(registry, stateId);
        }

        byte cached = table[stateId];
        if (cached != 0) {
            return (byte)(cached & ~Resolved);
        }

        byte flags = Resolve(stateId, registry);
        table[stateId] = (byte)(flags | Resolved);
        return flags;
    }

    private static byte Resolve(uint stateId, MinecraftRegistry registry) {
        if (!registry.Blocks.StatesByStateId.ContainsKey(stateId)) {
            // A chunk can carry a state we do not know, the same way ChunkSection's fluid count can.
            // Counting it as air keeps it out of every map rather than failing a whole chunk.
            return 0;
        }

        IBlock block = registry.Blocks.GetByStateId(stateId);

        byte flags = 0;
        if (!block.Air) {
            flags |= NotAir;
        }

        // Vanilla's MOTION_BLOCKING predicate is a disjunction, so water counts even though nothing
        // walks on it. Dropping the fluid half is what puts rain through an ocean's surface.
        bool fluid = block.Fluid is not null;
        if (fluid || InTag(registry, BlocksMotionInHeightmap, block.Identifier)) {
            flags |= MotionBlocking;
        }

        if (fluid || InTag(registry, BlocksMotionInHeightmapNoLeaves, block.Identifier)) {
            flags |= MotionBlockingNoLeaves;
        }

        return flags;
    }

    private static readonly Identifier BlocksMotionInHeightmap = "minecraft:blocks_motion_in_heightmap";
    private static readonly Identifier BlocksMotionInHeightmapNoLeaves = "minecraft:blocks_motion_in_heightmap_no_leaves";

    private static bool InTag(MinecraftRegistry registry, Identifier tag, Identifier block) {
        return registry.Blocks.Tags.Contains(tag) && registry.Blocks.Tags[tag].GetValueIds(registry).Contains(block);
    }

    private static byte[] Grow(MinecraftRegistry registry, uint stateId) {
        // Sized to the registry rather than to the id asked for, so this happens once.
        int size = (int)Math.Max(registry.Blocks.StatesCount, stateId + 1);
        byte[] grown = new byte[size];

        // Whatever was already resolved stays resolved; a lost race just recomputes.
        byte[] existing = _table;
        Array.Copy(existing, grown, Math.Min(existing.Length, size));

        _table = grown;
        return grown;
    }
}
