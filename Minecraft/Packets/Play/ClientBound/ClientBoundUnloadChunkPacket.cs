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

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteInteger(Z)
            .WriteInteger(X);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundUnloadChunkPacket {
        Z = r.ReadInteger(),
        X = r.ReadInteger()
    };
}
