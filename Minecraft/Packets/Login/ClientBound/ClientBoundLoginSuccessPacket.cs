using Minecraft.Schemas;

namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundLoginSuccessPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:login_finished";
    
    public required string Username;
    public required Guid Uuid;

    protected override DataWriter WriteData(DataWriter w) {
        w.WriteUuid(Uuid);
        w.WriteString(Username);
        w.WritePrefixedArray(Array.Empty<int>(), (_, _) => { });
        return w;
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundLoginSuccessPacket {
        Uuid = r.ReadUuid(),
        Username = r.ReadString()
    };
}
