using ClientLib.World;
using Minecraft.Data.Particles;

namespace ClientLib.Particles;

public sealed partial class ParticleEngine {
    /// <summary>
    /// What a tick reads and writes besides the particles: its random, the chunk it last looked in, and where the
    /// particles it spawns go. The thread that makes particles and the worker each have their own, so a provider's
    /// constructor tick on one never disturbs a tick running on the other.
    /// </summary>
    private sealed class TickContext(ParticleRandom random, bool worker) {
        public readonly ParticleRandom Random = random;
        public readonly bool Worker = worker;
        public long ChunkKey = long.MinValue;
        public ClientChunk? Chunk;
    }

    /// <summary>A particle a tick on the worker spawned, made on the main thread once the tick is done.</summary>
    private struct DeferredSpawn {
        public IParticle? Options;
        public double X, Y, Z, Xd, Yd, Zd;
        public bool AlwaysVisible;

        /// <summary>A firework spark's trail, which copies these from the spark rather than having options.</summary>
        public float R, G, B, F1, F2, F3;
        public ParticleFlags Flags;
    }

    [ThreadStatic] private static TickContext? _workerContext;

    private readonly TickContext _mainContext;
    private readonly TickContext _simContext = new(new ParticleRandom(), true);
    private DeferredSpawn[] _deferred = new DeferredSpawn[16];
    private int _deferredCount;

    /// <summary>The context of the thread running now: the worker's on the worker, the main one anywhere else.</summary>
    private TickContext Context => _workerContext ?? _mainContext;

    /// <summary>
    /// Ticks the particles on a thread of their own, overlapping the frames between ticks, rather than inside
    /// <see cref="Tick"/>. <see cref="AfterTick"/> then runs on that thread too, so the renderer can build its
    /// instances there. A tick's work joins the main thread at the next <see cref="Publish"/>: the particles its
    /// particles spawned are made then, and join a tick later than they would ticked in place.
    /// <p/>
    /// The level is read while the main thread draws, so whatever changes it (packets and ticks) must hold
    /// <see cref="HoldLevel"/>; the worker pauses between small batches while it is held.
    /// </summary>
    public bool Asynchronous { get; set; }

    /// <summary>Runs after every tick with the live particles, on the worker when <see cref="Asynchronous"/>.</summary>
    public TickedHandler? AfterTick { get; set; }

    /// <summary>
    /// Runs on the main thread just before an asynchronous tick starts, with nothing running on the worker, given
    /// the particles about to join: what a renderer must look up on the main thread it looks up here.
    /// </summary>
    public TickedHandler? BeforeTick { get; set; }

    public delegate void TickedHandler(ReadOnlySpan<ParticleState> particles, int tick);

    /// <summary>Counts <see cref="Tick"/> calls that ran, so a renderer can tell a tick it has not seen the end of yet.</summary>
    public int TickCount { get; private set; }

    /// <summary>The elder guardians alive at the last published tick, which are drawn as models rather than quads.</summary>
    public IReadOnlyList<ParticleState> ElderGuardians => _publishedGuardians;

    private List<ParticleState> _publishedGuardians = [], _workerGuardians = [];

    private readonly object _jobLock = new();
    private Thread? _thread;
    private bool _jobQueued;
    private volatile bool _jobRunning;
    private bool _published = true;
    private Exception? _jobError;

    /// <summary>The particles waiting for the running tick, swapped with <see cref="_pending"/> as it starts.</summary>
    private ParticleState[] _jobPending = new ParticleState[64];
    private int _jobPendingCount;

    private int _levelBusy, _inBatch, _holdDepth;
    private const int BatchSize = 128;

    /// <summary>
    /// Keeps the worker out of the level until disposed: the worker finishes the batch it is in, at most a few
    /// microseconds, and waits. Nests; only the main thread holds it.
    /// </summary>
    public LevelHold HoldLevel() {
        if (_holdDepth++ == 0) {
            Acquire();
        }
        return new LevelHold(this);
    }

    public readonly struct LevelHold(ParticleEngine engine) : IDisposable {
        public void Dispose() {
            if (--engine._holdDepth == 0) {
                Volatile.Write(ref engine._levelBusy, 0);
            }
        }
    }

    private void Acquire() {
        Interlocked.Exchange(ref _levelBusy, 1);
        SpinWait spin = new();
        while (Volatile.Read(ref _inBatch) != 0) {
            spin.SpinOnce(-1);
        }
    }

