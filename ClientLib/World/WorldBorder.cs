using ClientLib.Maths;
using Minecraft.Physics;
using Mth = Minecraft.Schemas.Mth;

namespace ClientLib.World;

/// <summary>
/// <c>WorldBorder</c> as a client level keeps it: the square the server's border packets describe,
/// growing or shrinking one tick at a time as <c>MovingBorderExtent</c> does.
/// </summary>
public sealed class WorldBorder {
    public const double MaxSize = 5.999997E7F;

    public double CenterX { get; private set; }
    public double CenterZ { get; private set; }
    public int AbsoluteMaxSize { get; private set; } = 29999984;
    public int WarningBlocks { get; set; } = 5;
    public int WarningTime { get; set; } = 15;

    private double _from, _to;
    private double _lerpDuration;
    private long _lerpProgress;
    private double _size = MaxSize, _previousSize = MaxSize;
    private bool _moving;
    private double _minX, _minZ, _maxX, _maxZ;
    private Box[] _collision = [];

    public WorldBorder() => UpdateBox();

    public double Size => _size;

    /// <summary><c>getLerpSpeed</c>: the blocks a moving border covers a tick, zero when it stands still.</summary>
    public double LerpSpeed => _moving ? Math.Abs(_from - _to) / (long)_lerpDuration : 0.0;

    /// <summary><c>getLerpTarget</c>: the size a moving border is headed for, or the size it has.</summary>
    public double LerpTarget => _moving ? _to : _size;

    public double MinX => _minX;
    public double MinZ => _minZ;
    public double MaxX => _maxX;
    public double MaxZ => _maxZ;

    private double Edge(double center, double size) => Math.Clamp(center + size / 2.0, -AbsoluteMaxSize, AbsoluteMaxSize);

    public void SetCenter(double x, double z) {
        CenterX = x;
        CenterZ = z;
        UpdateBox();
    }

    /// <summary><c>setSize</c>: a <c>StaticBorderExtent</c>.</summary>
    public void SetSize(double size) {
        _moving = false;
        _size = size;
        _previousSize = size;
        UpdateBox();
    }

    /// <summary><c>lerpSizeBetween</c>; the game time it also takes only feeds <c>getLerpSpeed</c>.</summary>
    public void LerpSizeBetween(double from, double to, long ticks) {
        if (from == to) {
            SetSize(to);
            return;
        }
        _moving = true;
        _from = from;
        _to = to;
        _lerpDuration = ticks;
        _lerpProgress = ticks;
        _size = CalculateSize();
        _previousSize = _size;
        UpdateBox();
    }

    public void SetAbsoluteMaxSize(int absoluteMaxSize) {
        AbsoluteMaxSize = absoluteMaxSize;
        UpdateBox();
    }

    /// <summary><c>WorldBorder.tick</c>: <c>MovingBorderExtent.update</c>.</summary>
    public void Tick() {
        if (!_moving) {
            return;
        }
        _lerpProgress--;
        _previousSize = _size;
        _size = CalculateSize();
        if (_lerpProgress <= 0L) {
            SetSize(_to);
            return;
        }
        UpdateBox();
    }

    private double CalculateSize() {
        double progress = (_lerpDuration - _lerpProgress) / _lerpDuration;
        return progress < 1.0 ? Mth.Lerp(progress, _from, _to) : _to;
    }

    /// <summary>
    /// The bounds and <c>getCollisionShape</c>: everything outside the bounds rounded out to whole blocks,
    /// as four slabs that together cover the eight cells of vanilla's voxel grid. A moving border's bounds
    /// are <c>getMinX(0.0F)</c>, which lerps from the previous tick's size, so they trail its size by a tick.
    /// </summary>
    private void UpdateBox() {
        _minX = Edge(CenterX, -_previousSize);
        _minZ = Edge(CenterZ, -_previousSize);
        _maxX = Edge(CenterX, _previousSize);
        _maxZ = Edge(CenterZ, _previousSize);
        double minX = Math.Floor(_minX), minZ = Math.Floor(_minZ), maxX = Math.Ceiling(_maxX), maxZ = Math.Ceiling(_maxZ);
        const double inf = double.PositiveInfinity;
        _collision = [
            new Box(-inf, -inf, -inf, minX, inf, inf),
            new Box(maxX, -inf, -inf, inf, inf, inf),
            new Box(-inf, -inf, -inf, inf, inf, minZ),
            new Box(-inf, -inf, maxZ, inf, inf, inf)
        ];
    }

    /// <summary><c>getCollisionShape</c>.</summary>
    public Box[] CollisionShape => _collision;

    /// <summary><c>isWithinBounds(x, z, margin)</c>.</summary>
    public bool IsWithinBounds(double x, double z, double margin = 0.0) =>
        x >= _minX - margin && x < _maxX + margin && z >= _minZ - margin && z < _maxZ + margin;

    /// <summary><c>isWithinBounds(BlockPos)</c>.</summary>
    public bool IsWithinBounds(int x, int z) => IsWithinBounds((double)x, z);

    /// <summary><c>getDistanceToBorder</c>.</summary>
    public double DistanceToBorder(double x, double z) {
        double fromNorth = z - _minZ;
        double fromSouth = _maxZ - z;
        double fromWest = x - _minX;
        double fromEast = _maxX - x;
        double min = Math.Min(fromWest, fromEast);
        min = Math.Min(min, fromNorth);
        return Math.Min(min, fromSouth);
    }

    /// <summary><c>isInsideCloseToBorder</c>: whether an entity at the position collides with the border at all.</summary>
    public bool IsInsideCloseToBorder(Vec3d position, Box boundingBox) {
        double bbMax = Math.Max(Math.Max(Math.Abs(boundingBox.MaxX - boundingBox.MinX), Math.Abs(boundingBox.MaxZ - boundingBox.MinZ)), 1.0);
        return DistanceToBorder(position.X, position.Z) < bbMax * 2.0 && IsWithinBounds(position.X, position.Z, bbMax);
    }
}
