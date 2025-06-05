using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Entities;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Server.Features;

public class SimpleEntitiesFeature : IFeature {
    public readonly List<Entity> Entities = [];
    private MinecraftServer _server = null!;
    private int _currentId = 9;
    public int NewNetId => _currentId++;
    
    public void Register(MinecraftServer server) {
        _server = server;
        server.Events.AddListener<PlayerLoginFeature.PlayerLoginEvent>(e => {
            _ = InformNewPlayer(e.Connection);
        });
    }

    public async Task InformNewPlayer(PlayerConnection connection) {
        foreach (Entity entity in Entities) {
            if (!entity.ViewableRule(connection)) {
                continue;
            }
            await connection.SendPackets(entity.GenerateSpawnEntityPackets());
        }
    }

    public Type[] GetDependencies() {
        return [];
    }

    public void Spawn(Entity entity) {
        entity.NetId = NewNetId;
        entity.Feat = this;
        Entities.Add(entity);
        
        SendPacketsFor(entity, entity.GenerateSpawnEntityPackets());
    }

    private void SendPacketsFor(Entity entity, params MinecraftPacket[] packets) {
        foreach (PlayerConnection con in _server.Connections) {
            if (con.State != PlayerConnectionState.Play) {
                continue;
            }

            if (!entity.ViewableRule(con)) {
                continue;
            }
            con.SendPackets(packets);
        }
    }

    public void MoveEntity(Entity entity, Vec3 newPos, Angle? yaw = null, Angle? pitch = null) {
        double deltaX = Math.Abs(newPos.X - entity.Position.X);
        double deltaY = Math.Abs(newPos.Y - entity.Position.Y);
        double deltaZ = Math.Abs(newPos.Z - entity.Position.Z);

        if (deltaX == 0 && deltaY == 0 && deltaZ == 0 && yaw != null && pitch != null) {
            RotateEntity(entity, yaw.Value, pitch.Value);
            return;
        }
        
        if (deltaX > 7.5 || deltaY > 7.5 || deltaZ > 7.5) {  // This packet can't support high values, use teleport
            TeleportEntity(entity, newPos, yaw ?? entity.Yaw, pitch ?? entity.Pitch);
            return;
        }
        
        SVec3 deltaPos = new(
            (short)(newPos.X*4096 - entity.Position.X*4096), 
            (short)(newPos.Y*4096 - entity.Position.Y*4096), 
            (short)(newPos.Z*4096 - entity.Position.Z*4096));
        
        MinecraftPacket packet = yaw == null || pitch == null
            ? new ClientBoundUpdateEntityPositionPacket(entity.NetId, deltaPos, false)
            : new ClientBoundUpdateEntityPosAndRotPacket(entity.NetId, deltaPos, yaw.Value, pitch.Value, true);
        
        SendPacketsFor(entity, packet);
    }

    public void TeleportEntity(Entity entity, Vec3 newPos, Angle yaw, Angle pitch) {
        MinecraftPacket packet =
            new ClientBoundTeleportEntityPacket(entity.NetId, newPos, Vec3.Zero, (float)yaw.Degrees, (float)pitch.Degrees, true);
        
        SendPacketsFor(entity, packet);
    }
    
    public void RotateEntity(Entity entity, Angle yaw, Angle pitch) {
        MinecraftPacket packet = new ClientBoundUpdateEntityRotationPacket(entity.NetId, yaw, pitch, true);
        SendPacketsFor(entity, packet);
    }
}