using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundChunkDataAndUpdateLightPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:level_chunk_with_light";
    
    public required int ChunkX;
    public required int ChunkZ;
    public required ChunkData Data;
    public required LightData Light;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteInteger(ChunkX)
            .WriteInteger(ChunkZ)
            .Write(Data)
            .Write(Light);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundChunkDataAndUpdateLightPacket {
        ChunkX = r.ReadInteger(),
        ChunkZ = r.ReadInteger(),
        Data = new ChunkData().Read(r),
        Light = LightData.FullBright  // TODO .Read()
    };
}
