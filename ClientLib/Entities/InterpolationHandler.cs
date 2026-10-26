using ClientLib.Maths;
using ClientLib.Physics;
using Minecraft.Physics;

namespace ClientLib.Entities;

/// <summary>
/// <c>InterpolationHandler</c>: how an entity moves toward the positions the server sends it. Which one
/// an entity has is its class's <c>createInterpolationHandler</c>, chosen in <see cref="InterpolationHandlers.For"/>.
/// </summary>
public interface IInterpolationHandler {
    /// <summary>Where the interpolation in progress ends, or null when none is.</summary>
    PositionAndRotation? Target { get; }

    /// <summary>False when the handler does nothing, and the caller moves the entity itself.</summary>
    bool InterpolateTo(PositionPath? position, float yRot, float xRot, bool hasRotation);

    void Interpolate();

    /// <summary>A move the client simulated, which the target follows so the move is not undone.</summary>
    void ApplyPredictedMovement(Vec3d delta);

    bool HasActiveInterpolation { get; }

    void Cancel();
}

/// <summary><c>InterpolationHandler.NO_OP</c>: a position from the server lands at once.</summary>
public sealed class NoOpInterpolationHandler : IInterpolationHandler {
    public static readonly NoOpInterpolationHandler Instance = new();

    private NoOpInterpolationHandler() {
    }

    public PositionAndRotation? Target => null;
    public bool InterpolateTo(PositionPath? position, float yRot, float xRot, bool hasRotation) => false;

    public void Interpolate() {
    }

    public void ApplyPredictedMovement(Vec3d delta) {
    }

    public bool HasActiveInterpolation => false;

    public void Cancel() {
    }
}

/// <summary><c>PositionAndRotation.Immutable</c>.</summary>
public readonly record struct PositionAndRotation(Vec3d Position, float YRot, float XRot);

/// <summary><c>PositionAndRotation.Mutable</c>, which starts at the origin.</summary>
public class MutablePositionAndRotation {
    public Vec3d Position { get; private set; }
    public float YRot { get; private set; }
    public float XRot { get; private set; }

    public PositionAndRotation Immutable() => new(Position, YRot, XRot);

    /// <summary><c>PositionAndRotation.is</c>: the angles by <c>==</c>, the position by <c>Vec3.equals</c>.</summary>
    public bool Is(Vec3d position, float yRot, float xRot) => YRot == yRot && XRot == xRot && PositionPath.JavaEquals(Position, position);

    public void Set(Vec3d position, float yRot, float xRot) {
        Position = position;
        YRot = yRot;
        XRot = xRot;
    }

    public virtual void AddDelta(Vec3d delta) => Position += delta;

    public virtual void AddRotation(float yRot, float xRot) {
        YRot += yRot;
        XRot += xRot;
    }
}

/// <summary>
/// <c>PositionPath</c>: where a move from the server ends, and for a stepped one each point it passes
/// through and how many ticks after the one before it the entity should reach it.
/// </summary>
public abstract record PositionPath {
    public abstract Vec3d EndPosition { get; }

    public static PositionPath Of(Vec3d position) => new Linear(position);

    public sealed record Linear(Vec3d End) : PositionPath {
        public override Vec3d EndPosition => End;
    }

    /// <summary>Never empty: a stepped delta with no steps decodes as a linear path to the codec's base.</summary>
    public sealed record Stepped(IReadOnlyList<PositionStep> Steps) : PositionPath {
        public override Vec3d EndPosition => Steps[^1].Position;
    }

    /// <summary><c>Vec3.equals</c>, by <c>Double.compare</c> on each axis.</summary>
    internal static bool JavaEquals(Vec3d a, Vec3d b) => JavaEquals(a.X, b.X) && JavaEquals(a.Y, b.Y) && JavaEquals(a.Z, b.Z);

    private static bool JavaEquals(double a, double b) => BitConverter.DoubleToInt64Bits(a) == BitConverter.DoubleToInt64Bits(b) || double.IsNaN(a) && double.IsNaN(b);
}

/// <summary><c>PositionStep</c>.</summary>
public readonly record struct PositionStep(Vec3d Position, int TickOffset);

/// <summary><c>AbstractInterpolationHandler</c>.</summary>
public abstract class AbstractInterpolationHandler(MinecraftClient client, ClientEntity entity, int interpolationSteps) : IInterpolationHandler {
    protected readonly ClientEntity Entity = entity;
    protected int InterpolationSteps = interpolationSteps;
    private readonly MutablePositionAndRotation _lastPositionAndRotation = new();

    protected abstract MutablePositionAndRotation InterpolationData { get; }

    protected abstract void StartInterpolating(PositionPath position, float yRot, float xRot);

    protected abstract void DoInterpolate();

    public abstract bool HasActiveInterpolation { get; }

    public abstract void Cancel();

    public PositionAndRotation? Target => HasActiveInterpolation ? InterpolationData.Immutable() : null;

