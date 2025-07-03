using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundAcknowledgeBlockChangePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:block_changed_ack";
    
    public required int SequenceId;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(SequenceId)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundAcknowledgeBlockChangePacket {
        SequenceId = r.ReadVarInt()
    };
}
