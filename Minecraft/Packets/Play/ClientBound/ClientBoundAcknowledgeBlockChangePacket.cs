using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundAcknowledgeBlockChangePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:block_changed_ack";
    
    public required int SequenceId;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(SequenceId);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundAcknowledgeBlockChangePacket {
        SequenceId = r.ReadVarInt()
    };
}
