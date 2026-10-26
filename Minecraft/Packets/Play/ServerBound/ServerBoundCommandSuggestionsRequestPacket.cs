using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Asks the server to complete a partially typed command.</summary>
public class ServerBoundCommandSuggestionsRequestPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:command_suggestion";

    /// <summary>Echoed back in the response so the client can match them up.</summary>
    public required int TransactionId { get; init; }

    /// <summary>What the player has typed so far, leading slash included.</summary>
    public required string Command { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(TransactionId)
            .WriteString(Command);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundCommandSuggestionsRequestPacket {
        TransactionId = r.ReadVarInt(),
        Command = r.ReadString()
    };
}
