using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas;

public record DeathLocation(string Dimension, IVec3 Position);