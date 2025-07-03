using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUnloadChunkPacket() : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:forget_level_chunk";
    
    public required int X;
    public required int Z;

    public ClientBoundUnloadChunkPacket(ChunkPosition pos) : this() {
        X = pos.X;
        Z = pos.Z;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteInteger(Z)
            .WriteInteger(X)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundUnloadChunkPacket {
        Z = r.ReadInteger(),
        X = r.ReadInteger()
    };
}
