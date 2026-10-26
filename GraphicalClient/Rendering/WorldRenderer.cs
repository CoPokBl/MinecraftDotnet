using System.Collections.Concurrent;
using System.Diagnostics;
using System.Numerics;
using ClientLib.World;
using GraphicalClient.Assets;
using GraphicalClient.Rendering.Pipeline;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>
/// The level's blocks on the GPU. Sections are snapshotted on the game thread, meshed on worker
/// threads, and uploaded back on the game thread within a time budget, so a burst of chunks costs
/// latency rather than frame time.
/// </summary>
public sealed unsafe class WorldRenderer : IDisposable {
    private const int MaxQuadsPerDraw = 1 << 17;
    private const double SnapshotBudgetMs = 1.0;

    private readonly GL _gl;
    private readonly BlockModels _models;
    private readonly int _waterState;
    private readonly uint _quadIndices;
    private readonly GeometryArena _arena;
    private readonly UploadRing _uploads;
    private readonly SectionCuller _culler;
    private uint _vao;

    private readonly Dictionary<long, SectionRender> _sections = new();
    private readonly DirtySections _dirty = new();
    private readonly Dictionary<long, int> _versions = new();
    private readonly HashSet<long> _inFlight = [];

    /// <summary>Sections whose current contents have been meshed, including the ones that came out empty.</summary>
    private readonly HashSet<long> _built = [];

    /// <summary>Each built section's face to face visibility; a section not yet built lets everything through.</summary>
    private readonly Dictionary<long, ulong> _visibility = new();
    private readonly Dictionary<long, SectionEndPortals> _endPortals = new();
    private readonly List<long> _taken = [];

    // The game thread takes a lock a mesher can hold only once a frame, in WakeWorkers, never per job:
    // with the cores busy, a preempted mesher holding one stalls the frame.
    private readonly ConcurrentQueue<SectionSnapshot> _jobs = new();
    private readonly ConcurrentQueue<SectionMesh> _results = new();
    private readonly ConcurrentQueue<SectionSnapshot> _snapshotPool = new();

    /// <summary>Wakes idle meshers, released once a frame for the whole batch.</summary>
    private readonly SemaphoreSlim _jobSignal = new(0);
    private int _idleWorkers;
    private readonly VertexArrayPool _vertexPool = new();
    private readonly Thread[] _workers;
    private readonly CancellationTokenSource _cts = new();

    private readonly OcclusionWalk _walk = new();
    private readonly Action _runWalk;
    private Task? _walkTask;
    private long _lastWalkTicks;
    private bool _walkUrgent;
    private bool _walkStale = true;
    private (int X, int Y, int Z) _walkFrom = (int.MinValue, 0, 0);
    private bool _walkSmartCull = true;

    /// <summary>The last walk's slots for the culler, and how many slots had been freed when it started.</summary>
    private int[] _listSlots = new int[8192];
    private int _listCount;
    private bool _listChanged;
    private int _freedAtWalk;

    private ClientLevel? _level;
    private BiomeColours.Tints[] _tints = [];
    private BlockMaterials _materials = BlockMaterials.None;
    private (int X, int Z) _lodCentre = (int.MinValue, int.MinValue);

    /// <summary>Sections the main camera drew, a frame or two ago.</summary>
    public int VisibleSections => _culler.VisibleSections;

    /// <summary>Accumulated milliseconds spent walking the visibility graph. For profiling.</summary>
    public readonly double[] Timings = new double[1];

    /// <summary>Quads drawn for the main camera and the shadow camera, a frame or two ago.</summary>
    public (long Main, long Shadow) QuadsDrawn => (_culler.MainQuads, _culler.ShadowQuads);

    public string LayerQuadsReport => $"solid {_culler.LayerQuads(0)} cutout {_culler.LayerQuads(1)} translucent {_culler.LayerQuads(2)}";

    public int LoadedSections => _sections.Count;

    public int PendingSections => _dirty.Count + _inFlight.Count;

    /// <summary>The built sections that hold end portal or end gateway blocks.</summary>
    public IReadOnlyCollection<SectionEndPortals> EndPortals => _endPortals.Values;

    /// <summary>How many sections from the camera the shadow camera reaches, horizontally.</summary>
    public int ShadowReach { get; set; }

    /// <summary>Changes whenever geometry within <see cref="ShadowReach"/> of the camera does.</summary>
    public int ShadowGeometryVersion { get; private set; }

