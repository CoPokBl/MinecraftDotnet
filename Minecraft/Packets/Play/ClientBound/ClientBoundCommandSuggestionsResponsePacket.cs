using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Answers a <c>ServerBoundCommandSuggestionsRequestPacket</c>.</summary>
public class ClientBoundCommandSuggestionsResponsePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:command_suggestions";

    /// <summary>Matches the transaction id of the request this answers.</summary>
    public required int TransactionId { get; init; }

    /// <summary>Index into the typed command of the first character the suggestions replace.</summary>
    public required int Start { get; init; }

    /// <summary>Number of characters the suggestions replace.</summary>
    public required int Length { get; init; }

    public required Suggestion[] Suggestions { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(TransactionId)
            .WriteVarInt(Start)
            .WriteVarInt(Length)
            .WritePrefixedArray(Suggestions, (suggestion, writer) => writer
                .WriteString(suggestion.Text)
                .WritePrefixedOptional(suggestion.Tooltip, (tooltip, tw) => tw.WriteNbt(tooltip)));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundCommandSuggestionsResponsePacket {
        TransactionId = r.ReadVarInt(),
        Start = r.ReadVarInt(),
        Length = r.ReadVarInt(),
        Suggestions = r.ReadPrefixedArray(reader => new Suggestion(
            reader.ReadString(),
            reader.ReadPrefixedOptional(tr => tr.ReadText())))
    };

    /// <param name="Text">The text that replaces the range described by the packet.</param>
    /// <param name="Tooltip">Hover text shown beside the suggestion, if any.</param>
    public record Suggestion(string Text, TextComponent? Tooltip = null);
}
