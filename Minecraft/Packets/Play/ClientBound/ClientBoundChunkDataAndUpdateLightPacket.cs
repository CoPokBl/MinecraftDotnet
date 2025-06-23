using Minecraft.Schemas.Chunks;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundChunkDataAndUpdateLightPacket(int chunkX, int chunkZ, ChunkData data, LightData light) : MinecraftPacket {
    public int ChunkX = chunkX;
    public int ChunkZ = chunkZ;
    public ChunkData Data = data;
    public LightData Light = light;

    public ClientBoundChunkDataAndUpdateLightPacket() : this(0, 0, new ChunkData(), new LightData()) { }
    
    public override int GetPacketId() {
        return 0x27;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteInteger(ChunkX)
            .WriteInteger(ChunkZ)
            .Write(Data)
            .Write(Light).ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        ChunkX = r.ReadInteger();
        ChunkZ = r.ReadInteger();
        Data = new ChunkData().Read(r); 
        Light = new LightData();  // TODO .Read()
        return this;
    }
}