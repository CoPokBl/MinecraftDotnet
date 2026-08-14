using System.Diagnostics;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Worlds;

/// <summary>
/// What one player has been given of a world and what they are still owed.
/// <p/>
/// The streaming model is a reconcile rather than a push: the view holds the chunk positions the
/// client should end up with, and every tick moves as many of them as are ready onto the wire. A
/// position that is not loaded yet stays where it is and is tried again, so nothing can be lost by
/// arriving at an awkward moment. The old model built a packet when a chunk finished loading and
/// pushed it at whoever looked eligible at that instant, which meant a player who was mid-join, or
/// who had just been teleported, was skipped and never retried.
/// </summary>
internal sealed class PlayerChunkView {
    /// <summary>
    /// Guards every field below. Held only for bookkeeping: never across a socket write, a lighting
    /// build, or an entity lookup.
    /// </summary>
    public readonly Lock Lock = new();

    /// <summary>
    /// The chunk the player is standing in. Set before the player is visible to the streaming loop
    /// and never null afterwards, which is the whole fix: a delivery that arrives before the centre
    /// is known has nothing to test itself against and used to be dropped outright.
    /// </summary>
    public Vec2<int> Centre;

    /// <summary>
    /// Set by anything that moves the player or invalidates their viewport, cleared by the tick that
    /// acts on it. A flag rather than a scheduled callback so several moves in one tick collapse
    /// into one diff, and so nothing outlives a player who leaves.
    /// </summary>
    public bool NeedsReconcile = true;

    /// <summary>
    /// The chunks the client holds. Cleared only by an unload, a reset, or the player leaving:
    /// notably <em>not</em> by queueing a light correction, because the client still has the chunk
    /// while a better version of it is on its way. <c>Reconcile</c> derives unloads from this, and
    /// the entity manager reads it to decide whether a mover needs a spawn packet, so flickering it
    /// would strand chunks on the client and duplicate entity spawns.
    /// </summary>
    public readonly HashSet<Vec2<int>> Sent = [];

    /// <summary>Positions still owed, nearest first. A position in both this and <see cref="Sent"/>
    /// is a pending light correction, which is a legal state.</summary>
    public readonly List<Vec2<int>> Pending = [];

    /// <summary>Membership of <see cref="Pending"/>, so queueing stays O(1).</summary>
    public readonly HashSet<Vec2<int>> Queued = [];

    /// <summary>
    /// Ready-made packets that must precede the chunks of this flush: the centre marker, and the
    /// unloads and entity despawns that go with it. The client sizes its chunk cache around the last
    /// centre it was told and discards chunks outside it, so a centre marker stuck behind a few
    /// hundred chunk packets would make it throw away chunks it will never be sent again.
    /// </summary>
    public readonly Queue<MinecraftPacket> Leading = new();

    /// <summary>Packets that must follow this flush's chunks, which is entity spawns: an entity
    /// belongs to a chunk the client should already have.</summary>
    public readonly Queue<MinecraftPacket> Trailing = new();

    /// <summary>
    /// Bumped by anything that invalidates work already handed to a send task. A batch captures it
    /// and stops if it has moved, so chunks dequeued before a reset cannot be written after the
    /// respawn packet that replaced the world underneath them.
    /// </summary>
    public int Epoch;

    public volatile bool Disconnected;
    public Action? CancelMoveListener;
    public Action? DisconnectHandler;

    /// <summary>Interlocked, so <c>RemovePlayer</c> is idempotent.</summary>
    public int RemovedFlag;

    /// <summary>Interlocked. One socket write in flight per player, which keeps a slow client from
    /// queueing up batches and keeps every send for that player strictly ordered.</summary>
    public int SendInProgress;

    /// <summary>What a flush hands to the send task.</summary>
    internal readonly record struct Batch(
        MinecraftPacket[] Leading,
        Vec2<int>[] Chunks,
        MinecraftPacket[] Trailing,
        int Epoch) {

        public bool IsEmpty => Leading.Length == 0 && Chunks.Length == 0 && Trailing.Length == 0;
    }

