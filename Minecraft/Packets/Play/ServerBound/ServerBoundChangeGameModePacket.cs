using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Sent by the game mode switcher, which only an operator's client offers.</summary>
public class ServerBoundChangeGameModePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:change_game_mode";

    public required GameMode Mode { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt((int)Mode);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundChangeGameModePacket {
        Mode = (GameMode)r.ReadVarInt()
    };
}