    public int RenderDistance { get; set; } = 12;

    /// <summary>A resource pack's colour maps for grass and foliage, read when a level is set.</summary>
    public BiomeColours.ColourMaps? ColourMaps { get; set; }

    /// <summary>
    /// Chunks from the camera at which sections are drawn at half detail; at twice this, quarter detail.
    /// 0 draws everything at full detail.
    /// </summary>
    public int LodDistance { get; set; } = 12;

    private volatile bool _ambientOcclusion = true;

    /// <summary>The <c>ao</c> option; a change remeshes every section, as <c>LevelExtractor.allChanged</c> does.</summary>
    public bool AmbientOcclusion {
        get => _ambientOcclusion;
        set {
            if (_ambientOcclusion == value) {
                return;
            }
            _ambientOcclusion = value;
            MarkAllDirty();
        }
    }

    /// <summary>The shader pack's material numbers; a change remeshes every section, as they are baked into the vertices.</summary>
    public BlockMaterials Materials {
        get => _materials;
        set {
            if (_materials.SameAs(value)) {
                return;
            }
            _materials = value;
            MarkAllDirty();
        }
    }

    public WorldRenderer(GL gl, BlockModels models, int waterState) {
        _gl = gl;
        _models = models;
        _waterState = waterState;
        _runWalk = _walk.Run;

        uint[] indices = new uint[MaxQuadsPerDraw * 6];
        for (uint q = 0; q < MaxQuadsPerDraw; q++) {
            ReadOnlySpan<uint> corners = [0, 1, 2, 2, 3, 0];
            for (int i = 0; i < 6; i++) {
                indices[q * 6 + i] = q * 4 + corners[i];
            }
        }
        _quadIndices = gl.CreateBuffer();
        fixed (uint* p = indices) {
            gl.NamedBufferStorage(_quadIndices, (nuint)(indices.Length * sizeof(uint)), p, BufferStorageMask.None);
        }
        _uploads = new UploadRing(gl, 32 * 1024 * 1024);
        _arena = new GeometryArena(gl, _uploads, BlockVertex.Size, 4 * 1024 * 1024);
        _culler = new SectionCuller(gl, _uploads, MaxQuadsPerDraw);
        _arena.Grown += () => {
            if (_vao != 0) {
                _gl.VertexArrayVertexBuffer(_vao, 0, _arena.Buffer, 0, BlockVertex.Size);
            }
        };
        _culler.Grown += () => {
            if (_vao != 0) {
                _gl.VertexArrayVertexBuffer(_vao, 1, _culler.OriginBuffer, 0, (uint)sizeof(Vector4));
            }
        };

        _workers = new Thread[Math.Max(1, Environment.ProcessorCount / 2 - 1)];
        for (int i = 0; i < _workers.Length; i++) {
            _workers[i] = new Thread(Work) { Name = $"Mesher {i}", IsBackground = true, Priority = ThreadPriority.BelowNormal };
            _workers[i].Start();
        }
    }

    private void Work() {
        SectionMesher mesher = new(_models.ByState) { WaterState = _waterState, Pool = _vertexPool };
        CancellationToken token = _cts.Token;
        while (!token.IsCancellationRequested) {
            if (_jobs.TryDequeue(out SectionSnapshot? snapshot)) {
                snapshot.Fill();
                mesher.AmbientOcclusion = _ambientOcclusion;
                SectionMesh mesh = mesher.Mesh(snapshot);
                _snapshotPool.Enqueue(snapshot);
                _results.Enqueue(mesh);
                continue;
            }
            // Counted idle before looking again, so a batch queued in between is either seen here or
            // sees this worker idle and wakes it.
            Interlocked.Increment(ref _idleWorkers);
            try {
                if (_jobs.IsEmpty) {
                    _jobSignal.Wait(token);
                }
            }
            catch (OperationCanceledException) {
                return;
            }
            finally {
                Interlocked.Decrement(ref _idleWorkers);
            }
        }
    }

    private void WakeWorkers(int queued) {
        if (queued == 0) {
            return;
        }
        Interlocked.MemoryBarrier();
        int wake = Math.Min(queued, Volatile.Read(ref _idleWorkers)) - _jobSignal.CurrentCount;
        if (wake > 0) {
            _jobSignal.Release(wake);
        }
    }

