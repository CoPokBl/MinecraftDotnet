using ManagedServer.Entities.Types;
using ManagedServer.Physics;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Entities;

public interface IEntityManager {
    int EntityCount { get; }
    EventNode<IServerEvent> BaseEventNode { get; }
    
    void Respawn(Entity entity);
    void SendPacketsToViewers(Entity entity, params MinecraftPacket[] packets);
    Entity? GetEntity(int id);
    Entity[] GetEntities();
    Player? GetPlayerByConnection(PlayerConnection connection);
    Player[] GetViewersOf(Entity entity, bool ignoreViewableRule = false);
    Player[] GetPlayers();
    Entity[] GetNearbyEntities(Vec3<double> pos, double distance);
    Entity[] GetEntitiesInChunk(Vec2<int> chunkPos);

    /// <summary>
    /// Everything whose bounding box intersects <paramref name="box"/>, vanilla's
    /// <c>getEntitiesOfClass(AABB, predicate)</c>. This is the query target selection wants: it is
    /// what a mob's follow range actually describes, and unlike
    /// <see cref="GetNearbyEntities"/> the filter runs before anything is collected.
    /// </summary>
    Entity[] GetEntitiesInBox(Box box, Func<Entity, bool>? filter = null);

    /// <summary>
    /// Everything within <paramref name="radius"/> of a point, compared as squared distances so no
    /// square root is taken per candidate. A target goal asks this of every mob every few ticks, which
    /// is why it exists separately from <see cref="GetNearbyEntities"/>.
    /// </summary>
    Entity[] GetEntitiesWithin(Vec3<double> pos, double radius, Func<Entity, bool>? filter = null);

    /// <summary>
    /// The closest entity within <paramref name="radius"/> that passes the filter, or null. Vanilla's
    /// <c>getNearestEntity</c>, which is what every "nearest attackable target" goal ends at.
    /// </summary>
    Entity? GetNearestEntity(Vec3<double> pos, double radius, Func<Entity, bool>? filter = null);

    void Register(Entity entity, int? id = null);
    void Despawn(Entity entity);
    void RefreshViewers(Entity entity);
    void RefreshPlayerVisibleEntities(Player player);
    void MoveEntity(Entity entity, Vec3<double> newPos, Angle? yaw = null, Angle? pitch = null);
    void TeleportEntity(Entity entity, Vec3<double> newPos, Angle yaw, Angle pitch);
    void SyncRotation(Entity entity);

    void SendSpawnPackets(Entity entity, Player player);
    void SendDespawnPackets(Entity entity, Player player);

    /// <summary>
    /// The same bookkeeping as <see cref="SendSpawnPackets"/> and <see cref="SendDespawnPackets"/>,
    /// but handing the packets back rather than writing them, so a caller streaming a viewport can
    /// put them in its own ordered queue instead of blocking on a socket.
    /// </summary>
    MinecraftPacket[] TrackSpawn(Entity entity, Player player);

    MinecraftPacket[] TrackDespawn(Entity entity, Player player);
    
    public static IEnumerable<Vec2<int>> GetChunksInRadius(Vec2<int> baseChunk, int chunkRadius) {
        for (int dx = -chunkRadius; dx <= chunkRadius; dx++) {
            for (int dz = -chunkRadius; dz <= chunkRadius; dz++) {
                yield return baseChunk + new Vec2<int>(dx, dz);
            }
        }
    }
}
