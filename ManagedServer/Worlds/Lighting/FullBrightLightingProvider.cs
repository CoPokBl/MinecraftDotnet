using Minecraft.Schemas.Chunks;

namespace ManagedServer.Worlds.Lighting;

public class FullBrightLightingProvider : ILightingProvider {
    
    public LightData GenerateLighting(ChunkData chunk, World world) {
        return LightData.FullBright;
    }
}
