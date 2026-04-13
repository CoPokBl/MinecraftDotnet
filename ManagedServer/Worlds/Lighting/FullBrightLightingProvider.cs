using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Worlds.Lighting;

public class FullBrightLightingProvider : ILightingProvider {
    public LightData GetLighting(Vec2<int> chunkPos, ChunkData chunk,
        Func<Vec2<int>, ChunkData?>? neighborLookup, MinecraftRegistry registry, bool hasSkyLight) {
        return LightData.FullBright;
    }

    public void Invalidate(Vec2<int> chunkPos) { }
}
