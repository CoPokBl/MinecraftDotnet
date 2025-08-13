using Minecraft.Schemas.Chunks;

namespace ManagedServer.Worlds.Lighting;

public interface ILightingProvider {
    LightData GenerateLighting(ChunkData chunk, World world);
}
