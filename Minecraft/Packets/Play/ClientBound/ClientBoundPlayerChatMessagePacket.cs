using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chat;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Sends a chat message that came from a player, along with everything the client needs to check
/// its signature. Server-generated messages go out as
/// <see cref="ClientBoundDisguisedChatMessagePacket"/> or
/// <see cref="ClientBoundSystemChatMessagePacket"/> instead.
/// </summary>
public class ClientBoundPlayerChatMessagePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:player_chat";

    /// <summary>Counts every chat message the server has sent this client, signed or not.</summary>
    public required int GlobalIndex { get; init; }

    public required Guid Sender { get; init; }

    /// <summary>Counts the messages this sender has signed, which the signature covers.</summary>
    public required int Index { get; init; }

    /// <summary>The sender's signature over the message, or null when it wasn't signed.</summary>
    public byte[]? Signature { get; init; }

    /// <summary>The plain text the sender signed.</summary>
    public required string Content { get; init; }

    /// <summary>When the message was sent, which the signature covers.</summary>
    public required DateTimeOffset Timestamp { get; init; }

    /// <summary>Random value mixed into the signature.</summary>
    public required long Salt { get; init; }

    /// <summary>The messages the sender had seen when they sent this one.</summary>
    public PackedMessageSignature[] LastSeen { get; init; } = [];

    /// <summary>A replacement the server wants shown instead of the signed content, if any.</summary>
    public TextComponent? UnsignedContent { get; init; }

    public required ChatFilterMask FilterMask { get; init; }

    public required BoundChatType ChatType { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        w.WriteVarInt(GlobalIndex)
            .WriteUuid(Sender)
            .WriteVarInt(Index)
            .WritePrefixedOptional(Signature, (signature, writer) => writer.Write(signature))
            .WriteString(Content)
            .WriteLong(Timestamp.ToUnixTimeMilliseconds())
            .WriteLong(Salt)
            .WritePrefixedArray(LastSeen, (entry, writer) => writer.Write(entry))
            .WritePrefixedOptional(UnsignedContent, (content, writer) => writer.WriteNbt(content));

        FilterMask.Write(w);
        return w.Write(ChatType, reg);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundPlayerChatMessagePacket {
        GlobalIndex = r.ReadVarInt(),
        Sender = r.ReadUuid(),
        Index = r.ReadVarInt(),
        Signature = r.ReadPrefixedOptional(reader => reader.Read(PackedMessageSignature.SignatureLength)),
        Content = r.ReadString(),
        Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(r.ReadLong()),
        Salt = r.ReadLong(),
        LastSeen = r.ReadPrefixedArray(PackedMessageSignature.Read),
        UnsignedContent = r.ReadPrefixedOptional(reader => reader.ReadText()),
        FilterMask = ChatFilterMask.Read(r),
        ChatType = r.Read<BoundChatType>(reg)
    };
}
