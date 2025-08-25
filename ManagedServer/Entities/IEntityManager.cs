using ManagedServer.Entities.Types;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Packets;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Entities;

public interface IEntityManager {
    int EntityCount { get; }
    
    void InformNewPlayer(PlayerEntity player);
    void Respawn(Entity entity);
    void SendPacketsToViewers(Entity entity, params MinecraftPacket[] packets);
    Entity? GetEntity(int id);
    Entity[] GetEntities();
    PlayerEntity? GetPlayerByConnection(PlayerConnection connection);
    PlayerEntity[] GetViewersOf(Entity entity);
    PlayerEntity[] GetPlayers();
    Entity[] GetNearbyEntities(Vec3<double> pos, double distance);

    void Register(Entity entity, int? id = null);
    void Despawn(Entity entity);
    void MoveEntity(Entity entity, Vec3<double> newPos, Angle? yaw = null, Angle? pitch = null);
    void TeleportEntity(Entity entity, Vec3<double> newPos, Angle yaw, Angle pitch);
    
    public static Vec2<int>[] GetChunksInRadius(int chunkRadius) {
        int numberOfChunksInRadius = (chunkRadius * 2 + 1) * (chunkRadius * 2 + 1);
        Vec2<int>[] chunks = new Vec2<int>[numberOfChunksInRadius];
        int index = 0;
        for (int x = -chunkRadius; x <= chunkRadius; x++) {
            for (int z = -chunkRadius; z <= chunkRadius; z++) {
                chunks[index++] = new Vec2<int>(x, z);
            }
        }

        if (index != numberOfChunksInRadius) {
            throw new Exception("Logic error in GetChunksInRadius");
        }
        
        return chunks;
    }
}
