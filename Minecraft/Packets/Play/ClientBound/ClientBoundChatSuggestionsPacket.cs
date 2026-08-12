using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Adds to or replaces the client's list of chat auto-completion entries. These are separate from
/// the command suggestions the server computes on demand.
/// </summary>
public class ClientBoundChatSuggestionsPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:custom_chat_completions";

    public required SuggestionAction Action { get; init; }
    public required string[] Entries { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt((int)Action)
            .WritePrefixedArray(Entries, (entry, writer) => writer.WriteString(entry));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundChatSuggestionsPacket {
        Action = (SuggestionAction)r.ReadVarInt(),
        Entries = r.ReadPrefixedArray(reader => reader.ReadString())
    };

    public enum SuggestionAction {
        Add = 0,
        Remove = 1,
        Set = 2
    }
}