    public static long Key(int x, int y, int z) => ((long)x & 0x3FFFFF) << 42 | ((long)z & 0x3FFFFF) << 20 | ((long)y & 0xFFFFF);

    internal static (int X, int Y, int Z) Unpack(long key) => ((int)(key >> 42), (int)(key & 0xFFFFF), (int)(key << 22 >> 42));

    public void SetLevel(ClientLevel? level) {
        if (_level != null) {
            _level.ChunkLoaded -= OnChunkLoaded;
            _level.ChunkUnloaded -= OnChunkUnloaded;
            _level.SectionChanged -= MarkDirty;
        }
        foreach (SectionRender section in _sections.Values) {
            Release(section);
        }
        _sections.Clear();
        _endPortals.Clear();
        _culler.Clear();
        // The walk's arrays are reused by the next one, and its result belongs to the old level.
        _walkTask?.Wait();
        _walkTask = null;
        _listCount = 0;
        _listChanged = false;
        _dirty.Clear();
        _inFlight.Clear();
        _built.Clear();
        _visibility.Clear();
        _walkStale = true;
        _results.Clear();

        _level = level;
        if (level == null) {
            return;
        }
        _tints = BiomeColours.Table(level, ColourMaps);
        level.ChunkLoaded += OnChunkLoaded;
        level.ChunkUnloaded += OnChunkUnloaded;
        level.SectionChanged += MarkDirty;
        foreach (ClientChunk chunk in level.Chunks) {
            OnChunkLoaded(chunk);
        }
    }

    private void OnChunkLoaded(ClientChunk chunk) {
        for (int dx = -1; dx <= 1; dx++) {
            for (int dz = -1; dz <= 1; dz++) {
                for (int y = 0; y < _level!.SectionCount; y++) {
                    MarkDirty(chunk.X + dx, y, chunk.Z + dz);
                }
            }
        }
    }

    private void OnChunkUnloaded(int x, int z) {
        for (int y = 0; y < _level!.SectionCount; y++) {
            long key = Key(x, y, z);
            if (_sections.Remove(key, out SectionRender? section)) {
                Release(section);
            }
            _endPortals.Remove(key);
            _dirty.Remove(key);
            _versions.Remove(key);
            _built.Remove(key);
            _visibility.Remove(key);
        }
        _walkStale = true;
    }

    private void MarkDirty(int x, int y, int z) {
        if (_level == null || !_level.HasChunk(x, z)) {
            return;
        }
        long key = Key(x, y, z);
        _built.Remove(key);
        _versions[key] = _versions.GetValueOrDefault(key) + 1;
        // A section on a chunk whose neighbours have not all arrived cannot be meshed yet; the last of
        // them to load marks it dirty again, so it is not queued to be scanned past until then. That
        // includes the diagonal ones, whose corner columns the border reads: meshed without them, a
        // section is meshed again as each arrives, and chunks being generated arrive in no order.
        if (NeighboursLoaded(_level, x, z)) {
            _dirty.Add(key);
        }
    }

    private void MarkAllDirty() {
        foreach (SectionRender section in _sections.Values) {
            MarkDirty(section.X, section.Y, section.Z);
        }
    }

    private static bool NeighboursLoaded(ClientLevel level, int x, int z) {
        for (int dx = -1; dx <= 1; dx++) {
            for (int dz = -1; dz <= 1; dz++) {
                if ((dx != 0 || dz != 0) && !level.HasChunk(x + dx, z + dz)) {
                    return false;
                }
            }
        }
        return true;
    }

    public bool IsSectionReady(int x, int y, int z) => _built.Contains(Key(x, y, z));

    private int LodAt(long distance) => LodDistance <= 0 || distance < LodDistance ? 0 : distance < LodDistance * 2 ? 1 : 2;

    private long LodDistanceOf(int sectionX, int sectionZ) =>
        Math.Max(Math.Abs((long)sectionX - _lodCentre.X), Math.Abs((long)sectionZ - _lodCentre.Z));

