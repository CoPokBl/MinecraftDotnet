using ManagedServer.Entities.Types;
using ManagedServer.Physics;
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

    /// <summary>
    /// Ids start at one: vanilla uses zero to mean "not assigned yet" and throws
    /// <c>Tried to access entity ID before ID assignment</c> the moment a client touches an
    /// entity carrying it, which drops the connection.
    /// </summary>
    public int NewNetId => ++field;

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
        foreach (Player viewer in GetViewersOf(entity)) {
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
        foreach (Player player in GetViewersOf(entity, true)) {
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
    
    public void RefreshPlayerVisibleEntities(Player player) {
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
        
        // Inform viewers of the chunk change. We schedule on the next tick because
        // entity.Position is set by Entity.Move *after* this method returns, and the
        // spawn packet needs the new position. On next tick we build the packets
        // (cheap) on the tick thread, then hand the socket write to the pool so the
        // tick itself doesn't block on serialisation/network I/O.
        foreach (Player player in entity.World.GetViewersOf(toChunk)) {
            if (player == entity) continue;
            if (entity.World.DoesPlayerHaveChunkLoaded(player, fromChunk)) continue;

            Player capturedPlayer = player;
            entity.Server.Scheduler.ScheduleNextTick(() => {
                if (!entity.ViewableRule(capturedPlayer)) return;
                MinecraftPacket[] packets = entity.GenerateSpawnEntityPackets();
                AddViewedEntity(capturedPlayer, entity.NetId);
                _ = Task.Run(() => {
                    try { capturedPlayer.SendPackets(packets); }
                    catch { /* player may have disconnected mid-send */ }
                });
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

    public Player? GetPlayerByConnection(PlayerConnection connection) {
        return _entitiesById.Values
            .Where(e => e is Player pe && pe.Connection == connection)
            .Cast<Player>()
            .FirstOrDefault();
    }

    // this could use some optimising
    public Player[] GetViewersOf(Entity entity, bool ignoreViewableRule = false) {
        return GetNearbyEntities(entity.Position, viewDistanceBlocks)
            .Where(e => 
                e is Player pe &&  // Only find players nearby
                (ignoreViewableRule || entity.ViewableRule(pe)) &&  // They can view the entity
                pe != entity)  // Don't include the entity itself if it's a player
            .Select(e => (Player)e)
            .ToArray();
    }

    // this is very slow for large numbers of entities
    public Player[] GetPlayers() {
        return _entitiesById.Values
            .Where(e => e is Player)
            .Cast<Player>()
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

    public Entity[] GetEntitiesInBox(Box box, Func<Entity, bool>? filter = null) {
        List<Entity> found = [];

        // The chunk grid is the only index there is, so the box is turned into the chunks it covers and
        // the boxes themselves are only tested inside those. One chunk of slack on each side, because
        // an entity is stored by its position and its box reaches past it.
        Vec2<int> min = World.GetChunkPos(new Vec3<double>(box.MinX, box.MinY, box.MinZ));
        Vec2<int> max = World.GetChunkPos(new Vec3<double>(box.MaxX, box.MaxY, box.MaxZ));

        for (int x = min.X - 1; x <= max.X + 1; x++) {
            for (int z = min.Y - 1; z <= max.Y + 1; z++) {
                if (!_entitiesByChunk.TryGetValue(new Vec2<int>(x, z), out List<Entity>? chunkEntities)) {
                    continue;
                }

                foreach (Entity entity in chunkEntities) {
                    if (!new Box(entity.BoundingBox).Translate(entity.Position).Intersects(box)) {
                        continue;
                    }

                    if (filter != null && !filter(entity)) {
                        continue;
                    }

                    found.Add(entity);
                }
            }
        }

        return found.ToArray();
    }

    public Entity[] GetEntitiesWithin(Vec3<double> pos, double radius, Func<Entity, bool>? filter = null) {
        double radiusSqr = radius * radius;
        List<Entity> found = [];

        foreach (Entity entity in CandidatesAround(pos, radius)) {
            if (SquaredDistance(entity.Position, pos) > radiusSqr) {
                continue;
            }

            if (filter != null && !filter(entity)) {
                continue;
            }

            found.Add(entity);
        }

        return found.ToArray();
    }

    public Entity? GetNearestEntity(Vec3<double> pos, double radius, Func<Entity, bool>? filter = null) {
        double bestSqr = radius * radius;
        Entity? best = null;

        foreach (Entity entity in CandidatesAround(pos, radius)) {
            double distanceSqr = SquaredDistance(entity.Position, pos);
            if (distanceSqr > bestSqr) {
                continue;
            }

            if (filter != null && !filter(entity)) {
                continue;
            }

            bestSqr = distanceSqr;
            best = entity;
        }

        return best;
    }

    /// <summary>
    /// Everything in the chunks a radius around a point could reach into. It yields rather than
    /// collecting, so a caller that rejects most of what it sees never builds the list.
    /// </summary>
    private IEnumerable<Entity> CandidatesAround(Vec3<double> pos, double radius) {
        int chunkRadius = (int)Math.Ceiling(radius / 16) + 1;

        foreach (Vec2<int> chunk in IEntityManager.GetChunksInRadius(World.GetChunkPos(pos), chunkRadius)) {
            if (!_entitiesByChunk.TryGetValue(chunk, out List<Entity>? chunkEntities)) {
                continue;
            }

            foreach (Entity entity in chunkEntities) {
                yield return entity;
            }
        }
    }

    private static double SquaredDistance(Vec3<double> a, Vec3<double> b) {
        double dx = a.X - b.X;
        double dy = a.Y - b.Y;
        double dz = a.Z - b.Z;
        return dx * dx + dy * dy + dz * dz;
    }

    // uses the most appropriate packet type
    public void MoveEntity(Entity entity, Vec3<double> newPos, Angle? yaw = null, Angle? pitch = null) {
        double deltaX = Math.Abs(newPos.X - entity.Position.X);
        double deltaY = Math.Abs(newPos.Y - entity.Position.Y);
        double deltaZ = Math.Abs(newPos.Z - entity.Position.Z);

        // Which packet to send is decided from what was last sent rather than from what the caller
        // named, the way vanilla's ServerEntity.sendChanges does. That is what gets a simulated
        // entity's rotation out at all: a mob turns by writing Yaw and nothing passes it through here,
        // so a mover that names neither half used to walk it around still facing where it spawned.
        Angle wantedYaw = yaw ?? entity.Yaw;
        Angle wantedPitch = pitch ?? entity.Pitch;
        bool rotated = wantedYaw.ByteValue != entity.LastSentYaw || wantedPitch.ByteValue != entity.LastSentPitch;

        if (deltaX == 0 && deltaY == 0 && deltaZ == 0) {
            if (rotated) {
                RotateEntity(entity, wantedYaw, wantedPitch);
            }
            else {
                // A head can turn on its own, and often does: a mob watching a player walk past
                // tracks it with its head long before its body catches up.
                SendHeadRotation(entity);
            }

            return;
        }

        if (deltaX > 7.5 || deltaY > 7.5 || deltaZ > 7.5) {  // This packet can't support high values, use teleport
            TeleportEntity(entity, newPos, wantedYaw, wantedPitch);
            return;
        }

        MoveEntityInStorage(entity, entity.Position, newPos);

        Vec3<float> deltaPos = new(
            (float)newPos.X - (float)entity.Position.X,
            (float)newPos.Y - (float)entity.Position.Y,
            (float)newPos.Z - (float)entity.Position.Z);

        if (rotated) {
            SendPacketsToViewers(entity, new ClientBoundUpdateEntityPosAndRotPacket {
                EntityId = entity.NetId,
                Delta = deltaPos,
                Yaw = wantedYaw,
                Pitch = wantedPitch,
                OnGround = true
            });
            RecordSentRotation(entity, wantedYaw, wantedPitch);
        }
        else {
            SendPacketsToViewers(entity, new ClientBoundUpdateEntityPositionPacket {
                EntityId = entity.NetId,
                Delta = deltaPos,
                OnGround = false
            });
        }

        SendHeadRotation(entity);
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

        SendPacketsToViewers(entity, packet);
        RecordSentRotation(entity, yaw, pitch);
        SendHeadRotation(entity);
    }

    /// <summary>
    /// Sends whatever of the entity's rotation has changed since it was last sent, and nothing if
    /// none of it has. This is what covers an entity that turned without moving, since
    /// <see cref="MoveEntity"/> is only reached by one that moved.
    /// </summary>
    public void SyncRotation(Entity entity) {
        if (entity.Yaw.ByteValue != entity.LastSentYaw || entity.Pitch.ByteValue != entity.LastSentPitch) {
            RotateEntity(entity, entity.Yaw, entity.Pitch);
            return;
        }

        SendHeadRotation(entity);
    }

    public void SendSpawnPackets(Entity entity, Player player) {
        if (!entity.ViewableRule(player)) {
            return;
        }
        player.SendPackets(entity.GenerateSpawnEntityPackets());
        AddViewedEntity(player, entity.NetId);
    }

    public void SendDespawnPackets(Entity entity, Player player) {
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
        SendPacketsToViewers(entity, packet);
        RecordSentRotation(entity, yaw, pitch);
        SendHeadRotation(entity);
    }

    /// <summary>
    /// The head's own packet, which carries <see cref="Entity.HeadYaw"/> and not the body yaw. They are
    /// the same thing for a player, whose client reports one rotation, and they are not for a mob:
    /// its look control turns its head and its body rotation control follows behind, so feeding this
    /// the body yaw would throw away the difference the two controls exist to create.
    /// </summary>
    private void SendHeadRotation(Entity entity) {
        Angle headYaw = entity.HeadYaw;
        if (headYaw.ByteValue == entity.LastSentHeadYaw) {
            return;
        }

        SendPacketsToViewers(entity, new ClientBoundSetHeadRotationPacket {
            EntityId = entity.NetId,
            Yaw = headYaw
        });
        entity.LastSentHeadYaw = headYaw.ByteValue;
    }

    private static void RecordSentRotation(Entity entity, Angle yaw, Angle pitch) {
        entity.LastSentYaw = yaw.ByteValue;
        entity.LastSentPitch = pitch.ByteValue;
    }


    private static void AddViewedEntity(Player player, int entityId) {
        if (!player.HasTag(VisibleEntitiesTag)) {
            player.SetTag(VisibleEntitiesTag, []);
        }
        
        player.GetTag(VisibleEntitiesTag).Add(entityId);
    }
    
    private static void RemoveViewedEntity(Player player, int entityId) {
        if (!player.HasTag(VisibleEntitiesTag)) {
            return;
        }
        
        player.GetTag(VisibleEntitiesTag).Remove(entityId);
    }
}