    /// <summary>The result of a diff, for the caller to act on outside the lock.</summary>
    internal readonly record struct Diff(Vec2<int>[] Unloaded, Vec2<int>[] Added);

    /// <summary>
    /// Brings the wanted set in line with the centre. Cheap and allocation-light by design: it does
    /// no packet building, no lighting and no I/O, so it is safe to run for every player on the tick
    /// thread.
    /// </summary>
    /// <param name="offsetsNearestFirst">
    /// The viewport offsets ordered by distance, computed once per world. Nearest first is what gets
    /// the chunk the player is standing in onto the wire first, which is what ends their loading
    /// screen.
    /// </param>
    public Diff Reconcile(int viewDistance, int unloadDistance, Vec2<int>[] offsetsNearestFirst) {
        lock (Lock) {
            if (!NeedsReconcile) {
                return new Diff([], []);
            }
            NeedsReconcile = false;

            Vec2<int> centre = Centre;

            // Chunks the client holds that have fallen outside the hysteresis band.
            List<Vec2<int>> unloaded = [];
            foreach (Vec2<int> pos in Sent) {
                if (!pos.IsWithinRadiusOf(centre, unloadDistance)) {
                    unloaded.Add(pos);
                }
            }
            foreach (Vec2<int> pos in unloaded) {
                Sent.Remove(pos);
            }

            // Positions still owed but no longer wanted are dropped, never unloaded: the client was
            // never told about them. A pending correction for a chunk the client does have is judged
            // by the unload distance instead, so it survives exactly as long as the chunk it fixes.
            int write = 0;
            for (int read = 0; read < Pending.Count; read++) {
                Vec2<int> pos = Pending[read];
                bool wanted = pos.IsWithinRadiusOf(centre, viewDistance)
                              || (Sent.Contains(pos) && pos.IsWithinRadiusOf(centre, unloadDistance));

                if (!wanted) {
                    Queued.Remove(pos);
                    continue;
                }

                Pending[write++] = pos;
            }
            Pending.RemoveRange(write, Pending.Count - write);

            Leading.Enqueue(new ClientBoundSetCenterChunkPacket { X = centre.X, Z = centre.Y });
            foreach (Vec2<int> pos in unloaded) {
                // The two must not disagree: an unload for something still queued would be undone by
                // the chunk that follows it. Dropping out-of-range pending positions above is what
                // keeps this true.
                Debug.Assert(!Queued.Contains(pos),
                    $"chunk {pos} is being unloaded while still queued to be sent");
                Leading.Enqueue(new ClientBoundUnloadChunkPacket { X = pos.X, Z = pos.Y });
            }

            List<Vec2<int>> added = [];
            foreach (Vec2<int> offset in offsetsNearestFirst) {
                Vec2<int> pos = centre + offset;
                if (Sent.Contains(pos) || !Queued.Add(pos)) {
                    continue;
                }
                Pending.Add(pos);
                added.Add(pos);
            }

            return new Diff(unloaded.ToArray(), added.ToArray());
        }
    }