    /// <summary>
    /// Remeshes the sections whose level of detail the camera's move has changed. A section must be a
    /// chunk past a boundary before it changes, so walking along one does not remesh a ring each step.
    /// </summary>
    private void RefreshLods(int camX, int camZ) {
        if ((camX, camZ) == _lodCentre) {
            return;
        }
        _lodCentre = (camX, camZ);
        if (LodDistance <= 0) {
            return;
        }
        foreach (SectionRender section in _sections.Values) {
            long distance = LodDistanceOf(section.X, section.Z);
            int wanted = LodAt(distance);
            if (wanted > section.Lod && LodAt(distance - 1) > section.Lod || wanted < section.Lod && LodAt(distance + 1) < section.Lod) {
                MarkDirty(section.X, section.Y, section.Z);
            }
        }
    }

    private static (int X, int Y, int Z) SectionOf(double x, double y, double z, ClientLevel level) =>
        ((int)Math.Floor(x) >> 4, ((int)Math.Floor(y) - level.MinY) >> 4, (int)Math.Floor(z) >> 4);

    /// <summary>Queues the dirty sections nearest the camera for meshing. No GL calls.</summary>
    public void Schedule(Vector3 cameraBlock) {
        ClientLevel? level = _level;
        if (level == null) {
            return;
        }
        (int camX, int camY, int camZ) = SectionOf(cameraBlock.X, cameraBlock.Y, cameraBlock.Z, level);
        RefreshLods(camX, camZ);
        _dirty.Recentre(camX, camY, camZ);
        int capacity = _workers.Length * 8 - _jobs.Count;
        if (_dirty.Count == 0 || capacity <= 0) {
            return;
        }
        _taken.Clear();
        _dirty.TakeNearest(capacity, _inFlight, _taken);
        // A capture takes references rather than copying, so this rarely reaches the budget; past it the
        // rest wait for the next frame.
        long started = Stopwatch.GetTimestamp();
        int queued = 0;
        for (int t = 0; t < _taken.Count; t++) {
            if (Stopwatch.GetElapsedTime(started).TotalMilliseconds > SnapshotBudgetMs) {
                for (; t < _taken.Count; t++) {
                    _dirty.Add(_taken[t]);
                }
                break;
            }
            if (Snapshot(level, _taken[t])) {
                queued++;
            }
        }
        WakeWorkers(queued);
    }

    /// <returns>Whether a job was queued, rather than the section found to have nothing to draw.</returns>
    private bool Snapshot(ClientLevel level, long key) {
        (int x, int y, int z) = Unpack(key);
        // A section of air with only air or nothing around it has no faces to draw.
        if (level.GetChunk(x, z) is not { } chunk || chunk.Sections[y] is { NonAirCount: 0, IsUniform: true }) {
            if (_sections.Remove(key, out SectionRender? empty)) {
                Release(empty);
            }
            _endPortals.Remove(key);
            MarkBuilt(key, VisibilityGraph.AllVisible);
            return false;
        }
        SectionSnapshot snapshot = _snapshotPool.TryDequeue(out SectionSnapshot? pooled) ? pooled : new SectionSnapshot();
        snapshot.Capture(level, x, y, z);
        snapshot.Tints = _tints;
        snapshot.Materials = _materials;
        snapshot.Version = _versions.GetValueOrDefault(key);
        snapshot.BaseY = level.MinY + y * 16;
        snapshot.Lod = LodAt(LodDistanceOf(x, z));
        _inFlight.Add(key);
        _jobs.Enqueue(snapshot);
        return true;
    }

    private void MarkBuilt(long key, ulong visibility) {
        _built.Add(key);
        _visibility[key] = visibility;
        _walkStale = true;
    }

    /// <summary>Uploads finished meshes until the budget runs out.</summary>
    public void UploadFinished(double budgetMs) {
        ClientLevel? level = _level;
        if (level == null) {
            return;
        }
        long started = Stopwatch.GetTimestamp();
        while (Stopwatch.GetElapsedTime(started).TotalMilliseconds < budgetMs && _results.TryDequeue(out SectionMesh? mesh)) {
            long key = Key(mesh.SectionX, mesh.SectionY, mesh.SectionZ);
            _inFlight.Remove(key);
            if (!level.HasChunk(mesh.SectionX, mesh.SectionZ) || mesh.Version != _versions.GetValueOrDefault(key)) {
                _vertexPool.Return(mesh.Vertices);
                continue;
            }
            if (mesh.EndPortals.Length > 0) {
                _endPortals[key] = new SectionEndPortals(mesh.SectionX * 16, level.MinY + mesh.SectionY * 16, mesh.SectionZ * 16, mesh.EndPortals);
            }
            else {
                _endPortals.Remove(key);
            }
            Upload(key, mesh);
            _vertexPool.Return(mesh.Vertices);
            MarkBuilt(key, mesh.Visibility);
        }
        _uploads.EndFrame();
    }

