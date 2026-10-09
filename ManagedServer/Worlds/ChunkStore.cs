using System.Collections.Concurrent;
using ManagedServer.Worlds.Lighting;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Worlds;

/// <summary>
/// A world's chunks, their loading, and the packet each one currently serialises to.
/// <p/>
/// The store exists because three separate things have to agree about when a chunk changed: the data
/// itself, the light computed over it, and the packet built from both. One
/// <c>ChunkEntry.Version</c> per chunk is what they agree on. Every mutation bumps it, a build
/// records the version it was built from, and a build whose version moved underneath it is discarded
/// rather than published. Without that, a packet built from an older snapshot can be installed over
/// a newer one and stay wrong for as long as the chunk is left alone.
/// </summary>
/// <remarks>
/// Locks here are leaves. <c>ChunkEntry.Build</c> is held across a lighting computation and may take
/// another entry's <c>Write</c> to read a neighbour, but a <c>Write</c> is never held while taking
/// anything else, so the two cannot cycle.
/// </remarks>
internal sealed class ChunkStore {
    /// <summary>A built packet and the version it was built from, as one reference so a reader
    /// cannot pair a new packet with an old version.</summary>
    private sealed record Built(MinecraftPacket Packet, long Version);

    /// <summary>
    /// A chunk and everything derived from it. Kept as one object so a caller resolves the position
    /// once and then works against the entry, rather than hashing per access on the send path.
    /// </summary>
    private sealed class ChunkEntry {
        public required Vec2<int> Position { get; init; }

        /// <summary>
        /// Completed by the loader. Continuations are forced asynchronous: this one computes light,
        /// and it must never run inline on whichever thread happened to finish the load, which on a
        /// join is the network thread and with a fast terrain provider is every single chunk.
        /// </summary>
        public readonly TaskCompletionSource<ChunkData> Completion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public Task<ChunkData> Load => Completion.Task;

        /// <summary>Guards the chunk's contents, and therefore snapshotting them.</summary>
        public readonly Lock Write = new();

        /// <summary>Serialises builds so several players share one, rather than each doing its own.</summary>
        public readonly Lock Build = new();

        /// <summary>
        /// Bumped by every block write and by anything that changes the light over this chunk,
        /// including a change in one of the eight around it.
        /// </summary>
        public long Version;

        /// <summary>
        /// Bumped only by writes to this chunk's own contents, which is what persistence keys off.
        /// <p/>
        /// <see cref="Version"/> cannot be used for it: a neighbour loading moves the light over this
        /// chunk and so moves that counter, which would mark most of a freshly generated world as
        /// changed and save terrain identical to what the generator would produce.
        /// </summary>
        public long ContentVersion;

        /// <summary>
        /// The <see cref="ContentVersion"/> a sink last took. Negative until something has stored this
        /// chunk, so a generated chunk starts out owed a save and a chunk read back from storage does
        /// not.
        /// </summary>
        public long SavedVersion = -1;

        public ChunkData? Snapshot;
        public long SnapshotVersion = -1;

        /// <summary>
        /// The <see cref="ContentVersion"/> <see cref="Snapshot"/> was taken at. Matching
        /// <see cref="SnapshotVersion"/> alone is not enough: a write bumps the content version under the
        /// lock and <see cref="Version"/> only after releasing it, so in between, a snapshot that matches
        /// the version is from before the write.
        /// </summary>
        public long SnapshotContentVersion = -1;

        public Built? Built;
    }

    private readonly ConcurrentDictionary<Vec2<int>, ChunkEntry> _entries = new();
    private readonly ITerrainProvider _provider;
    private readonly ILightingProvider _lighting;
    private readonly MinecraftRegistry _registry;
    private readonly int _worldHeight;
    private readonly int _minY;
    private readonly bool _hasSkyLight;
    private readonly Action<Exception?> _onError;
    private readonly ChunkGenerationQueue _generation;

    /// <summary>
    /// Raised once per chunk, off the tick thread, when its terrain has arrived. The world turns
    /// this into light corrections for the chunks around it.
    /// </summary>
    public event Action<Vec2<int>>? ChunkLoaded;

    /// <summary>
    /// Raised when a chunk's own contents change, which is the signal persistence runs on. Inert
    /// with nothing subscribed, and never raised for a light change in a neighbour.
    /// </summary>
    public event Action<Vec2<int>>? ChunkChanged;

