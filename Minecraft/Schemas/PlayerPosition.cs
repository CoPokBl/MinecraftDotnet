using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas;

public record PlayerPosition(Vec3<double> Position, Vec3<double> Velocity, Angle Yaw, Angle Pitch) {
    public int ChunkX => (int)Position.X / 16;
    public int ChunkZ => (int)Position.Z / 16;
}
