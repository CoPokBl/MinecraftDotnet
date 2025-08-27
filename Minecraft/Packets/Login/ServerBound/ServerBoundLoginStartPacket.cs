using Minecraft.Schemas;

namespace Minecraft.Packets.Login.ServerBound;

public class ServerBoundLoginStartPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:hello";
    
    public required Guid Uuid { get; init; }
    public required string Name { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        w.WriteString(Name);
        w.WriteUuid(Uuid);
        return w;
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundLoginStartPacket {
        Name = r.ReadString(),
        Uuid = r.ReadUuid()
    };
}