    public ChunkStore(ITerrainProvider provider, ILightingProvider lighting, MinecraftRegistry registry,
        int worldHeight, int minY, bool hasSkyLight, Action<Exception?> onError,
        ChunkGenerationQueue generation) {

        _provider = provider;
        _lighting = lighting;
        _registry = registry;
        _worldHeight = worldHeight;
        _minY = minY;
        _hasSkyLight = hasSkyLight;
        _onError = onError;
        _generation = generation;
    }

    // ── loading ─────────────────────────────────────────────────────────────

    public Task<ChunkData> Load(Vec2<int> pos) => Entry(pos).Load;

    /// <summary>Starts a load without waiting for it, which is what the streaming path wants.</summary>
    public void EnsureLoading(Vec2<int> pos) => Entry(pos);

    public bool IsLoaded(Vec2<int> pos) {
        return _entries.TryGetValue(pos, out ChunkEntry? entry) && entry.Load.IsCompletedSuccessfully;
    }

    /// <summary>
    /// Whether a chunk and all eight around it are loaded, which is exactly the condition under which
    /// nothing arriving later can change the light over it.
    /// </summary>
    public bool NeighbourhoodLoaded(Vec2<int> pos) {
        for (int dz = -1; dz <= 1; dz++) {
            for (int dx = -1; dx <= 1; dx++) {
                if (!IsLoaded(new Vec2<int>(pos.X + dx, pos.Y + dz))) {
                    return false;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// The live chunk, for block reads. Never serialise this: use <see cref="BuildPacket"/>, which
    /// goes through a snapshot.
    /// </summary>
    public ChunkData? TryGet(Vec2<int> pos) {
        return _entries.TryGetValue(pos, out ChunkEntry? entry) && entry.Load.IsCompletedSuccessfully
            ? entry.Load.Result
            : null;
    }

    public ChunkData LoadBlocking(Vec2<int> pos) => Entry(pos).Load.GetAwaiter().GetResult();

    /// <summary>
    /// <c>ConcurrentDictionary.GetOrAdd</c> can run a factory more than once and keep only one
    /// result, so the load is not started inside one. The entry is built cold, and only the caller
    /// that actually won the slot starts it: a losing loader would otherwise run to completion and
    /// publish over a chunk no one else can reach.
    /// </summary>
    private ChunkEntry Entry(Vec2<int> pos) {
        if (_entries.TryGetValue(pos, out ChunkEntry? existing)) {
            return existing;
        }

        ChunkEntry created = new() { Position = pos };
        ChunkEntry actual = _entries.GetOrAdd(pos, created);
        if (!ReferenceEquals(actual, created)) {
            return actual;
        }

        StartLoad(created);
        return created;
    }

    /// <summary>
    /// Posted to the shared generation queue rather than straight to the pool. A viewport is asked
    /// for in one tick, so an unbounded post here is what puts every packet the server has to answer
    /// behind the whole of it.
    /// </summary>
    private void StartLoad(ChunkEntry entry) {
        _generation.Post(() => {
            try {
                entry.Completion.SetResult(LoadCore(entry.Position, entry));
            } catch (Exception e) {
                // Dropped from the store so a later request retries rather than inheriting the
                // failure for the lifetime of the world.
                _entries.TryRemove(entry.Position, out _);
                entry.Completion.SetException(e);
                _onError(e);
                return;
            }

            try {
                ChunkLoaded?.Invoke(entry.Position);
            } catch (Exception e) {
                _onError(e);
            }
        });
    }

    private ChunkData LoadCore(Vec2<int> pos, ChunkEntry entry) {
        ChunkData data = new(_worldHeight) { ChunkX = pos.X, ChunkZ = pos.Y, MinY = _minY };

        // A store says whether it actually had the chunk, and a chunk it did not have is terrain
        // nothing has written down. That is the same state a block write leaves a chunk in, so a
        // generated chunk is picked up by the next pass over changed chunks without asking.
        bool stored = _provider is ITerrainStore store ? store.TryGetChunk(ref data) : Generate(ref data);
        entry.SavedVersion = stored ? 0 : -1;

        if (data == null!) {
            throw new InvalidOperationException($"Terrain provider returned null for chunk {pos}.");
        }

        // Stamped again because the provider takes the chunk by reference and a loader may have
        // swapped in a different object: PolarLoader and AnvilLoader both answer with a clone of a
        // chunk they hold. The one that came back is the one the world will use.
        data.MinY = _minY;

        data.PackData(_registry);
        return data;
    }

    /// <summary>A plain provider has no way to say it had nothing, so nothing it makes counts as stored.</summary>
    private bool Generate(ref ChunkData data) {
        _provider.GetChunk(ref data);
        return false;
    }

    // ── mutation ────────────────────────────────────────────────────────────

    /// <summary>
    /// Applies a write to a chunk and marks everything derived from it stale.
    /// <p/>
    /// The lock is not paranoia. <c>ChunkData.Write</c> reaches its sections through
    /// <c>ChunkSection.Palette</c>, whose getter repacks in place, so serialising a chunk is itself a
    /// mutation and a write racing it can null the array the serialiser is halfway through. The
    /// world's contract says block writes happen on the tick thread, but <c>SetBlocksAsync</c>
    /// resumes on a pool thread after awaiting its loads, so that was never quite true.
    /// <p/>
    /// <b>Blocks for a full chunk generation when the target is not loaded</b>, and
    /// <c>World.SetBlock</c> reaches this from the tick thread, so a write into unloaded terrain
    /// stalls the whole server for as long as generating that chunk takes. It waits because
    /// <c>SetBlock</c> is synchronous to its caller: a write that returned before the chunk existed
    /// would not be visible to the <c>GetBlock</c> after it. Use <c>SetBlocksAsync</c>, or load the
    /// chunk first, for a write that might land outside what is loaded.
    /// </summary>
    public void Write(Vec2<int> pos, Action<ChunkData> mutate) {
        ChunkEntry entry = Entry(pos);
        ChunkData data = entry.Load.GetAwaiter().GetResult();

        lock (entry.Write) {
            mutate(data);
            Interlocked.Increment(ref entry.ContentVersion);
        }

        InvalidateLightAround(pos);

        try {
            ChunkChanged?.Invoke(pos);
        } catch (Exception e) {
            _onError(e);
        }
    }

    // -- persistence ---------------------------------------------------------

    /// <summary>Chunks that have been written to, or generated, since anything last stored them.</summary>
    public bool IsDirty(Vec2<int> pos) {
        return _entries.TryGetValue(pos, out ChunkEntry? entry)
               && entry.Load.IsCompletedSuccessfully
               && Interlocked.Read(ref entry.ContentVersion) != Interlocked.Read(ref entry.SavedVersion);
    }

    public IEnumerable<Vec2<int>> LoadedChunks() {
        foreach (KeyValuePair<Vec2<int>, ChunkEntry> pair in _entries) {
            if (pair.Value.Load.IsCompletedSuccessfully) {
                yield return pair.Key;
            }
        }
    }

    /// <summary>
    /// A chunk as it stands, safe to serialise from another thread, together with the content version
    /// it represents.
    /// </summary>
    /// <remarks>
    /// The same snapshot the send path builds, so a chunk anybody has been sent recently costs nothing
    /// to capture. Never save the live chunk: <c>ChunkSection.Palette</c>'s getter repacks in place, so
    /// a writer racing an encode can null the array halfway through it.
    /// </remarks>
    public ChunkData? SnapshotFor(Vec2<int> pos, out long contentVersion) {
        contentVersion = 0;
        if (!_entries.TryGetValue(pos, out ChunkEntry? entry) || !entry.Load.IsCompletedSuccessfully) {
            return null;
        }

        return SnapshotOf(entry, out _, out contentVersion);
    }

    /// <summary>
    /// Records that a sink has taken this chunk as of <paramref name="contentVersion"/>.
    /// </summary>
    /// <remarks>
    /// The version is the one the snapshot was taken at rather than the one now, so a write that
    /// landed while the chunk was being encoded leaves it dirty and is saved by the next pass. Marking
    /// it clean against the current version would drop that write until something touched the chunk
    /// again.
    /// </remarks>
    public void MarkSaved(Vec2<int> pos, long contentVersion) {
        if (_entries.TryGetValue(pos, out ChunkEntry? entry)) {
            Interlocked.Exchange(ref entry.SavedVersion, contentVersion);
        }
    }

    /// <summary>
    /// Marks a chunk and the eight around it as changed. Light crosses fifteen blocks, so a block
    /// written in one chunk moves the light in all of its neighbours, diagonals included, and their
    /// packets are stale too.
    /// <p/>
    /// Versions are bumped <em>before</em> anything acts on the change, which is what makes a light
    /// correction safe: a build already running for any of these nine can no longer publish, and the
    /// world's scan of who holds them cannot be overtaken by a send that has not recorded itself yet.
    /// </summary>
    public void InvalidateLightAround(Vec2<int> pos) {
        _lighting.Invalidate(pos);

        for (int dz = -1; dz <= 1; dz++) {
            for (int dx = -1; dx <= 1; dx++) {
                if (_entries.TryGetValue(pos + new Vec2<int>(dx, dz), out ChunkEntry? entry)) {
                    Interlocked.Increment(ref entry.Version);
                }
            }
        }
    }

    // ── building ────────────────────────────────────────────────────────────

    /// <summary>
    /// The chunk's packet as of now, shared by every player owed it. Null when the chunk is not
    /// loaded, which the streaming path reads as "not ready yet" rather than as a failure.
    /// </summary>
    /// <remarks>
    /// The packet object rather than its bytes, deliberately. A frame could be cached here and shared
    /// between recipients, and <see cref="PreSerialisedPacket"/> is the protocol layer's way to send
    /// one, but doing it changes the type every listener on the send path sees a chunk arrive as. A
    /// re-serialisation is a fraction of a millisecond against the tens a chunk costs to generate, so
    /// that is not a trade worth making here.
    /// </remarks>
    public MinecraftPacket? BuildPacket(Vec2<int> pos) => Build(pos)?.Packet;

    private Built? Build(Vec2<int> pos) {
        if (!_entries.TryGetValue(pos, out ChunkEntry? entry) || !entry.Load.IsCompletedSuccessfully) {
            return null;
        }

        Built? built = entry.Built;
        if (built != null && built.Version == Interlocked.Read(ref entry.Version)) {
            return built;
        }

        lock (entry.Build) {
            ChunkData snapshot = SnapshotOf(entry, out long version, out _);

            built = entry.Built;
            if (built != null && built.Version == version) {
                return built;
            }

            MinecraftPacket packet = new ClientBoundChunkDataAndUpdateLightPacket {
                ChunkX = pos.X,
                ChunkZ = pos.Y,
                Data = snapshot,
                Light = _lighting.GetLighting(pos, snapshot, SnapshotLookup, _registry, _hasSkyLight)
            };

            Built fresh = new(packet, version);

            // Published only if nothing moved while we built. Otherwise this answer is already old,
            // and installing it would hide the newer one until the chunk happened to change again.
            if (Interlocked.Read(ref entry.Version) == version) {
                entry.Built = fresh;
            }

            return fresh;
        }
    }

    /// <summary>
    /// Neighbours are read as snapshots too. The lighting pass walks their sections through the same
    /// repacking getter that serialising uses, so handing it live chunks races a writer just as
    /// surely as serialising one would.
    /// </summary>
    private ChunkData? SnapshotLookup(Vec2<int> pos) {
        if (!_entries.TryGetValue(pos, out ChunkEntry? entry) || !entry.Load.IsCompletedSuccessfully) {
            return null;
        }
        return SnapshotOf(entry, out _, out _);
    }

    /// <remarks>
    /// The snapshot is <b>packed before it is published</b>, and that is a correctness requirement
    /// rather than a saving. A snapshot is shared by every player owed the chunk and serialised by
    /// each of them at once, and <c>ChunkSection.Palette</c>'s getter repacks in place: two threads
    /// reaching an unpacked section together each build their own palette and one of them is left
    /// reading an array the other has already nulled. Packed here, under the same lock that guards
    /// the clone, every later reader only ever sees an immutable palette.
    /// </remarks>
    private ChunkData SnapshotOf(ChunkEntry entry, out long version, out long contentVersion) {
        ChunkData live = entry.Load.Result;

        lock (entry.Write) {
            long current = Interlocked.Read(ref entry.Version);
            long content = Interlocked.Read(ref entry.ContentVersion);
            version = current;
            contentVersion = content;

            if (entry.Snapshot != null && entry.SnapshotVersion == current
                && entry.SnapshotContentVersion == content) {
                return entry.Snapshot;
            }

            ChunkData snapshot = live.Snapshot();
            snapshot.PackData(_registry);
            entry.Snapshot = snapshot;
            entry.SnapshotVersion = current;
            entry.SnapshotContentVersion = content;
            return snapshot;
        }
    }
}
