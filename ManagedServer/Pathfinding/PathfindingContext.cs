using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Pathfinding;

/// <summary>
/// Everything a search is allowed to read, vanilla's <c>PathfindingContext</c>: the world, a
/// classification cache and where the mob started.
/// <p/>
/// Vanilla wraps a <c>PathNavigationRegion</c>, a snapshot of the chunks around the mob, rather than
/// the level itself. The world is read live here, which is safe for the same reason vanilla's is:
/// the search runs synchronously on the tick thread, so nothing can write underneath it. The shape
/// is kept as a read only view all the same, because that snapshot is the only thing standing
/// between this and being offloadable, and the port should not be what closes that door.
/// <p/>
/// An unloaded chunk reads as air, which is what <c>PathNavigationRegion</c> does for a chunk it did
/// not capture. A mob therefore plans happily through terrain that has not loaded yet, and walks
/// into it when it arrives; that is vanilla's behaviour rather than a gap here.
/// </summary>
public class PathfindingContext(World world, Mob mob) {
    public World World { get; } = world;

    /// <summary>Where the mob was when the search started, <c>PathfindingContext.mobPosition</c>.</summary>
    public Vec3<int> MobPosition { get; } = mob.Position.ToBlockPos();

    private readonly PathTypeCache _cache = world.PathTypes;
    private readonly MinecraftRegistry _registry = world.Server.Registry;
    private readonly uint _airStateId = Block.Air.StateId;

    /// <summary>
    /// <c>PathfindingContext.getPathTypeFromState</c>: the classification of one block, through the
    /// per position cache.
    /// </summary>
    public PathType GetPathTypeFromState(int x, int y, int z) {
        return _cache.GetOrCompute(this, x, y, z);
    }

    /// <summary>What the cache calls on a miss. Not for general use; go through the cache.</summary>
    internal PathType ClassifyUncached(int x, int y, int z) {
        return BlockPathData.Of(_registry, World.GetBlockStateIdOr(x, y, z, _airStateId));
    }

    public uint GetBlockStateId(int x, int y, int z) {
        return World.GetBlockStateIdOr(x, y, z, _airStateId);
    }

    public IBlock GetBlock(int x, int y, int z) {
        return World.GetBlockOr(new Vec3<int>(x, y, z), Block.Air);
    }
}
