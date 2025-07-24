using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas;

public record DeathLocation(string Dimension, Vec3<int> Position);
