using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundOpenBookPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:open_book";

    public required Hand Hand { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt((int)Hand);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundOpenBookPacket {
        Hand = (Hand)r.ReadVarInt()
    };
}
