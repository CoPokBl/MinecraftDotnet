using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundChunkBatchStartPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:chunk_batch_start";

    protected override DataWriter WriteData(DataWriter w) {
        return w;
    }

    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ClientBoundChunkBatchStartPacket();
}
