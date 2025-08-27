using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetCooldownPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:cooldown";

    public required Identifier CooldownGroup { get; init; }
    public required int Ticks { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteString(CooldownGroup)
                .WriteVarInt(Ticks);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (reader, _) => new ClientBoundSetCooldownPacket {
        CooldownGroup = reader.ReadString(),
        Ticks = reader.ReadVarInt()
    };
}
