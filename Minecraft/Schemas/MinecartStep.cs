using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas;

/// <summary>
/// One tick of a minecart's path along a rail, sent ahead of time so the client can follow the
/// track rather than interpolate in a straight line.
/// </summary>
/// <param name="Position">Where the cart is at this step.</param>
/// <param name="Movement">The cart's velocity at this step.</param>
/// <param name="Yaw">Rotation around the vertical axis.</param>
/// <param name="Pitch">Rotation around the horizontal axis.</param>
/// <param name="Weight">How strongly this step pulls the interpolation towards it.</param>
public record MinecartStep(Vec3<double> Position, Vec3<double> Movement, Angle Yaw, Angle Pitch, float Weight)
    : IWritable {

    public void Write(DataWriter w) {
        w.WriteVec3(Position)
            .WriteVec3(Movement)
            .WriteAngle(Yaw)
            .WriteAngle(Pitch)
            .WriteFloat(Weight);
    }

    public static MinecartStep Read(DataReader r) {
        return new MinecartStep(
            r.ReadVec3(),
            r.ReadVec3(),
            r.ReadAngle(),
            r.ReadAngle(),
            r.ReadFloat());
    }
}
