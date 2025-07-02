using Minecraft.Schemas.Chunks;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundChunkDataAndUpdateLightPacket : ClientBoundPacket {
    public required int ChunkX;
    public required int ChunkZ;
    public required ChunkData Data;
    public required LightData Light;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteInteger(ChunkX)
            .WriteInteger(ChunkZ)
            .Write(Data)
            .Write(Light).ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundChunkDataAndUpdateLightPacket {
        ChunkX = r.ReadInteger(),
        ChunkZ = r.ReadInteger(),
        Data = new ChunkData().Read(r),
        Light = LightData.FullBright  // TODO .Read()
    };
}