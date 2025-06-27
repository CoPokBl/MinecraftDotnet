using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas;

public record PlayerPosition(Vec3 Position, Vec3 Velocity, Angle Yaw, Angle Pitch) {
    public int ChunkX => (int)Position.X / 16;
    public int ChunkZ => (int)Position.Z / 16;
}