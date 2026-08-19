using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Server.Terrain.Generation;

/// <summary>One section's worth of terrain written into a chunk that was not the one being generated.</summary>
internal readonly record struct ForkedSection(int SectionIndex, GenerationSection Overlay);

/// <summary>
/// Terrain written into a chunk that was not the one being generated: applied straight away if that
/// chunk is loaded, and parked until it is generated if not.
/// </summary>
/// <remarks>
/// <b>The lock is the point of this class.</b> Asking whether the target is loaded and then parking
/// the change loses it whenever the target publishes between the two: the take for that chunk has
/// already run, nothing looks at the parked list again, and the terrain is gone for the world's
/// lifetime with nothing thrown.
/// <p/>
/// One lock covering both "test loaded, else park" and "take the parked list" closes it, given
/// <see cref="ITerrainHost.ChunkAvailable"/>'s guarantee that a chunk is reachable before it is
/// announced. Either the poster sees the chunk and applies, or it parks and nothing has taken the
/// list yet. There is no third outcome.
/// <p/>
/// <b>Lock order.</b> Posting takes this lock and then, inside <c>TryApplyToLoadedChunk</c>, a chunk's
/// own write lock. Draining takes this lock, <em>releases it</em>, and then takes the chunk's. So this
/// one sits above a chunk write lock and a chunk write lock never reaches back for it, which is the
/// invariant the chunk store documents.
/// <p/>
/// A plain <c>lock (object)</c> rather than <c>System.Threading.Lock</c>, which this project's net8.0
/// target does not have.
/// </remarks>
internal sealed class ForkQueue {
    private readonly object _gate = new();
    private readonly Dictionary<Vec2<int>, List<ForkedSection>> _parked = [];

    /// <summary>How many chunks are holding parked terrain. Zero once a world has settled.</summary>
    public int PendingChunks {
        get {
            lock (_gate) {
                return _parked.Count;
            }
        }
    }

    public void Post(Vec2<int> target, ForkedSection fork, long stateCount, ITerrainHost host) {
        bool applied;
        lock (_gate) {
            applied = Apply(host, target, fork, stateCount);

            if (!applied) {
                if (!_parked.TryGetValue(target, out List<ForkedSection>? pending)) {
                    _parked[target] = pending = [];
                }

                pending.Add(fork);
            }
        }

        // Outside the gate. Announcing a change walks every player in the world and takes each of
        // their queues, and every chunk generating anywhere in the world posts through this gate, so
        // holding it across that serialises generation behind the send path.
        if (applied) {
            host.NotifyChunkChanged(target);
        }
    }

    /// <summary>
    /// Applies whatever was parked for a chunk that has just become available. The list is taken
    /// under the lock and applied outside it, so a chunk's write lock is never taken while holding
    /// this one.
    /// </summary>
    public void Drain(Vec2<int> chunk, long stateCount, ITerrainHost host) {
        List<ForkedSection>? pending = Take(chunk);
        if (pending == null) {
            return;
        }

        // One announcement for the whole parked list, not one per change: they all land in the same
        // chunk, and it is the chunk that gets sent again.
        bool applied = false;
        foreach (ForkedSection fork in pending) {
            applied |= Apply(host, chunk, fork, stateCount);
        }

        if (applied) {
            host.NotifyChunkChanged(chunk);
        }
    }

    /// <summary>
    /// Hands over whatever was parked for a chunk that is about to be generated, so it can be written
    /// into the terrain the generator is about to decorate.
    /// </summary>
    /// <remarks>
    /// Taken rather than copied: a fork is applied exactly once, and the caller owns the list from
    /// here. This is what stops a fork that arrived first from being applied a second time once the
    /// chunk loads.
    /// </remarks>
    public List<ForkedSection>? Take(Vec2<int> chunk) {
        lock (_gate) {
            return _parked.Remove(chunk, out List<ForkedSection>? pending) ? pending : null;
        }
    }

    private static bool Apply(ITerrainHost host, Vec2<int> chunk, ForkedSection fork, long stateCount) {
        return host.TryApplyToLoadedChunk(chunk, data => {
            if (fork.SectionIndex < 0 || fork.SectionIndex >= data.Sections.Length) {
                return;
            }

            fork.Overlay.MergeInto(data.Sections[fork.SectionIndex], stateCount);
            data.InvalidateHeightmaps();
        });
    }
}