    /// <summary>
    /// A rebuilt section keeps its object, because the last walk holds references to it; a new one
    /// waits for the next walk, which is brought forward when it is near enough to be noticed.
    /// </summary>
    private void Upload(long key, SectionMesh mesh) {
        _sections.TryGetValue(key, out SectionRender? section);
        if (mesh.VertexCount == 0) {
            if (section != null) {
                _sections.Remove(key);
                Release(section);
            }
            return;
        }

        if (section == null) {
            section = new SectionRender { X = mesh.SectionX, Y = mesh.SectionY, Z = mesh.SectionZ, Slot = _culler.Allocate() };
            _sections[key] = section;
            (int cx, int cy, int cz) = _walkFrom;
            if (Math.Max(Math.Abs(section.X - cx), Math.Max(Math.Abs(section.Y - cy), Math.Abs(section.Z - cz))) <= 2) {
                _walkUrgent = true;
            }
        }
        else {
            _arena.Free(section.Offset, section.Vertices);
        }

        section.Vertices = mesh.VertexCount;
        section.Lod = mesh.Lod;
        section.Offset = _arena.Allocate(mesh.VertexCount);
        _arena.Upload<BlockVertex>(section.Offset, mesh.Vertices.AsSpan(0, mesh.VertexCount));
        GeometryChanged(section.X, section.Z);
        _culler.Update(section.Slot, section.X, (_level!.MinY >> 4) + section.Y, section.Z, section.Offset, mesh.BucketQuads);
    }

    private void Release(SectionRender section) {
        GeometryChanged(section.X, section.Z);
        _arena.Free(section.Offset, section.Vertices);
        _culler.Free(section.Slot);
        section.Released = true;
        _walkStale = true;
    }

    private void GeometryChanged(int x, int z) {
        if (Math.Abs((long)x - _walkFrom.X) <= ShadowReach && Math.Abs((long)z - _walkFrom.Z) <= ShadowReach) {
            ShadowGeometryVersion++;
        }
    }

    /// <summary>
    /// Walks the visibility graph on a worker when the camera has changed section or the graph has
    /// changed, and hands the culler the last walk's result once it is done. No GL calls.
    /// </summary>
    /// <param name="smartCull">
    /// <c>CameraRenderState.smartCull</c>: whether sections are culled by what can be seen through them, which a
    /// spectator inside a block that fills its cube turns off, so everything in range is drawn.
    /// </param>
    public void Walk(Camera camera, bool smartCull = true) {
        ClientLevel? level = _level;
        if (level == null) {
            return;
        }
        if (_walkTask is { IsCompleted: true }) {
            _walkTask = null;
            PublishReachable();
        }
        (int X, int Y, int Z) from = SectionOf(camera.Position.X, camera.Position.Y, camera.Position.Z, level);
        // While sections stream in the graph changes constantly; ten walks a second is plenty to keep up.
        bool due = _walkUrgent || _walkStale && Stopwatch.GetElapsedTime(_lastWalkTicks).TotalMilliseconds >= 100;
        if (_walkFrom == from && _walkSmartCull == smartCull && !due || _walkTask != null) {
            return;
        }
        long t0 = Stopwatch.GetTimestamp();
        _lastWalkTicks = t0;
        _walkFrom = from;
        _walkSmartCull = smartCull;
        _walkStale = _walkUrgent = false;
        _walk.Prepare(level, _sections.Values, _visibility, from.X, from.Y, from.Z, RenderDistance + 1, smartCull);
        _walkTask = Task.Run(_runWalk);
        Timings[0] += Stopwatch.GetElapsedTime(t0).TotalMilliseconds;
    }

    private void PublishReachable() {
        List<SectionRender> reachable = _walk.Reachable;
        if (_listSlots.Length < reachable.Count) {
            _listSlots = new int[Math.Max(reachable.Count, _listSlots.Length * 2)];
        }
        _listCount = 0;
        foreach (SectionRender section in reachable) {
            if (!section.Released) {
                _listSlots[_listCount++] = section.Slot;
            }
        }
        _listChanged = true;
        _freedAtWalk = _culler.FreedSinceList;
    }

