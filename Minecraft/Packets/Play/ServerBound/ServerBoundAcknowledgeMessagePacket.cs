using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>
/// Confirms how many chat messages the client has seen, letting the server drop that many from
/// the signature cache it expects the client to know.
/// </summary>
public class ServerBoundAcknowledgeMessagePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:chat_ack";

    /// <summary>How many messages the client has acknowledged since the last time it sent this.</summary>
    public required int MessageCount { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt(MessageCount);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundAcknowledgeMessagePacket {
        MessageCount = r.ReadVarInt()
    };
}
