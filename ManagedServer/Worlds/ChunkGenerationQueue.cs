using System.Collections.Concurrent;

namespace ManagedServer.Worlds;

/// <summary>
/// The budget chunk generation is allowed to spend on the thread pool, shared by every world on a
/// server.
/// </summary>
/// <remarks>
/// <b>The queue is the point, not the limit.</b> The thread pool's own queue is global and first in
/// first out, and a chunk read is <c>await</c>ed, so a player's chat message resumes as a work item
/// behind whatever is already queued. A viewport is thousands of chunks asked for in one tick, so
/// posting them straight to the pool puts every packet, every send and every scheduled task behind
/// tens of seconds of terrain, and the server stops answering while the queue drains. Holding the
/// backlog here instead means the pool only ever carries <see cref="MaxConcurrency"/> chunks at a
/// time and anything else posted to it runs at once.
/// <p/>
/// One chunk per work item rather than a worker that loops, so the limit is honest at every instant,
/// a change to it applies to work already queued, and the pool is free to interleave between chunks
/// rather than seeing a long running item and injecting threads to compensate.
/// <p/>
/// Order is preserved, which matters: a world hands its viewport over sorted by distance, so the
/// chunk the player is standing on is generated first.
/// <p/>
/// This is a bound on <em>concurrency</em>, not a promise about latency. A join still costs what the
/// terrain costs; what it buys is that the cost lands on chunks arriving slightly later rather than
/// on the whole server going quiet.
/// </remarks>
public sealed class ChunkGenerationQueue {
    private readonly ConcurrentQueue<Action> _queue = new();
    private readonly Action<Exception> _onError;

    private int _running;
    private int _maxConcurrency;

    /// <param name="onError">
    /// Where a failure in posted work goes. An exception escaping a pool work item takes the process
    /// with it, so this is the only thing standing between a broken terrain provider and a crash.
    /// </param>
    /// <param name="maxConcurrency">
    /// How many chunks may generate at once. Defaults to leaving two cores for everything that is
    /// not terrain: the tick thread runs on its own thread, but sends, packet handling and scheduled
    /// tasks are all pool work.
    /// </param>
    public ChunkGenerationQueue(Action<Exception> onError, int? maxConcurrency = null) {
        _onError = onError;
        MaxConcurrency = maxConcurrency ?? Math.Max(1, Environment.ProcessorCount - 2);
    }

    /// <summary>
    /// How many chunks may be generating at once. Raising it takes effect immediately, including on
    /// work already waiting.
    /// </summary>
    public int MaxConcurrency {
        get => Volatile.Read(ref _maxConcurrency);
        set {
            if (value < 1) {
                throw new ArgumentOutOfRangeException(nameof(value), value,
                    "At least one chunk has to be able to generate.");
            }

            Volatile.Write(ref _maxConcurrency, value);
            TryStart();
        }
    }

    /// <summary>Chunks asked for and not started yet. The number that a join makes large.</summary>
    public int Pending => _queue.Count;

    /// <summary>Chunks generating right now, never more than <see cref="MaxConcurrency"/>.</summary>
    public int Running => Volatile.Read(ref _running);

    public void Post(Action work) {
        _queue.Enqueue(work);
        TryStart();
    }

    /// <summary>
    /// Claims a slot and puts one item on the pool for it.
    /// </summary>
    /// <remarks>
    /// The claim is a compare and exchange rather than a lock because every completing chunk calls
    /// this, and losing the race means another thread has already taken the slot this one was going
    /// to fill. Rechecked after the claim: <see cref="Post"/> enqueues before it starts, so a start
    /// racing an empty queue is possible and the slot has to go back.
    /// </remarks>
    private void TryStart() {
        while (true) {
            int running = Volatile.Read(ref _running);
            if (running >= MaxConcurrency || _queue.IsEmpty) {
                return;
            }

            if (Interlocked.CompareExchange(ref _running, running + 1, running) != running) {
                continue;
            }

            if (!_queue.TryDequeue(out Action? work)) {
                Interlocked.Decrement(ref _running);
                return;
            }

            ThreadPool.UnsafeQueueUserWorkItem(static state => state.Queue.Run(state.Work), (Queue: this, Work: work),
                preferLocal: false);
            return;
        }
    }

    private void Run(Action work) {
        try {
            work();
        } catch (Exception e) {
            _onError(e);
        } finally {
            Interlocked.Decrement(ref _running);
            TryStart();
        }
    }
}
