using ManagedServer.Entities.Types;
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
    PlayerEntity? GetPlayerByConnection(PlayerConnection connection);
    PlayerEntity[] GetViewersOf(Entity entity, bool ignoreViewableRule = false);
    PlayerEntity[] GetPlayers();
    Entity[] GetNearbyEntities(Vec3<double> pos, double distance);
    Entity[] GetEntitiesInChunk(Vec2<int> chunkPos);

    void Register(Entity entity, int? id = null);
    void Despawn(Entity entity);
    void RefreshViewers(Entity entity);
    void RefreshPlayerVisibleEntities(PlayerEntity player);
    void MoveEntity(Entity entity, Vec3<double> newPos, Angle? yaw = null, Angle? pitch = null);
    void TeleportEntity(Entity entity, Vec3<double> newPos, Angle yaw, Angle pitch);

    void SendSpawnPackets(Entity entity, PlayerEntity player);
    void SendDespawnPackets(Entity entity, PlayerEntity player);
    
    public static IEnumerable<Vec2<int>> GetChunksInRadius(Vec2<int> baseChunk, int chunkRadius) {
        for (int dx = -chunkRadius; dx <= chunkRadius; dx++) {
            for (int dz = -chunkRadius; dz <= chunkRadius; dz++) {
                yield return baseChunk + new Vec2<int>(dx, dz);
            }
        }
    }
}