    /// <summary>
    /// Takes as much as this flush can carry: everything leading, then up to <paramref name="budget"/>
    /// chunks that are ready, then everything trailing.
    /// <p/>
    /// A position whose chunk has not loaded is left where it is rather than blocking the ones behind
    /// it, so slow terrain costs latency and never delivery. <paramref name="scanLimit"/> bounds the
    /// walk so a player waiting on a lot of terrain cannot make the tick sweep their whole viewport
    /// every time.
    /// <p/>
    /// A taken position is recorded in <see cref="Sent"/> <em>here</em>, inside the same critical
    /// section that removed it from <see cref="Pending"/>, and not when the write completes. That is
    /// what closes the light correction race: an invalidation either lands before this and finds the
    /// position still queued, so the build that follows picks up the new light, or lands after it and
    /// finds the position in <see cref="Sent"/>, so it queues a correction behind it. If the recording
    /// happened at write time there would be a third case, a build already running and visible to
    /// nobody, whose stale packet would be the last thing the client ever received for that chunk.
    /// </summary>
    public Batch TakeBatch(int budget, int scanLimit, Func<Vec2<int>, bool> isLoaded,
        List<Vec2<int>> toLoad) {

        lock (Lock) {
            MinecraftPacket[] leading = Leading.Count > 0 ? Leading.ToArray() : [];
            Leading.Clear();

            List<Vec2<int>> chunks = [];
            int examined = 0;
            int write = 0;

            for (int read = 0; read < Pending.Count; read++) {
                Vec2<int> pos = Pending[read];

                if (chunks.Count < budget && examined < scanLimit) {
                    examined++;
                    if (isLoaded(pos)) {
                        Queued.Remove(pos);
                        Sent.Add(pos);
                        chunks.Add(pos);
                        continue;
                    }

                    toLoad.Add(pos);
                }

                Pending[write++] = pos;
            }

            Pending.RemoveRange(write, Pending.Count - write);

            MinecraftPacket[] trailing = Trailing.Count > 0 ? Trailing.ToArray() : [];
            Trailing.Clear();

            return new Batch(leading, chunks.ToArray(), trailing, Epoch);
        }
    }

    /// <summary>Queues packets that must precede this flush's chunks, such as entity despawns that
    /// pair with an unload.</summary>
    public void EnqueueLeading(ReadOnlySpan<MinecraftPacket> packets) {
        if (packets.Length == 0) return;
        lock (Lock) {
            foreach (MinecraftPacket packet in packets) Leading.Enqueue(packet);
        }
    }

    /// <summary>Queues packets that must follow this flush's chunks, such as the spawn packets for
    /// entities standing in a chunk the client is about to be given.</summary>
    public void EnqueueTrailing(ReadOnlySpan<MinecraftPacket> packets) {
        if (packets.Length == 0) return;
        lock (Lock) {
            foreach (MinecraftPacket packet in packets) Trailing.Enqueue(packet);
        }
    }

    /// <summary>
    /// Queues a chunk the client already has to be sent again, because the light over it changed.
    /// Appended at the tail so it lands behind the packet it is correcting: the client drops light
    /// for a chunk it does not hold, so a correction that overtook its chunk would leave the wrong
    /// light on screen permanently.
    /// <p/>
    /// A chunk that is merely pending needs nothing. It has not been built yet, and the build that
    /// eventually happens reads the new light for free.
    /// </summary>
    public void RequeueForLight(ReadOnlySpan<Vec2<int>> positions) {
        lock (Lock) {
            foreach (Vec2<int> pos in positions) {
                if (!Sent.Contains(pos)) {
                    continue;
                }
                if (!Queued.Add(pos)) {
                    continue;
                }
                Pending.Add(pos);
            }
        }
    }

    /// <summary>
    /// Puts back chunks a batch could not write, and unrecords them so they are genuinely re-sent.
    /// Used when a send throws part way through, which otherwise loses every chunk behind the
    /// failure while leaving them marked as delivered.
    /// </summary>
    public void ReturnUnsent(ReadOnlySpan<Vec2<int>> positions) {
        lock (Lock) {
            for (int i = positions.Length - 1; i >= 0; i--) {
                Vec2<int> pos = positions[i];
                Sent.Remove(pos);
                if (Queued.Add(pos)) {
                    Pending.Insert(0, pos);
                }
            }
        }
    }

    /// <summary>Throws away everything the client was told, so the viewport streams from scratch.</summary>
    public void Reset(Vec2<int> centre) {
        lock (Lock) {
            Sent.Clear();
            Pending.Clear();
            Queued.Clear();
            Leading.Clear();
            Trailing.Clear();
            Centre = centre;
            NeedsReconcile = true;
            Epoch++;
        }
    }
}
