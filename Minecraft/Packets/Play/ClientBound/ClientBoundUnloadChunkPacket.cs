using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUnloadChunkPacket() : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:forget_level_chunk";
    
    public required int X { get; init; }
    public required int Z { get; init; }

    public ClientBoundUnloadChunkPacket(Vec2<int> pos) : this() {
        X = pos.X;
        Z = pos.Y;
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
