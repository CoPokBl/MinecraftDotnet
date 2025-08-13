using Minecraft.Schemas.Chunks;

namespace ManagedServer.Worlds.Lighting;

public class FullDarkLightingProvider : ILightingProvider {
    
    public LightData GenerateLighting(ChunkData chunk, World world) {
        return LightData.FullDark;
    }
}
