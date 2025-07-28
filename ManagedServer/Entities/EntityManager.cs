using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Entities;

public class EntityManager(EventNode<IServerEvent> baseEventNode, int viewDistanceBlocks) {
    public EventNode<IServerEvent> BaseEventNode { get; set; } = baseEventNode;
    
    public readonly List<Entity> Entities = [];
    private int _currentId = 9;
    public int NewNetId => Random.Shared.Next();//_currentId++;

    public void InformNewPlayer(PlayerEntity player) {
        foreach (Entity entity in Entities) {
            if (!entity.ViewableRule(player)) {
                continue;
            }
            player.SendPackets(entity.GenerateSpawnEntityPackets());
        }
    }

    /// <summary>
    /// Adds an entity to the manager and sends spawn packets to all viewers.
    /// DO NOT CALL DIRECTLY. Use <see cref="Entity.SetWorld"/>.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="id"></param>
    internal void Spawn(Entity entity, int? id = null) {
        entity.NetId = id ?? NewNetId;
        entity.Manager = this;
        Entities.Add(entity);
        
        SendPacketsFor(entity, entity.GenerateSpawnEntityPackets());
    }

    public void Despawn(Entity entity) {
        SendPacketsFor(entity, new ClientBoundRemoveEntitiesPacket {
            Entities = [entity.NetId]
        });
        Entities.Remove(entity);
    }

    public void Respawn(Entity entity) {
        SendPacketsFor(entity, new ClientBoundRemoveEntitiesPacket {
            Entities = [entity.NetId]
        });
        SendPacketsFor(entity, entity.GenerateSpawnEntityPackets());
    }

    public void SendPacketsFor(Entity entity, params MinecraftPacket[] packets) {
        entity.SendPacketsToViewers(packets);
    }

    public Entity? GetEntityById(int id) {
        return Entities.Find(entity => entity.NetId == id);
    }
    
    public PlayerEntity? GetPlayerByConnection(PlayerConnection connection) {
        return Entities
            .Where(e => e is PlayerEntity pe && pe.Connection == connection)
            .Cast<PlayerEntity>()
            .FirstOrDefault();
    }

    // this could use some optimising
    public PlayerEntity[] GetViewersOf(Entity entity) {
        return Entities
            .Where(e => e is PlayerEntity pe && 
                        pe.Position.DistanceTo2D(entity.Position) < viewDistanceBlocks &&
                        entity.ViewableRule(pe))
            .Select(e => (PlayerEntity)e)
            .ToArray();
    }

    public PlayerEntity[] GetPlayers() {
        return Entities
            .Where(e => e is PlayerEntity)
            .Cast<PlayerEntity>()
            .ToArray();
    }
    
    // TODO: this needs major optimising (perhaps store entities in a spatial partitioning structure, or per chunk)
    public Entity[] GetNearbyEntities(Vec3<double> pos, double distance) {
        return Entities
            .Where(e => e.Position.DistanceTo(pos) < distance)
            .ToArray();
    }

    // uses the most appropriate packet type
    public void MoveEntity(Entity entity, Vec3<double> newPos, Angle? yaw = null, Angle? pitch = null) {
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
        
        Vec3<float> deltaPos = new(
            (float)newPos.X - (float)entity.Position.X, 
            (float)newPos.Y - (float)entity.Position.Y, 
            (float)newPos.Z - (float)entity.Position.Z);
        
        MinecraftPacket[] packets = yaw == null || pitch == null
            ? [new ClientBoundUpdateEntityPositionPacket {
                EntityId = entity.NetId,
                Delta = deltaPos,
                OnGround = false
            }]
            : [
                new ClientBoundUpdateEntityPosAndRotPacket {
                    EntityId = entity.NetId,
                    Delta = deltaPos,
                    Yaw = yaw.Value,
                    Pitch = pitch.Value,
                    OnGround = true
                },
                HeadRotPacket(entity.NetId, yaw.Value)
            ];
        
        SendPacketsFor(entity, packets);
    }

    public void SetEntityCrouching(Entity entity, bool crouching) {
        SendPacketsFor(entity, new ClientBoundSetEntityMetadataPacket {
            EntityId = entity.NetId,
            Meta = new PlayerMeta {
                Pose = crouching ? EntityPose.Sneaking : EntityPose.Standing,
                Status = crouching ? EntityStatus.Sneaking : EntityStatus.None
            }
        });
    }

    public void TeleportEntity(Entity entity, Vec3<double> newPos, Angle yaw, Angle pitch) {
        MinecraftPacket packet =
            new ClientBoundTeleportEntityPacket {
                EntityId = entity.NetId,
                Position = newPos,
                Velocity = Vec3<double>.Zero,
                Pitch = pitch,
                Yaw = yaw,
                OnGround = true
            };
        
        SendPacketsFor(entity, packet, HeadRotPacket(entity.NetId, yaw));
    }
    
    public void RotateEntity(Entity entity, Angle yaw, Angle pitch) {
        // for some reason pitch and yaw seem reversed.
        MinecraftPacket packet = new ClientBoundUpdateEntityRotationPacket {
            EntityId = entity.NetId,
            Pitch = yaw,
            Yaw = pitch,
            OnGround = true
        };
        SendPacketsFor(entity, packet, HeadRotPacket(entity.NetId, pitch));
    }

    private static ClientBoundSetHeadRotationPacket HeadRotPacket(int id, Angle yaw) {
        return new ClientBoundSetHeadRotationPacket {
            EntityId = id,
            Yaw = yaw
        };
    }
}