    /// <summary>Hands the culler any new walk and has it cull for the main camera.</summary>
    public void Cull(Camera camera) {
        _culler.BeginFrame();
        if (_level == null) {
            return;
        }
        if (_listChanged) {
            _culler.SetList(_listSlots.AsSpan(0, _listCount), _freedAtWalk);
            _listChanged = false;
        }
        _culler.CullMain(camera.Position.X, camera.Position.Y, camera.Position.Z,
            Frustum.FromMatrix(camera.View * camera.CullProjection), (RenderDistance + 1) * 16.0F);
    }

    /// <summary>
    /// Has the culler cull for the shadow camera: every section inside its box, solid and cutout,
    /// every facing, since back faces cast shadows too and caves can be lit through openings.
    /// </summary>
    public void PrepareShadow(Camera camera, float radius, Matrix4x4 shadowViewProjection) {
        if (_level != null) {
            _culler.CullShadow(camera.Position.X, camera.Position.Y, camera.Position.Z, Frustum.FromMatrix(shadowViewProjection), radius);
        }
    }

    /// <summary>Makes this frame's culling visible to the draws, after <see cref="Cull"/> and any <see cref="PrepareShadow"/>.</summary>
    public void Commit() => _culler.Finish();

    /// <summary>One indirect draw for every visible section's quads in a layer, with whatever program is bound.</summary>
    public void DrawLayer(RenderLayer layer, bool shadow = false) {
        int set = shadow ? 3 + (int)layer : (int)layer;
        if (set >= SectionCuller.Sets) {
            return;
        }
        if (_vao == 0) {
            _vao = CreateVertexArray();
        }
        _gl.BindVertexArray(_vao);
        _culler.Draw(set);
        _gl.BindVertexArray(0);
    }

    /// <summary>
    /// Binding 0 is the arena's <see cref="BlockVertex"/>es; binding 1 is each section's camera relative origin, per draw.
    /// Made at the first draw: a vertex array belongs to the context that made it, and the renderer may be built on another.
    /// </summary>
    private uint CreateVertexArray() {
        uint vao = _gl.CreateVertexArray();
        _gl.VertexArrayElementBuffer(vao, _quadIndices);
        _gl.VertexArrayVertexBuffer(vao, 0, _arena.Buffer, 0, BlockVertex.Size);
        _gl.VertexArrayVertexBuffer(vao, 1, _culler.OriginBuffer, 0, (uint)sizeof(Vector4));
        _gl.VertexArrayBindingDivisor(vao, 1, 1);

        Attribute(0, 3, VertexAttribType.UnsignedShort, false, 0, false);
        Attribute(1, 2, VertexAttribType.UnsignedByte, false, 6, true);
        Attribute(2, 2, VertexAttribType.UnsignedShort, false, 8, false);
        Attribute(3, 1, VertexAttribType.UnsignedShort, false, 12, false);
        Attribute(4, 2, VertexAttribType.UnsignedByte, false, 14, false);
        Attribute(5, 4, VertexAttribType.UnsignedByte, true, 16, false);
        _gl.EnableVertexArrayAttrib(vao, 6);
        _gl.VertexArrayAttribFormat(vao, 6, 3, VertexAttribType.Float, false, 0);
        _gl.VertexArrayAttribBinding(vao, 6, 1);
        return vao;

        void Attribute(uint index, int size, VertexAttribType type, bool normalised, uint offset, bool integer) {
            _gl.EnableVertexArrayAttrib(vao, index);
            if (integer) {
                _gl.VertexArrayAttribIFormat(vao, index, size, (VertexAttribIType)type, offset);
            }
            else {
                _gl.VertexArrayAttribFormat(vao, index, size, type, normalised, offset);
            }
            _gl.VertexArrayAttribBinding(vao, index, 0);
        }
    }

    public void Dispose() {
        _cts.Cancel();
        _arena.Dispose();
        _uploads.Dispose();
        _gl.DeleteVertexArray(_vao);
        _gl.DeleteBuffer(_quadIndices);
        _culler.Dispose();
    }
}

internal sealed class SectionRender {
    public int X, Y, Z;
    public int Offset;
    public int Vertices;
    public int Slot;
    public int Lod;

    /// <summary>Set once the section is dropped, for references the last walk still holds.</summary>
    public bool Released;
}
