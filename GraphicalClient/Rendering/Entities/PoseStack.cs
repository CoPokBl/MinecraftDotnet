using System.Numerics;

namespace GraphicalClient.Rendering.Entities;

/// <summary>
/// Vanilla's <c>PoseStack</c>. Each call applies its transform before everything already on the stack,
/// as JOML's post-multiplication does for column vectors; with <see cref="Matrix4x4"/>'s row vectors
/// that is a pre-multiplication, which is why every method here puts the new matrix on the left.
/// </summary>
public sealed class PoseStack {
    private (Matrix4x4 Pose, Matrix4x4 Normal)[] _saved = new (Matrix4x4, Matrix4x4)[8];
    private int _depth;
    private Matrix4x4 _pose = Matrix4x4.Identity;
    private Matrix4x4 _normal = Matrix4x4.Identity;

    public Matrix4x4 Matrix => _pose;

    public PoseStack() { }

    /// <summary>A stack starting from a transform, whose normals turn with it.</summary>
    public PoseStack(Matrix4x4 start) {
        _pose = start;
        _normal = start;
    }

    [ThreadStatic] private static Stack<PoseStack>? _spare;

    /// <summary>An identity stack to give back with <see cref="Return"/>, as every entity drawn each frame takes one.</summary>
    public static PoseStack Rent() => _spare is { Count: > 0 } spare ? spare.Pop() : new PoseStack();

    public static void Return(PoseStack pose) {
        pose._depth = 0;
        pose._pose = pose._normal = Matrix4x4.Identity;
        (_spare ??= new Stack<PoseStack>()).Push(pose);
    }

    public void Push() {
        if (_depth == _saved.Length) {
            Array.Resize(ref _saved, _depth * 2);
        }
        _saved[_depth++] = (_pose, _normal);
    }

    public void Pop() {
        if (_depth == 0) {
            throw new InvalidOperationException("Pose stack is empty");
        }
        (_pose, _normal) = _saved[--_depth];
    }

    public void Translate(float x, float y, float z) => _pose = Matrix4x4.CreateTranslation(x, y, z) * _pose;

    public void Translate(Vector3 offset) => Translate(offset.X, offset.Y, offset.Z);

    /// <summary>
    /// A scale, with the normal matrix taking its inverse. A uniform negative scale flips every normal
    /// the way vanilla's special case does; a non-uniform one inverts per axis.
    /// </summary>
    public void Scale(float x, float y, float z) {
        _pose = Matrix4x4.CreateScale(x, y, z) * _pose;
        if (x == y && y == z) {
            if (x < 0) {
                _normal = Matrix4x4.CreateScale(-1) * _normal;
            }
            return;
        }
        _normal = Matrix4x4.CreateScale(1 / x, 1 / y, 1 / z) * _normal;
    }

    public void Rotate(Matrix4x4 rotation) {
        _pose = rotation * _pose;
        _normal = rotation * _normal;
    }

    public void RotateX(float radians) => Rotate(Matrix4x4.CreateRotationX(radians));
    public void RotateY(float radians) => Rotate(Matrix4x4.CreateRotationY(radians));
    public void RotateZ(float radians) => Rotate(Matrix4x4.CreateRotationZ(radians));

    public void RotateXDegrees(float degrees) => RotateX(degrees * MathF.PI / 180.0F);
    public void RotateYDegrees(float degrees) => RotateY(degrees * MathF.PI / 180.0F);
    public void RotateZDegrees(float degrees) => RotateZ(degrees * MathF.PI / 180.0F);

    /// <summary>JOML's <c>rotationZYX(z, y, x)</c>: X turns first, then Y, then Z.</summary>
    public void RotateZYX(float z, float y, float x) =>
        Rotate(Matrix4x4.CreateRotationX(x) * Matrix4x4.CreateRotationY(y) * Matrix4x4.CreateRotationZ(z));

    /// <summary>JOML's <c>rotationXYZ(x, y, z)</c>: Z turns first, then Y, then X.</summary>
    public void RotateXYZ(float x, float y, float z) =>
        Rotate(Matrix4x4.CreateRotationZ(z) * Matrix4x4.CreateRotationY(y) * Matrix4x4.CreateRotationX(x));

    public void MulPose(Quaternion rotation) => Rotate(Matrix4x4.CreateFromQuaternion(rotation));

    /// <summary><c>Pose.mulPose(Matrix4fc)</c>: any affine transform, normals by its inverse transpose.</summary>
    public void MulPose(Matrix4x4 transform) {
        if (transform.IsIdentity) {
            return;
        }
        _pose = transform * _pose;
        if (Matrix4x4.Invert(transform, out Matrix4x4 inverse)) {
            inverse.Translation = Vector3.Zero;
            _normal = Matrix4x4.Transpose(inverse) * _normal;
        }
    }

    public Vector3 TransformNormal(Vector3 normal) {
        Vector3 turned = Vector3.TransformNormal(normal, _normal);
        float length = turned.Length();
        return length > 0 ? turned / length : normal;
    }
}
