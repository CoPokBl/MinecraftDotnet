using ClientLib.Maths;

namespace ClientLib.Entities;

/// <summary>
/// <c>InterpolationHandler</c> for an entity that also moves itself: whatever it moved since the last
/// step is carried over to the target, so its own motion is not undone by the server's position.
/// </summary>
public sealed class InterpolationHandler(SimulatedEntity entity, int interpolationSteps = 3) {
    private int _steps;
    private Vec3d _position;
    private float _yRot, _xRot;
    private Vec3d? _previousTickPosition;
    private (float X, float Y)? _previousTickRot;

    public Vec3d Position => _steps > 0 ? _position : entity.Position;
    public float YRot => _steps > 0 ? _yRot : entity.YRot;
    public float XRot => _steps > 0 ? _xRot : entity.XRot;

    public bool HasActiveInterpolation => _steps > 0;

    /// <summary><c>InterpolationHandler.interpolateTo</c>. A repeat of the target in progress does not restart it.</summary>
    public void InterpolateTo(Vec3d position, float yRot, float xRot) {
        if (interpolationSteps == 0) {
            entity.Snap(position, yRot, xRot);
            Cancel();
            return;
        }
        if (HasActiveInterpolation && JavaEquals(YRot, yRot) && JavaEquals(XRot, xRot) && JavaEquals(Position, position)) {
            return;
        }
        _steps = interpolationSteps;
        _position = position;
        _yRot = yRot;
        _xRot = xRot;
        _previousTickPosition = entity.Position;
        _previousTickRot = (entity.XRot, entity.YRot);
    }

    /// <summary><c>InterpolationHandler.interpolate</c>.</summary>
    public void Interpolate() {
        if (!HasActiveInterpolation) {
            Cancel();
            return;
        }

        double alpha = 1.0 / _steps;
        if (_previousTickPosition is { } previous) {
            Vec3d deltaSinceLastInterpolation = entity.Position - previous;
            if (entity.NoCollision(entity.MakeBoundingBox(_position + deltaSinceLastInterpolation))) {
                _position += deltaSinceLastInterpolation;
            }
        }
        if (_previousTickRot is { } previousRot) {
            _yRot += entity.YRot - previousRot.Y;
            _xRot += entity.XRot - previousRot.X;
        }

        Vec3d newPosition = new(
            ClientEntity.Lerp(alpha, entity.Position.X, _position.X),
            ClientEntity.Lerp(alpha, entity.Position.Y, _position.Y),
            ClientEntity.Lerp(alpha, entity.Position.Z, _position.Z));
        float newYRot = (float)ClientEntity.RotLerp(alpha, entity.YRot, _yRot);
        float newXRot = (float)ClientEntity.Lerp(alpha, entity.XRot, _xRot);
        entity.Position = newPosition;
        entity.YRot = newYRot % 360.0F;
        entity.XRot = newXRot % 360.0F;
        _steps--;
        _previousTickPosition = newPosition;
        _previousTickRot = (entity.XRot, entity.YRot);
    }

    public void Cancel() {
        _steps = 0;
        _previousTickPosition = null;
        _previousTickRot = null;
    }

    /// <summary><c>Float.equals</c>, which tells the zeroes apart and finds NaN equal to itself.</summary>
    internal static bool JavaEquals(float a, float b) => BitConverter.SingleToInt32Bits(a) == BitConverter.SingleToInt32Bits(b) || float.IsNaN(a) && float.IsNaN(b);

    /// <summary><c>Vec3.equals</c>, by <c>Double.compare</c> on each axis.</summary>
    internal static bool JavaEquals(Vec3d a, Vec3d b) => JavaEquals(a.X, b.X) && JavaEquals(a.Y, b.Y) && JavaEquals(a.Z, b.Z);

    internal static bool JavaEquals(double a, double b) => BitConverter.DoubleToInt64Bits(a) == BitConverter.DoubleToInt64Bits(b) || double.IsNaN(a) && double.IsNaN(b);
}
