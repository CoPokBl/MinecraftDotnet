using ManagedServer.Worlds;

namespace ManagedServer.Testing.Worlds;

/// <summary>
/// The queue that keeps chunk generation from occupying the whole thread pool.
/// </summary>
/// <remarks>
/// The limit is the property that matters and it is invisible when it breaks: work still completes
/// and the server still answers, just seconds later, so nothing here can be left to a benchmark to
/// notice.
/// </remarks>
public class ChunkGenerationQueueTest {

    [Test]
    public void NeverRunsMoreThanTheLimitAtOnce() {
        ChunkGenerationQueue queue = new(_ => { }, 3);

        int running = 0;
        int peak = 0;
        CountdownEvent done = new(64);

        for (int i = 0; i < 64; i++) {
            queue.Post(() => {
                int now = Interlocked.Increment(ref running);
                InterlockedMax(ref peak, now);
                Thread.Sleep(5);
                Interlocked.Decrement(ref running);
                done.Signal();
            });
        }

        Assert.That(done.Wait(TimeSpan.FromSeconds(30)), "the queue stalled");
        Assert.That(peak, Is.LessThanOrEqualTo(3));
        Assert.That(peak, Is.GreaterThan(1), "nothing ran in parallel, so the limit measured nothing");
    }

    /// <summary>
    /// A world hands its viewport over sorted by distance, so the order work comes back out in is
    /// the order chunks reach the player.
    /// </summary>
    [Test]
    public void StartsWorkInTheOrderItWasPosted() {
        ChunkGenerationQueue queue = new(_ => { }, 1);

        List<int> started = [];
        CountdownEvent done = new(32);

        for (int i = 0; i < 32; i++) {
            int index = i;
            queue.Post(() => {
                lock (started) started.Add(index);
                done.Signal();
            });
        }

        Assert.That(done.Wait(TimeSpan.FromSeconds(30)), "the queue stalled");
        Assert.That(started, Is.EqualTo(Enumerable.Range(0, 32).ToList()));
    }

    /// <summary>
    /// An exception escaping a thread pool work item takes the process with it, so a terrain provider
    /// that throws has to be caught here whatever the caller does about it.
    /// </summary>
    [Test]
    public void AFailureIsReportedAndTheQueueCarriesOn() {
        List<Exception> errors = [];
        ChunkGenerationQueue queue = new(e => { lock (errors) errors.Add(e); }, 2);

        CountdownEvent done = new(8);

        for (int i = 0; i < 8; i++) {
            int index = i;
            queue.Post(() => {
                done.Signal();
                if (index % 2 == 0) throw new InvalidOperationException("provider failed");
            });
        }

        Assert.That(done.Wait(TimeSpan.FromSeconds(30)), "a failure stopped the queue");
        Assert.That(errors, Has.Count.EqualTo(4));
    }

    /// <summary>Raising the limit applies to work already waiting, not only to the next post.</summary>
    [Test]
    public void RaisingTheLimitStartsWaitingWork() {
        ChunkGenerationQueue queue = new(_ => { }, 1);

        ManualResetEventSlim block = new();
        CountdownEvent secondReached = new(1);

        // Holds the single slot until it is released.
        queue.Post(() => block.Wait(TimeSpan.FromSeconds(30)));
        queue.Post(() => secondReached.Signal());

        Assert.That(secondReached.Wait(TimeSpan.FromMilliseconds(200)), Is.False,
            "the second item ran while the only slot was held");

        queue.MaxConcurrency = 2;

        Assert.That(secondReached.Wait(TimeSpan.FromSeconds(30)), "raising the limit started nothing");
        block.Set();
    }

    [Test]
    public void ALimitBelowOneIsRejected() {
        ChunkGenerationQueue queue = new(_ => { }, 1);
        Assert.Throws<ArgumentOutOfRangeException>(() => queue.MaxConcurrency = 0);
    }

    private static void InterlockedMax(ref int target, int value) {
        int seen = Volatile.Read(ref target);
        while (value > seen) {
            int was = Interlocked.CompareExchange(ref target, value, seen);
            if (was == seen) return;
            seen = was;
        }
    }
}
