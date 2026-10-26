using System.Numerics;
using ClientLib.Maths;
using Minecraft.Data.EnvironmentAttributes;

namespace GraphicalClient.Rendering;

/// <summary>
/// Where the frame is drawn from. Geometry is drawn relative to <see cref="Position"/>, so the view
/// matrix holds only the rotation and float precision never meets a world coordinate.
/// </summary>
public sealed class Camera {
    public Vec3d Position { get; private set; }

    /// <summary><c>Camera.attributeProbe</c>: the environment attributes where the camera is, ticked at last frame's position.</summary>
    public EnvironmentAttributeProbe AttributeProbe { get; } = new();
    public float Yaw { get; private set; }
    public float Pitch { get; private set; }
    public Matrix4x4 View { get; private set; } = Matrix4x4.Identity;
    public Matrix4x4 Projection { get; private set; } = Matrix4x4.Identity;

    /// <summary>
    /// <c>Camera.createProjectionMatrixForCulling</c>: at the wider of the view's field of view and the
    /// option's, so a spyglass's zoom does not cull what the next frame out of it shows.
    /// </summary>
    public Matrix4x4 CullProjection { get; private set; } = Matrix4x4.Identity;

    /// <summary>
    /// The hurt tilt, view bob and spinning warp, in view space. Vanilla multiplies them into the projection
    /// it draws with and leaves them out of the one it culls with, as <see cref="RenderProjection"/> and
    /// <see cref="CullProjection"/> do here.
    /// </summary>
    public Matrix4x4 Bob { get; set; } = Matrix4x4.Identity;

    public Matrix4x4 RenderProjection => Bob * Projection;
    public float FovDegrees { get; set; } = 70.0F;

    /// <summary>The field of view <see cref="FovDegrees"/> is culled at, the option's.</summary>
    public float CullFovDegrees { get; set; } = 70.0F;

    /// <summary><c>Camera.hudFov</c>: what the hand and the screen effects are drawn at.</summary>
    public float HudFovDegrees { get; set; } = 70.0F;

    public const float NearPlane = 0.05F;
    public float FarPlane { get; private set; }

    /// <summary>Width over height of the projection.</summary>
    public float Aspect { get; private set; } = 1.0F;

    public Vector3 Forward => Look(Yaw, Pitch);

    /// <summary>The view's up, square to <see cref="Forward"/>.</summary>
    public Vector3 Up { get; private set; } = Vector3.UnitY;

    /// <summary>Vanilla's convention: yaw 0 faces south (+Z) and turns clockwise, pitch is positive looking down.</summary>
    public static Vector3 Look(float yawDegrees, float pitchDegrees) {
        float yaw = yawDegrees * MathF.PI / 180.0F;
        float pitch = pitchDegrees * MathF.PI / 180.0F;
        return new Vector3(-MathF.Sin(yaw) * MathF.Cos(pitch), -MathF.Sin(pitch), MathF.Cos(yaw) * MathF.Cos(pitch));
    }

    public void Update(Vec3d position, float yaw, float pitch, float aspect, float farPlane) {
        Position = position;
        Yaw = yaw;
        Pitch = pitch;
        // Up from the yaw rather than the world's: looking straight up or down the world's up is parallel
        // to the view and the look-at basis collapses, flipping the picture.
        float yawRadians = yaw * MathF.PI / 180.0F;
        Vector3 right = new(-MathF.Cos(yawRadians), 0, -MathF.Sin(yawRadians));
        Up = Vector3.Cross(right, Forward);
        View = Matrix4x4.CreateLookAt(Vector3.Zero, Forward, Up);
        FarPlane = farPlane;
        Aspect = aspect;
        Projection = Frustum.Perspective(FovDegrees * MathF.PI / 180.0F, aspect, NearPlane, farPlane);
        CullProjection = Frustum.Perspective(Math.Max(FovDegrees, CullFovDegrees) * MathF.PI / 180.0F, aspect, NearPlane, farPlane);
    }
}
