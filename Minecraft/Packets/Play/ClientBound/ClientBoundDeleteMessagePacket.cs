using Minecraft.Schemas;
using Minecraft.Schemas.Chat;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Removes a chat message the client has already shown.</summary>
public class ClientBoundDeleteMessagePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:delete_chat";

    /// <summary>Identifies the message to remove, by its signature or its cache index.</summary>
    public required PackedMessageSignature Signature { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.Write(Signature);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundDeleteMessagePacket {
        Signature = PackedMessageSignature.Read(r)
    };
}