    private void EnterBatch() {
        SpinWait spin = new();
        while (true) {
            Interlocked.Exchange(ref _inBatch, 1);
            if (Volatile.Read(ref _levelBusy) == 0) {
                return;
            }
            Volatile.Write(ref _inBatch, 0);
            while (Volatile.Read(ref _levelBusy) != 0) {
                spin.SpinOnce();
            }
        }
    }

    private void ExitBatch() => Volatile.Write(ref _inBatch, 0);

    /// <summary>Starts a tick on the worker with what was made since the last one. Nothing may be running.</summary>
    private void StartTick() {
        BeforeTick?.Invoke(_pending.AsSpan(0, _pendingCount), TickCount);
        (_pending, _jobPending) = (_jobPending, _pending);
        (_pendingCount, _jobPendingCount) = (0, _pendingCount);
        _published = false;
        _jobRunning = true;
        lock (_jobLock) {
            _jobQueued = true;
            if (_thread == null) {
                _thread = new Thread(WorkerLoop) { IsBackground = true, Name = "Particles" };
                _thread.Start();
            }
            else {
                Monitor.PulseAll(_jobLock);
            }
        }
    }

    /// <summary>The worker, which ends itself after a few idle seconds so a client that stops ticking keeps no thread.</summary>
    private void WorkerLoop() {
        _workerContext = _simContext;
        while (true) {
            lock (_jobLock) {
                while (!_jobQueued) {
                    if (!Monitor.Wait(_jobLock, 5000) && !_jobQueued) {
                        _thread = null;
                        return;
                    }
                }
                _jobQueued = false;
            }
            try {
                Simulate(true);
                AfterTick?.Invoke(_particles.AsSpan(0, _count), TickCount);
            }
            catch (Exception e) {
                _jobError = e;
            }
            finally {
                ExitBatch();
                lock (_jobLock) {
                    _jobRunning = false;
                    Monitor.PulseAll(_jobLock);
                }
            }
        }
    }

    /// <summary>Waits out a running tick, letting go of the level meanwhile so the worker can finish.</summary>
    private void WaitForTick() {
        if (!_jobRunning) {
            return;
        }
        bool held = _holdDepth > 0;
        if (held) {
            Volatile.Write(ref _levelBusy, 0);
        }
        lock (_jobLock) {
            while (_jobRunning) {
                Monitor.Wait(_jobLock);
            }
        }
        if (held) {
            Acquire();
        }
    }

    /// <summary>
    /// Takes up a finished asynchronous tick on the main thread: the particles it spawned are made, and its elder
    /// guardians become <see cref="ElderGuardians"/>. Cheap when there is nothing new; called each frame.
    /// </summary>
    public void Publish() {
        if (_published || _jobRunning) {
            return;
        }
        _published = true;
        if (_jobError is { } error) {
            _jobError = null;
            throw new InvalidOperationException("The particle tick failed", error);
        }
        (_publishedGuardians, _workerGuardians) = (_workerGuardians, _publishedGuardians);
        int count = _deferredCount;
        _deferredCount = 0;
        for (int i = 0; i < count; i++) {
            ref DeferredSpawn spawn = ref _deferred[i];
            if (spawn.Options == null) {
                SpawnTrail(spawn.X, spawn.Y, spawn.Z, spawn.R, spawn.G, spawn.B, spawn.Flags, spawn.F1, spawn.F2, spawn.F3);
            }
            else if (spawn.AlwaysVisible) {
                AddAlwaysVisibleParticle(spawn.Options, spawn.X, spawn.Y, spawn.Z, spawn.Xd, spawn.Yd, spawn.Zd);
            }
            else {
                AddParticle(spawn.Options, spawn.X, spawn.Y, spawn.Z, spawn.Xd, spawn.Yd, spawn.Zd);
            }
            spawn.Options = null;
        }
        ForgetEmittedIfUnused();
        Version++;
    }

