using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundChunkDataAndUpdateLightPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:level_chunk_with_light";
    
    public required int ChunkX;
    public required int ChunkZ;
    public required ChunkData Data;
    public required LightData Light;

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry registry) {
        return w
            .WriteInteger(ChunkX)
            .WriteInteger(ChunkZ)
            .Write(wr => Data.Write(wr, registry))
            .Write(Light);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundChunkDataAndUpdateLightPacket {
        ChunkX = r.ReadInteger(),
        ChunkZ = r.ReadInteger(),
        Data = ChunkData.Read(r, reg),
        Light = LightData.FullBright  // TODO .Read()
    };
}
