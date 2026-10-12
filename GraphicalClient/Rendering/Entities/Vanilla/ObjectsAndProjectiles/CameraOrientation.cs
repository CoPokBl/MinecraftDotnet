using System.Numerics;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>
/// <c>CameraRenderState.orientation</c>, which billboards turn by: <c>Camera.setRotation</c>'s
/// <c>rotationYXZ(PI - yRot, -xRot, 0)</c>.
/// </summary>
public static class CameraOrientation {
    public static void Apply(PoseStack pose, Camera camera) {
        pose.RotateY(MathF.PI - camera.Yaw * Mth.DegToRad);
        pose.RotateX(-camera.Pitch * Mth.DegToRad);
    }

    /// <summary>
    /// JOML's <c>rotate(Quaternionfc)</c>, which does not normalise: a quaternion off unit length, such as
    /// a boat's bubble tilt built with <c>setAngleAxis</c> about an unnormalised axis, scales as it turns.
    /// </summary>
    public static Matrix4x4 JomlRotation(float x, float y, float z, float w) {
        float w2 = w * w, x2 = x * x, y2 = y * y, z2 = z * z;
        float zw = z * w, dzw = zw + zw, xy = x * y, dxy = xy + xy, xz = x * z, dxz = xz + xz;
        float yw = y * w, dyw = yw + yw, yz = y * z, dyz = yz + yz, xw = x * w, dxw = xw + xw;
        return new Matrix4x4(
            w2 + x2 - z2 - y2, dxy + dzw, dxz - dyw, 0,
            -dzw + dxy, y2 - z2 + w2 - x2, dyz + dxw, 0,
            dyw + dxz, dyz - dxw, z2 - y2 - x2 + w2, 0,
            0, 0, 0, 1);
    }
}
