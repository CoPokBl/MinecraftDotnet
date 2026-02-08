using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Entities;

public class EntityManager(EventNode<IServerEvent> baseEventNode, int viewDistanceBlocks) : IEntityManager {
    private static readonly Tag<HashSet<int>> VisibleEntitiesTag = new("managedserver:entitymanager:visible_entities");
    
    public EventNode<IServerEvent> BaseEventNode { get; } = baseEventNode;

    private readonly Dictionary<Vec2<int>, List<Entity>> _entitiesByChunk = [];
    private readonly Dictionary<int, Entity> _entitiesById = [];
    
    private int _currentId;
    public int NewNetId => _currentId++;

    public int EntityCount => _entitiesById.Count;

    public Entity[] GetEntitiesInChunk(Vec2<int> chunkPos) {
        return _entitiesByChunk.GetValueOrDefault(chunkPos, []).ToArray();
    }

    /// <summary>
    /// Adds an entity to the manager and sends spawn packets to all viewers.
    /// DO NOT CALL DIRECTLY. Use <see cref="Entity.SetWorld"/>.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="id"></param>
    public void Register(Entity entity, int? id = null) {
        entity.NetId = id ?? NewNetId;

        MoveEntityInStorage(entity, new Vec3<double>(int.MaxValue), entity.Position);
        _entitiesById[entity.NetId] = entity;

        MinecraftPacket[] spawnPackets = entity.GenerateSpawnEntityPackets();
        foreach (PlayerEntity viewer in GetViewersOf(entity)) {
            viewer.SendPackets(spawnPackets);
            AddViewedEntity(viewer, entity.NetId);
        }
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

    public void RefreshViewers(Entity entity) {
        foreach (PlayerEntity player in GetViewersOf(entity, true)) {
            if (entity.ViewableRule(player)) {
                if (player.GetTagOrDefault(VisibleEntitiesTag, []).Contains(entity.NetId)) {
                    continue;  // already visible
                }
                SendSpawnPackets(entity, player);
            } else {
                if (!player.GetTagOrDefault(VisibleEntitiesTag, []).Contains(entity.NetId)) {
                    continue;  // already not visible
                }
                SendDespawnPackets(entity, player);
            }
        }
    }
    
    public void RefreshPlayerVisibleEntities(PlayerEntity player) {
        HashSet<int> visibleEntities = player.GetTagOrDefault(VisibleEntitiesTag, []);
        
        foreach (Entity entity in GetNearbyEntities(player.Position, viewDistanceBlocks)) {
            if (entity == player) {
                continue;
            }
            
            if (entity.ViewableRule(player)) {
                if (visibleEntities.Contains(entity.NetId)) {
                    continue;  // already visible
                }
                SendSpawnPackets(entity, player);
            } else {
                if (!visibleEntities.Contains(entity.NetId)) {
                    continue;  // already not visible
                }
                SendDespawnPackets(entity, player);
            }
        }
    }

    private void MoveEntityInStorage(Entity entity, Vec3<double> from, Vec3<double> to) {
        Vec2<int> fromChunk = World.GetChunkPos(from);
        Vec2<int> toChunk = World.GetChunkPos(to);

        if (fromChunk == toChunk) {
            return;
        }
        
        if (_entitiesByChunk.TryGetValue(fromChunk, out List<Entity>? fromList)) {
            fromList.Remove(entity);
            if (fromList.Count == 0) {
                _entitiesByChunk.Remove(fromChunk);
            }
        }
        
        if (!_entitiesByChunk.TryGetValue(toChunk, out List<Entity>? toList)) {
            toList = [];
            _entitiesByChunk[toChunk] = toList;
        }
        toList.Add(entity);

        if (entity.World == null) {
            return;
        }
        
        // Inform viewers of the chunk change
        foreach (PlayerEntity player in entity.World.GetViewersOf(toChunk)) {
            if (player == entity) {
                continue;  // Don't send to self
            }
            
            if (entity.World.DoesPlayerHaveChunkLoaded(player, fromChunk)) {
                continue;  // they could already see it
            }

            // do it next tick so that the position is updated
            entity.Server.Scheduler.ScheduleNextTick(() => {
                SendSpawnPackets(entity, player);
            });
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
    public PlayerEntity[] GetViewersOf(Entity entity, bool ignoreViewableRule = false) {
        return GetNearbyEntities(entity.Position, viewDistanceBlocks)
            .Where(e => 
                e is PlayerEntity pe &&  // Only find players nearby
                (ignoreViewableRule || entity.ViewableRule(pe)) &&  // They can view the entity
                pe != entity)  // Don't include the entity itself if it's a player
            .Select(e => (PlayerEntity)e)
            .ToArray();
    }

    // this is very slow for large numbers of entities
    public PlayerEntity[] GetPlayers() {
        return _entitiesById.Values
            .Where(e => e is PlayerEntity)
            .Cast<PlayerEntity>()
            .ToArray();
    }
    
    // TODO: optimise this by removing .ToArray call
    public Entity[] GetNearbyEntities(Vec3<double> pos, double distance) {
        int chunkRadius = (int)Math.Ceiling(distance / 16) + 1;
        
        Vec2<int> chunkPos = World.GetChunkPos(pos);
        
        List<Entity> entities = [];
        foreach (Vec2<int> chunk in IEntityManager.GetChunksInRadius(chunkPos, chunkRadius)) {
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
        
        MoveEntityInStorage(entity, entity.Position, newPos);
        
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
        MoveEntityInStorage(entity, entity.Position, newPos);
        
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

    public void SendSpawnPackets(Entity entity, PlayerEntity player) {
        if (!entity.ViewableRule(player)) {
            return;
        }
        player.SendPackets(entity.GenerateSpawnEntityPackets());
        AddViewedEntity(player, entity.NetId);
    }

    public void SendDespawnPackets(Entity entity, PlayerEntity player) {
        player.SendPackets(new ClientBoundRemoveEntitiesPacket {
            Entities = [entity.NetId]
        });
        RemoveViewedEntity(player, entity.NetId);
    }

    private void RotateEntity(Entity entity, Angle yaw, Angle pitch) {
        MinecraftPacket packet = new ClientBoundUpdateEntityRotationPacket {
            EntityId = entity.NetId,
            Pitch = pitch,
            Yaw = yaw,
            OnGround = true
        };
        SendPacketsToViewers(entity, packet, HeadRotPacket(entity.NetId, yaw));
    }

    private static ClientBoundSetHeadRotationPacket HeadRotPacket(int id, Angle yaw) {
        return new ClientBoundSetHeadRotationPacket {
            EntityId = id,
            Yaw = yaw
        };
    }
    
    private static void AddViewedEntity(PlayerEntity player, int entityId) {
        if (!player.HasTag(VisibleEntitiesTag)) {
            player.SetTag(VisibleEntitiesTag, []);
        }
        
        player.GetTag(VisibleEntitiesTag).Add(entityId);
    }
    
    private static void RemoveViewedEntity(PlayerEntity player, int entityId) {
        if (!player.HasTag(VisibleEntitiesTag)) {
            return;
        }
        
        player.GetTag(VisibleEntitiesTag).Remove(entityId);
    }
}