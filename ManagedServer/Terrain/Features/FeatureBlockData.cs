using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using Minecraft.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Features;

/// <summary>
/// What a feature needs to know about a block state, resolved once per state id.
/// </summary>
/// <remarks>
/// Same shape and the same reason as <c>BlockPhysicsData</c> and <c>HeightmapStates</c>: a
/// <c>GetByStateId</c> is an interned read but the class chain walk behind a tag test is not, and the
/// feature pass asks these questions tens of thousands of times per chunk.
/// <p/>
/// Tag membership is a <see cref="bool"/> per state per tag, built on first use of that tag. The
/// alternative, resolving a tag to a set of block identifiers and hashing an identifier per query, is
/// what makes a placement filter cost more than the feature behind it.
/// </remarks>
public sealed class FeatureBlockData {
    private const byte Air = 1;
    private const byte Solid = 2;
    private const byte Replaceable = 4;
    private const byte BlocksMotion = 8;
    private const byte HasFluid = 16;
    private const byte Resolved = 32;
    private const byte Liquid = 64;
    private const byte SolidRender = 128;

    private static readonly ConditionalWeakTable<MinecraftRegistry, FeatureBlockData> Cache = new();

    private readonly MinecraftRegistry _registry;
    private readonly byte[] _flags;
    private readonly ConcurrentDictionary<Identifier, bool[]> _tags = new();

    private FeatureBlockData(MinecraftRegistry registry) {
        _registry = registry;
        _flags = new byte[registry.Blocks.StatesCount];
    }

    /// <summary>The table for a registry, built once and shared by every world using it.</summary>
    public static FeatureBlockData For(MinecraftRegistry registry) {
        return Cache.GetValue(registry, key => new FeatureBlockData(key));
    }

    public bool IsAir(uint stateId) => (FlagsOf(stateId) & Air) != 0;

    /// <summary><c>BlockState.isSolid</c>, which the <c>solid</c> block predicate asks.</summary>
    public bool IsSolid(uint stateId) => (FlagsOf(stateId) & Solid) != 0;

    /// <summary><c>BlockState.canBeReplaced</c>, which is what a feature is allowed to overwrite.</summary>
    public bool IsReplaceable(uint stateId) => (FlagsOf(stateId) & Replaceable) != 0;

    public bool BlocksMotionAt(uint stateId) => (FlagsOf(stateId) & BlocksMotion) != 0;

    /// <summary>Whether the state carries a fluid, source or flowing, waterlogged or not.</summary>
    public bool HasFluidAt(uint stateId) => (FlagsOf(stateId) & HasFluid) != 0;

    /// <summary>
    /// <c>BlockState.liquid</c>: whether the block <b>is</b> a fluid, which is not
    /// <see cref="HasFluidAt"/>. A waterlogged fence carries a fluid and is not one.
    /// </summary>
    public bool IsLiquid(uint stateId) => (FlagsOf(stateId) & Liquid) != 0;

    /// <summary>
    /// <c>BlockState.isSolidRender</c>: whether the state's occlusion shape is the whole cube, which
    /// is what decides whether a mineshaft lays a rail over a floor block.
    /// </summary>
    public bool IsSolidRender(uint stateId) => (FlagsOf(stateId) & SolidRender) != 0;

    /// <summary>Whether the state is in a block tag, by the tag's registry id.</summary>
    public bool IsIn(Identifier tag, uint stateId) {
        bool[] membership = _tags.GetOrAdd(tag, BuildTag);
        return stateId < (uint)membership.Length && membership[stateId];
    }

    private byte FlagsOf(uint stateId) {
        if (stateId >= (uint)_flags.Length) {
            // A state the registry does not know reads as air, which keeps a feature from placing
            // against it rather than failing the chunk.
            return Air;
        }

        byte cached = _flags[stateId];
        if (cached != 0) {
            return cached;
        }

        IBlock block = _registry.Blocks.GetByStateId(stateId);

        byte flags = Resolved;
        if (block.Air) {
            flags |= Air;
        }

        if (block.Solid) {
            flags |= Solid;
        }

        if (block.Replaceable) {
            flags |= Replaceable;
        }

        if (block.BlocksMotion) {
            flags |= BlocksMotion;
        }

        if (block.Fluid is not null) {
            flags |= HasFluid;
        }

        if (block.Liquid) {
            flags |= Liquid;
        }

        // Vanilla caches this the same way, off the occlusion shape it built for the state, and the
        // shape is empty for anything that cannot occlude at all.
        if (block.Occludes && ShapeSupport.IsShapeFullBlock(block.OcclusionShape)) {
            flags |= SolidRender;
        }

        // Two threads resolving the same state write the same byte, so no lock is needed.
        _flags[stateId] = flags;
        return flags;
    }

    /// <summary>
    /// Every state of every block in a tag.
    /// </summary>
    /// <remarks>
    /// A tag the registry does not have is an empty set rather than a throw: the block tags are
    /// datapack driven, so a consumer can have removed one, and a feature asking about a tag nothing
    /// is in simply never places.
    /// </remarks>
    private bool[] BuildTag(Identifier tag) {
        bool[] membership = new bool[_registry.Blocks.StatesCount];

        if (!_registry.Blocks.Tags.Contains(tag)) {
            return membership;
        }

        HashSet<Identifier> blocks = [.._registry.Blocks.Tags[tag].GetValueIds(_registry)];
        if (blocks.Count == 0) {
            return membership;
        }

        for (uint stateId = 0; stateId < (uint)membership.Length; stateId++) {
            if (!_registry.Blocks.StatesByStateId.ContainsKey(stateId)) {
                continue;
            }

            membership[stateId] = blocks.Contains(_registry.Blocks.GetByStateId(stateId).Identifier);
        }

        return membership;
    }
}