    public bool InterpolateTo(PositionPath? position, float yRot, float xRot, bool hasRotation) {
        PositionAndRotation current = HasActiveInterpolation ? InterpolationData.Immutable() : Entity.StorePositionAndRotation();
        InterpolateTo(position ?? PositionPath.Of(current.Position), hasRotation ? yRot : current.YRot, hasRotation ? xRot : current.XRot);
        return true;
    }

    private void InterpolateTo(PositionPath position, float yRot, float xRot) {
        if (InterpolationSteps == 0) {
            Entity.SnapTo(position.EndPosition, yRot, xRot);
            Cancel();
        }
        else if (!HasActiveInterpolation || !InterpolationData.Is(position.EndPosition, yRot, xRot)) {
            StartInterpolating(position, yRot, xRot);
            SetLastPositionAndRotation();
            Entity.OnInterpolationStart(this);
        }
    }

    public void ApplyPredictedMovement(Vec3d delta) {
        AdjustInterpolationPosition(delta);
        _lastPositionAndRotation.AddDelta(delta);
    }

    public void Interpolate() {
        if (!HasActiveInterpolation) {
            Cancel();
        }
        else {
            AdjustInterpolationTargetFromDeltas();
            DoInterpolate();
            SetLastPositionAndRotation();
        }
    }

    private void AdjustInterpolationPosition(Vec3d delta) {
        Vec3d adjustedPosition = InterpolationData.Position + delta;
        if (NoCollision(Entity.MakeBoundingBox(adjustedPosition))) {
            InterpolationData.AddDelta(delta);
        }
    }

    private void AdjustInterpolationTargetFromDeltas() {
        Vec3d deltaSinceLastInterpolation = Entity.Position - _lastPositionAndRotation.Position;
        if (deltaSinceLastInterpolation.LengthSqr() > 1.0E-5F) {
            AdjustInterpolationPosition(deltaSinceLastInterpolation);
        }

        float deltaYRotSinceLastInterpolation = Entity.YRot - _lastPositionAndRotation.YRot;
        float deltaXRotSinceLastInterpolation = Entity.XRot - _lastPositionAndRotation.XRot;
        InterpolationData.AddRotation(deltaYRotSinceLastInterpolation, deltaXRotSinceLastInterpolation);
    }

    private void SetLastPositionAndRotation() => _lastPositionAndRotation.Set(Entity.Position, Entity.YRot, Entity.XRot);

    /// <summary>
    /// <c>CollisionGetter.noCollision(entity, box)</c>. An entity the client does not simulate has no
    /// collision context of its own, so liquids, powder snow and scaffolding collide as they do for no entity.
    /// </summary>
    private bool NoCollision(Box box) {
        if (Entity is PhysicsEntity physics) {
            return physics.NoCollision(box);
        }
        return client.Level is not { } level || LevelCollisions.NoCollision(level, box) && EntityCollisions.None(client, Entity, box);
    }

    /// <summary><c>Level.getRelativeTickSpeed</c>, as <c>ClientLevel</c> overrides it: faster only above 20 ticks a second.</summary>
    protected float RelativeTickSpeed {
        get {
            float tickrate = client.Level?.TickRateManager.TickRate ?? 20.0F;
            return tickrate > 20.0F ? tickrate / 20.0F : 1.0F;
        }
    }
}

/// <summary><c>LinearInterpolationHandler</c>: a fixed number of steps to the end of the path, whatever it passes through.</summary>
public sealed class LinearInterpolationHandler(MinecraftClient client, ClientEntity entity, int interpolationSteps = LinearInterpolationHandler.DefaultInterpolationSteps)
    : AbstractInterpolationHandler(client, entity, interpolationSteps) {
    public const int DefaultInterpolationSteps = 3;

    private readonly Data _data = new();

    public void SetInterpolationLength(int steps) => InterpolationSteps = steps;

    protected override MutablePositionAndRotation InterpolationData => _data;

    protected override void StartInterpolating(PositionPath position, float yRot, float xRot) {
        _data.Set(position.EndPosition, yRot, xRot);
        _data.RemainingSteps = InterpolationSteps;
    }

    protected override void DoInterpolate() {
        double alpha = 1.0 / _data.RemainingSteps;
        Vec3d from = Entity.Position;
        Vec3d to = _data.Position;
        Vec3d newPosition = new(ClientEntity.Lerp(alpha, from.X, to.X), ClientEntity.Lerp(alpha, from.Y, to.Y), ClientEntity.Lerp(alpha, from.Z, to.Z));
        float newYRot = (float)ClientEntity.RotLerp(alpha, Entity.YRot, _data.YRot);
        float newXRot = (float)ClientEntity.Lerp(alpha, Entity.XRot, _data.XRot);
        Entity.Position = newPosition;
        Entity.SetRot(newYRot, newXRot);
        _data.RemainingSteps--;
    }

    public override bool HasActiveInterpolation => _data.RemainingSteps > 0;

    public override void Cancel() => _data.RemainingSteps = 0;

    private sealed class Data : MutablePositionAndRotation {
        public int RemainingSteps;
    }
}
