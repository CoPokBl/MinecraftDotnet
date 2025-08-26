using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
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

public class EntityManager(EventNode<IServerEvent> baseEventNode, int viewDistanceBlocks) : IEntityManager {
    public EventNode<IServerEvent> BaseEventNode { get; } = baseEventNode;

    private readonly Dictionary<Vec2<int>, List<Entity>> _entitiesByChunk = [];
    private readonly Dictionary<int, Entity> _entitiesById = [];
    
    private int _currentId;
    public int NewNetId => _currentId++;

    public int EntityCount => _entitiesById.Count;

    public void InformNewPlayer(PlayerEntity player) {
        foreach (Entity entity in GetNearbyEntities(player.Position, viewDistanceBlocks)) {
            if (!entity.ViewableRule(player)) {
                continue;
            }
            player.SendMessage("You can see entity " + entity.NetId);
            if (entity is PlayerEntity) {
                player.SendMessage("It's a player!");
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
    public void Register(Entity entity, int? id = null) {
        entity.NetId = id ?? NewNetId;
        entity.Manager = this;

        Vec2<int> chunk = World.GetChunkPos(entity.Position);
        if (!_entitiesByChunk.TryGetValue(chunk, out List<Entity>? value)) {
            value = [];
            _entitiesByChunk[chunk] = value;
        }
        value.Add(entity);
        _entitiesById[entity.NetId] = entity;
        
        SendPacketsToViewers(entity, entity.GenerateSpawnEntityPackets());
    }

    public void Despawn(Entity entity) {
        SendPacketsToViewers(entity, new ClientBoundRemoveEntitiesPacket {
            Entities = [entity.NetId]
        });

        _entitiesById.Remove(entity.NetId);
        Vec2<int> chunk = World.GetChunkPos(entity.Position);
        if (_entitiesByChunk.TryGetValue(chunk, out List<Entity>? value)) {
            value.Remove(entity);
            if (value.Count == 0) {
                _entitiesByChunk.Remove(chunk);
            }
        }
    }

    public void Respawn(Entity entity) {
        SendPacketsToViewers(entity, new ClientBoundRemoveEntitiesPacket {
            Entities = [entity.NetId]
        });
        SendPacketsToViewers(entity, entity.GenerateSpawnEntityPackets());
    }

    public void SendPacketsToViewers(Entity entity, params MinecraftPacket[] packets) {
        entity.SendPacketsToViewers(packets);
    }

    public Entity? GetEntity(int id) {
        return _entitiesById.GetValueOrDefault(id);
    }

    public Entity[] GetEntities() {
        return _entitiesById.Values.ToArray();
    }

    public PlayerEntity? GetPlayerByConnection(PlayerConnection connection) {
        return _entitiesById.Values
            .Where(e => e is PlayerEntity pe && pe.Connection == connection)
            .Cast<PlayerEntity>()
            .FirstOrDefault();
    }

    // this could use some optimising
    public PlayerEntity[] GetViewersOf(Entity entity) {
        return _entitiesById.Values
            .Where(e => e is PlayerEntity pe && 
                        pe.Position.DistanceTo2D(entity.Position) < viewDistanceBlocks &&
                        entity.ViewableRule(pe))
            .Select(e => (PlayerEntity)e)
            .ToArray();
    }

    public PlayerEntity[] GetPlayers() {
        return _entitiesById.Values
            .Where(e => e is PlayerEntity)
            .Cast<PlayerEntity>()
            .ToArray();
    }
    
    public Entity[] GetNearbyEntities(Vec3<double> pos, double distance) {
        int chunkRadius = (int)Math.Ceiling(distance / 16) + 1;
        Vec2<int>[] chunksToCheck = IEntityManager.GetChunksInRadius(chunkRadius);
        
        List<Entity> entities = [];
        foreach (Vec2<int> chunk in chunksToCheck) {
            List<Entity>? chunkEntities = _entitiesByChunk.GetValueOrDefault(chunk);
            if (chunkEntities == null) continue;

            entities.AddRange(chunkEntities.Where(entity => entity.Position.DistanceTo(pos) < distance));
        }
        
        return entities.ToArray();
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
        
        SendPacketsToViewers(entity, packets);
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
        
        SendPacketsToViewers(entity, packet, HeadRotPacket(entity.NetId, yaw));
    }

    private void RotateEntity(Entity entity, Angle yaw, Angle pitch) {
        // for some reason pitch and yaw seem reversed.
        MinecraftPacket packet = new ClientBoundUpdateEntityRotationPacket {
            EntityId = entity.NetId,
            Pitch = yaw,
            Yaw = pitch,
            OnGround = true
        };
        SendPacketsToViewers(entity, packet, HeadRotPacket(entity.NetId, pitch));
    }

    private static ClientBoundSetHeadRotationPacket HeadRotPacket(int id, Angle yaw) {
        return new ClientBoundSetHeadRotationPacket {
            EntityId = id,
            Yaw = yaw
        };
    }
}