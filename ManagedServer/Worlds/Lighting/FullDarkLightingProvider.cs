using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Worlds.Lighting;

public class FullDarkLightingProvider : ILightingProvider {
    public LightData GetLighting(Vec2<int> chunkPos, ChunkData chunk,
        Func<Vec2<int>, ChunkData?>? neighborLookup, MinecraftRegistry registry, bool hasSkyLight) {
        return LightData.FullDark;
    }

    public void Invalidate(Vec2<int> chunkPos) { }
}
