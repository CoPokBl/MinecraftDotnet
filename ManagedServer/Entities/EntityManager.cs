using System.Collections.Concurrent;
using ManagedServer.Entities.Types;
using ManagedServer.Physics;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Implementations;
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

    /// <summary>
    /// The chunk index, copy on write: a reader takes the array and iterates it with no lock, and a
    /// writer replaces it wholesale under <see cref="_chunkIndexLock"/>.
    /// <p/>
    /// It has to be concurrent rather than merely documented as tick-thread-only. Entities are
    /// registered from wherever <c>Entity.SetWorld</c> is called, which on a join is the network
    /// thread, while the tick thread is reading the same index to decide what each player can see.
    /// A plain <see cref="Dictionary{TKey,TValue}"/> resizing under a concurrent read does not throw
    /// reliably, it corrupts its buckets or spins.
    /// </summary>
    private readonly ConcurrentDictionary<Vec2<int>, Entity[]> _entitiesByChunk = new();
    private readonly ConcurrentDictionary<int, Entity> _entitiesById = new();
    private readonly Lock _chunkIndexLock = new();

    /// <summary>
    /// The players registered here, kept as their own list rather than being filtered back out of
    /// every entity.
    /// <p/>
    /// Viewer lookups are the hottest thing this class does: every movement, rotation, velocity change
    /// and metadata write of every entity asks who can see it, several times per entity per tick. Each
    /// of those used to sweep the chunk index over the whole view distance, which at the default eight
    /// chunks is 361 dictionary probes and a LINQ pipeline, to find what is typically a handful of
    /// players. Walking the players directly is the same answer for a fraction of the work and none of
    /// the allocation.
    /// </summary>
    private readonly SnapshotList<Player> _players = new();

    /// <summary>Compared against squared distances, so no square root is taken per candidate.</summary>
    private readonly double _viewDistanceSqr = (double)viewDistanceBlocks * viewDistanceBlocks;

    private int _nextNetId;

    /// <summary>
    /// Ids start at one: vanilla uses zero to mean "not assigned yet" and throws
    /// <c>Tried to access entity ID before ID assignment</c> the moment a client touches an
    /// entity carrying it, which drops the connection.
    /// </summary>
    public int NewNetId => Interlocked.Increment(ref _nextNetId);

    public int EntityCount => _entitiesById.Count;

    public Entity[] GetEntitiesInChunk(Vec2<int> chunkPos) {
        if (!_entitiesByChunk.TryGetValue(chunkPos, out Entity[]? entities) || entities.Length == 0) {
            return [];
        }
        return (Entity[])entities.Clone();
    }

    private void AddToChunkIndex(Vec2<int> chunk, Entity entity) {
        lock (_chunkIndexLock) {
            Entity[] existing = _entitiesByChunk.GetValueOrDefault(chunk) ?? [];
            if (Array.IndexOf(existing, entity) >= 0) return;

            Entity[] updated = new Entity[existing.Length + 1];
            Array.Copy(existing, updated, existing.Length);
            updated[^1] = entity;
            _entitiesByChunk[chunk] = updated;
        }
    }

    private void RemoveFromChunkIndex(Vec2<int> chunk, Entity entity) {
        lock (_chunkIndexLock) {
            if (!_entitiesByChunk.TryGetValue(chunk, out Entity[]? existing)) return;

            int index = Array.IndexOf(existing, entity);
            if (index < 0) return;

            if (existing.Length == 1) {
                _entitiesByChunk.TryRemove(chunk, out _);
                return;
            }

            Entity[] updated = new Entity[existing.Length - 1];
            Array.Copy(existing, updated, index);
            Array.Copy(existing, index + 1, updated, index, existing.Length - index - 1);
            _entitiesByChunk[chunk] = updated;
        }
    }

    /// <summary>
    /// The set of entities a player has been sent, which is read and written from the tick thread,
    /// the network thread and the send pool at once. Guarded on the set itself, which is private to
    /// this class, so no caller can hold it wrongly.
    /// </summary>
    private static bool IsViewing(Player player, int entityId) {
        HashSet<int> visible = player.GetTagOrDefault(VisibleEntitiesTag, []);
        lock (visible) return visible.Contains(entityId);
    }

    /// <summary>
    /// Adds an entity to the manager and sends spawn packets to all viewers.
    /// DO NOT CALL DIRECTLY. Use <see cref="Entity.SetWorld"/>.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="id"></param>
    public void Register(Entity entity, int? id = null) {
        entity.NetId = id ?? NewNetId;

        // Straight into the index rather than through MoveEntityInStorage. That method's second half
        // announces a chunk crossing to the viewers of entity.World, and on this path entity.World is
        // still the world the entity is *leaving*: registering a player into their game world told
        // everyone back in the lobby to spawn them. The spawn broadcast below is this world's, and is
        // the only one wanted here.
        AddToChunkIndex(World.GetChunkPos(entity.Position), entity);
        _entitiesById[entity.NetId] = entity;
        if (entity is Player player) {
            _players.Add(player);
        }

        MinecraftPacket[] spawnPackets = entity.GenerateSpawnEntityPackets();
        foreach (Player viewer in GetViewersOf(entity)) {
            viewer.SendPackets(spawnPackets);
            AddViewedEntity(viewer, entity.NetId);
        }
    }

    public void Despawn(Entity entity) {
        // Removed by identity, not just by id, and only once. Despawning is reached from a disconnect,
        // which two threads can notice at the same moment, and a plain remove by id would take out
        // whatever now holds that id if one has been reused.
        if (!_entitiesById.TryRemove(new KeyValuePair<int, Entity>(entity.NetId, entity))) {
            return;
        }

        if (entity is Player player) {
            _players.Remove(player);
        }

        RemoveFromChunkIndex(World.GetChunkPos(entity.Position), entity);

        // Told to exactly the players recorded as holding it, rather than to whoever is in range now.
        // Those are not the same set: a player who walked away has already been sent a despawn by the
        // viewport reconcile, and one whose ViewableRule turned false since would be missed. Untracking
        // is the same pass, so nothing is left recorded as seeing an entity that no longer exists; a
        // stale id there is what makes a later entity registered with an explicit net id (a player's,
        // which is random rather than sequential) silently never spawn.
        ClientBoundRemoveEntitiesPacket packet = new() {
            Entities = [entity.NetId]
        };

        foreach (Player viewer in _players.Snapshot) {
            if (!ReferenceEquals(viewer, entity) && RemoveViewedEntity(viewer, entity.NetId)) {
                viewer.SendPacket(packet);
            }
        }
    }

    public void RefreshViewers(Entity entity) {
        Vec3<double> pos = entity.Position;

        foreach (Player player in _players.Snapshot) {
            if (CanSee(player, entity, pos, true)) {
                SyncVisibility(entity, player);
            }
        }
    }

    public void RefreshPlayerVisibleEntities(Player player) {
        foreach (Entity entity in GetNearbyEntities(player.Position, viewDistanceBlocks)) {
            if (entity != player) {
                SyncVisibility(entity, player);
            }
        }
    }

    /// <summary>
    /// Brings one client's idea of one entity in line with its <see cref="Entity.ViewableRule"/>, and
    /// sends nothing when it already agrees. Both refresh paths are this same question asked over a
    /// different set.
    /// </summary>
    private void SyncVisibility(Entity entity, Player player) {
        bool visible = IsViewing(player, entity.NetId);

        if (entity.ViewableRule(player)) {
            if (!visible) {
                SendSpawnPackets(entity, player);
            }
        }
        else if (visible) {
            SendDespawnPackets(entity, player);
        }
    }

    private void MoveEntityInStorage(Entity entity, Vec3<double> from, Vec3<double> to) {
        Vec2<int> fromChunk = World.GetChunkPos(from);
        Vec2<int> toChunk = World.GetChunkPos(to);

        if (fromChunk == toChunk) {
            return;
        }
        
        RemoveFromChunkIndex(fromChunk, entity);
        AddToChunkIndex(toChunk, entity);

        // Read once. The entity can be despawned by a disconnect on another thread part way through
        // this, and reading it again below would then be a null dereference, or a throw out of
        // Entity.Server, in the middle of somebody else's move.
        World? world = entity.World;
        if (world == null) {
            return;
        }

        // Inform viewers of the chunk change. We schedule on the next tick because
        // entity.Position is set by Entity.Move *after* this method returns, and the
        // spawn packet needs the new position. On next tick we build the packets
        // (cheap) on the tick thread, then hand the socket write to the pool so the
        // tick itself doesn't block on serialisation/network I/O.
        foreach (Player player in world.GetViewersOf(toChunk)) {
            if (ReferenceEquals(player, entity)) continue;
            if (world.DoesPlayerHaveChunkLoaded(player, fromChunk)) continue;

            Player capturedPlayer = player;
            world.Server.Scheduler.ScheduleNextTick(() => {
                if (capturedPlayer.Connection.IsDisconnected) return;
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

    /// <summary>
    /// Writes packets to everyone who can see an entity, without building the viewer list first. This
    /// is the broadcast every moving entity performs several times a tick, so it walks the player
    /// snapshot in place: no array, no audience wrapper, no LINQ.
    /// </summary>
    public void SendPacketsToViewers(Entity entity, params MinecraftPacket[] packets) {
        if (packets.Length == 0) {
            return;
        }

        Vec3<double> pos = entity.Position;

        foreach (Player player in _players.Snapshot) {
            if (!CanSee(player, entity, pos, false)) {
                continue;
            }

            foreach (MinecraftPacket packet in packets) {
                player.SendPacket(packet);
            }
        }
    }

    public Entity? GetEntity(int id) {
        return _entitiesById.GetValueOrDefault(id);
    }

    public Entity[] GetEntities() {
        return _entitiesById.Values.ToArray();
    }

    public Player? GetPlayerByConnection(PlayerConnection connection) {
        foreach (Player player in _players.Snapshot) {
            if (player.Connection == connection) {
                return player;
            }
        }

        return null;
    }

    public Player[] GetViewersOf(Entity entity, bool ignoreViewableRule = false) {
        Player[] players = _players.Snapshot;
        if (players.Length == 0) {
            return [];
        }

        Vec3<double> pos = entity.Position;
        Player[] buffer = new Player[players.Length];
        int count = 0;

        foreach (Player player in players) {
            if (CanSee(player, entity, pos, ignoreViewableRule)) {
                buffer[count++] = player;
            }
        }

        if (count == buffer.Length) {
            return buffer;
        }

        Player[] result = new Player[count];
        Array.Copy(buffer, result, count);
        return result;
    }

    /// <summary>
    /// Whether a player is close enough to an entity to be sent its packets, and allowed to be. The
    /// entity's own position is passed in rather than read here, so a broadcast reads it once instead
    /// of once per player, and so every player in one broadcast is judged against the same position.
    /// <p/>
    /// An entity is never its own viewer. That is vanilla's <c>ChunkMap.TrackedEntity.updatePlayer</c>
    /// returning early for the tracked entity, and it is what keeps a player's own metadata from
    /// reaching them; see the note on <see cref="Entity.Meta"/> for why that matters.
    /// </summary>
    private bool CanSee(Player player, Entity entity, Vec3<double> entityPos, bool ignoreViewableRule) {
        if (ReferenceEquals(player, entity)) {
            return false;
        }

        return SquaredDistance(player.Position, entityPos) < _viewDistanceSqr
               && (ignoreViewableRule || entity.ViewableRule(player));
    }

    /// <summary>Every player in this world. The array is shared, so it must not be written to.</summary>
    public Player[] GetPlayers() {
        return _players.Snapshot;
    }

    public Entity[] GetNearbyEntities(Vec3<double> pos, double distance) {
        double distanceSqr = distance * distance;
        List<Entity> entities = [];

        foreach (Entity entity in CandidatesAround(pos, distance)) {
            if (SquaredDistance(entity.Position, pos) < distanceSqr) {
                entities.Add(entity);
            }
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
                if (!_entitiesByChunk.TryGetValue(new Vec2<int>(x, z), out Entity[]? chunkEntities)) {
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
        Vec2<int> centre = World.GetChunkPos(pos);

        // The chunk walk is written out rather than going through GetChunksInRadius, which is a second
        // iterator wrapped around this one for every call.
        for (int dx = -chunkRadius; dx <= chunkRadius; dx++) {
            for (int dz = -chunkRadius; dz <= chunkRadius; dz++) {
                if (!_entitiesByChunk.TryGetValue(new Vec2<int>(centre.X + dx, centre.Y + dz),
                        out Entity[]? chunkEntities)) {
                    continue;
                }

                foreach (Entity entity in chunkEntities) {
                    yield return entity;
                }
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
        player.SendPackets(TrackSpawn(entity, player));
    }

    public void SendDespawnPackets(Entity entity, Player player) {
        player.SendPackets(TrackDespawn(entity, player));
    }

    /// <summary>
    /// Records the entity as visible to the player and hands back the packets that say so, instead
    /// of writing them. A caller that is streaming a viewport wants these to travel in its own queue
    /// rather than going straight to the socket: it is on the tick thread, and a socket write there
    /// blocks every other player behind whichever client is slowest.
    /// <p/>
    /// Empty when the entity is not visible to that player, which keeps the caller from having to
    /// ask separately.
    /// </summary>
    public MinecraftPacket[] TrackSpawn(Entity entity, Player player) {
        if (!entity.ViewableRule(player)) {
            return [];
        }

        MinecraftPacket[] packets = entity.GenerateSpawnEntityPackets();
        AddViewedEntity(player, entity.NetId);
        return packets;
    }

    /// <summary>The despawn half of <see cref="TrackSpawn"/>.</summary>
    public MinecraftPacket[] TrackDespawn(Entity entity, Player player) {
        RemoveViewedEntity(player, entity.NetId);
        return [new ClientBoundRemoveEntitiesPacket {
            Entities = [entity.NetId]
        }];
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

        HashSet<int> visible = player.GetTag(VisibleEntitiesTag);
        lock (visible) visible.Add(entityId);
    }
    
    /// <summary>Forgets an entity, answering whether the player was being shown it.</summary>
    private static bool RemoveViewedEntity(Player player, int entityId) {
        if (!player.HasTag(VisibleEntitiesTag)) {
            return false;
        }

        HashSet<int> visible = player.GetTag(VisibleEntitiesTag);
        lock (visible) return visible.Remove(entityId);
    }
}