    /// <summary>A tick spawning a particle: made now on the main thread, or once the tick is published on the worker.</summary>
    private void Spawn(IParticle options, double x, double y, double z, double xd, double yd, double zd, bool alwaysVisible = false) {
        if (!Context.Worker) {
            if (alwaysVisible) {
                AddAlwaysVisibleParticle(options, x, y, z, xd, yd, zd);
            }
            else {
                AddParticle(options, x, y, z, xd, yd, zd);
            }
            return;
        }
        ref DeferredSpawn spawn = ref Defer();
        spawn.Options = options;
        (spawn.X, spawn.Y, spawn.Z, spawn.Xd, spawn.Yd, spawn.Zd) = (x, y, z, xd, yd, zd);
        spawn.AlwaysVisible = alwaysVisible;
    }

    /// <summary>A firework spark leaving a half aged copy of itself behind.</summary>
    private void SpawnTrail(in ParticleState spark) {
        if (!Context.Worker) {
            SpawnTrail(spark.X, spark.Y, spark.Z, spark.R, spark.G, spark.B, spark.Flags, spark.F1, spark.F2, spark.F3);
            return;
        }
        ref DeferredSpawn spawn = ref Defer();
        spawn.Options = null;
        (spawn.X, spawn.Y, spawn.Z) = (spark.X, spark.Y, spark.Z);
        (spawn.R, spawn.G, spawn.B, spawn.F1, spawn.F2, spawn.F3) = (spark.R, spark.G, spark.B, spark.F1, spark.F2, spark.F3);
        spawn.Flags = spark.Flags;
    }

    private void SpawnTrail(double x, double y, double z, float r, float g, float b, ParticleFlags flags, float f1, float f2, float f3) {
        int handle = SpawnSpark(x, y, z, 0.0, 0.0, 0.0);
        if (handle < 0) {
            return;
        }
        ref ParticleState trail = ref _pending[handle];
        trail.A = 0.99F;
        trail.SetColour(r, g, b);
        trail.Age = trail.Lifetime / 2;
        trail.Flags |= flags & (ParticleFlags.Fade | ParticleFlags.Twinkle);
        (trail.F1, trail.F2, trail.F3) = (f1, f2, f3);
    }

    private ref DeferredSpawn Defer() {
        if (_deferredCount == _deferred.Length) {
            Array.Resize(ref _deferred, _deferred.Length * 2);
        }
        return ref _deferred[_deferredCount++];
    }

    /// <summary>
    /// <c>ParticleEngine.tick</c>'s body: every particle ticks and the dead ones go, then the waiting particles join
    /// their groups. On the worker the level is only read inside batches, which <see cref="HoldLevel"/> waits out.
    /// </summary>
    private void Simulate(bool worker) {
        TickContext context = Context;
        context.ChunkKey = long.MinValue;
        int write = 0;
        int count = _count;
        for (int start = 0; start < count; start += BatchSize) {
            int end = Math.Min(count, start + BatchSize);
            if (worker) {
                EnterBatch();
            }
            for (int i = start; i < end; i++) {
                ref ParticleState p = ref _particles[i];
                TickParticle(ref p, i);
                if (p.Removed) {
                    Forget(ref p);
                    continue;
                }
                if (p.Visible) {
                    SampleLight(context, ref p);
                }
                if (write != i) {
                    _particles[write] = p;
                }
                write++;
            }
            if (worker) {
                ExitBatch();
                // A chunk may be unloaded between batches.
                context.ChunkKey = long.MinValue;
            }
        }
        _count = write;

        if (worker) {
            EnterBatch();
        }
        // Read only now: on the main thread the ticks above may have added to the queue, and those join too.
        ParticleState[] pending = worker ? _jobPending : _pending;
        int pendingCount = worker ? _jobPendingCount : _pendingCount;
        for (int i = 0; i < pendingCount; i++) {
            ref ParticleState p = ref pending[i];
            if (p.Removed || !JoinGroup(ref p)) {
                if (p.Has(ParticleFlags.SporeLimited)) {
                    Interlocked.Decrement(ref _sporeBlossoms);
                }
                continue;
            }
            if (p.Visible) {
                SampleLight(context, ref p);
            }
            if (_count == _particles.Length) {
                Array.Resize(ref _particles, _particles.Length * 2);
            }
            _particles[_count++] = p;
        }
        if (worker) {
            _jobPendingCount = 0;
            ExitBatch();
        }
        else {
            _pendingCount = 0;
        }
        _workerGuardians.Clear();
        if (_elderGuardians > 0) {
            foreach (ref readonly ParticleState p in _particles.AsSpan(0, _count)) {
                if (p.IsElderGuardian) {
                    _workerGuardians.Add(p);
                }
            }
        }
    }
}
