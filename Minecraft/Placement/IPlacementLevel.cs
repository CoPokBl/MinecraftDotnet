using Minecraft.Data.Blocks;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Placement;

/// <summary>
/// What the placement rules read and write, vanilla's <c>LevelAccessor</c> as far as
/// <c>getStateForPlacement</c>, <c>canSurvive</c>, <c>updateShape</c> and <c>setPlacedBy</c> reach into
/// it. A server's world and a client's predicting level both implement it, so the two run one port.
/// </summary>
public interface IPlacementLevel {
    public IBlock GetBlock(Vec3<int> pos);

    /// <summary>The block, or <paramref name="def"/> outside the world or in a chunk that is not loaded.</summary>
    public IBlock GetBlockOr(Vec3<int> pos, IBlock def);

    public MinecraftRegistry Registry { get; }

    public int MinY { get; }

    public int Height { get; }

    public bool IsInBounds(Vec3<int> pos);

    /// <summary><c>Level.isClientSide</c>. A few <c>setPlacedBy</c> bodies and the shape cascade's destroy branch only run on a server.</summary>
    public bool IsClientSide { get; }

    /// <summary><c>state.is(tag)</c> for a block tag, as this side knows the tags.</summary>
    public bool IsInBlockTag(Identifier tag, Identifier block);

    /// <summary>The rule speaking for a block here, or null when it places its default state and reacts to nothing.</summary>
    public IBlockPlacementRule? PlacementRuleFor(IBlock block);

    /// <summary><c>Level.setBlock</c>, which runs the shape cascade unless <see cref="BlockUpdateFlags.KnownShape"/> says not to.</summary>
    public void SetBlock(Vec3<int> pos, IBlock block, int flags = BlockUpdateFlags.Default, int updateLimit = BlockUpdateFlags.UpdateLimit);

    /// <summary><c>Level.destroyBlock</c>: leaves the block's fluid behind.</summary>
    public bool DestroyBlock(Vec3<int> pos, bool dropResources, int updateLimit = BlockUpdateFlags.UpdateLimit);
}
