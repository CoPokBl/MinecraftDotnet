using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Chunks;

namespace Conformance;

/// <summary>
/// Chunk packets, which reflection can't fabricate: the sections are a bit packed format whose
/// palettes and bits per entry have to agree with each other, so a default constructed one is
/// either invalid or (worse) trivially empty.
/// </summary>
/// <remarks>
/// Several shapes, because the section encoding branches on how many distinct blocks it holds:
/// one block picks a single value palette, a handful picks an indirect palette sized to fit,
/// and enough of them falls back to writing state ids directly. Only exercising the empty case
/// would leave the interesting branches unchecked.
/// </remarks>
public static class ChunkSamples {
    private const int WorldHeight = ChunkData.VanillaOverworldHeight;

    /// <summary>The section count the client will read, which is fixed by the world height.</summary>
    public static int SectionCount => WorldHeight / ChunkSection.Size;

    public static IEnumerable<(string Name, MinecraftPacket Packet)> Build() {
        yield return ("ClientBoundChunkDataAndUpdateLightPacket[empty]", Packet(BuildEmpty()));
        yield return ("ClientBoundChunkDataAndUpdateLightPacket[single value palette]", Packet(BuildFilled()));
        yield return ("ClientBoundChunkDataAndUpdateLightPacket[indirect palette]", Packet(BuildIndirect()));
        yield return ("ClientBoundChunkDataAndUpdateLightPacket[direct palette]", Packet(BuildDirect()));
    }

    private static ClientBoundChunkDataAndUpdateLightPacket Packet(ChunkData data) {
        data.PackData();
        return new ClientBoundChunkDataAndUpdateLightPacket {
            ChunkX = 0,
            ChunkZ = 0,
            Data = data,
            Light = LightData.FullBright
        };
    }

    private static ChunkData BuildEmpty() {
        return new ChunkData(WorldHeight);
    }

    private static ChunkData BuildFilled() {
        ChunkData data = new(WorldHeight);
        data.Fill(Block.Stone);
        return data;
    }

    /// <summary>A few distinct blocks per section, which is what an indirect palette is for.</summary>
    private static ChunkData BuildIndirect() {
        ChunkData data = new(WorldHeight);
        data.Fill(Block.Stone);

        for (int y = 0; y < WorldHeight; y++) {
            data.SetBlock(y % 16, y, 0, y % 2 == 0 ? Block.Dirt.StateId : Block.Cobblestone.StateId);
        }

        return data;
    }

    /// <summary>
    /// Enough distinct states that the palette stops paying for itself and state ids go out
    /// directly.
    /// </summary>
    private static ChunkData BuildDirect() {
        ChunkData data = new(WorldHeight);
        data.FillRandom();
        return data;
    }
}
