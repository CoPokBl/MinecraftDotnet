using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Only sent by single player worlds opened to LAN; a server ignores it.</summary>
public class ServerBoundChangeDifficultyPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:change_difficulty";

    public required ClientBoundChangeDifficultyPacket.DifficultySetting Difficulty { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt((int)Difficulty);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundChangeDifficultyPacket {
        Difficulty = (ClientBoundChangeDifficultyPacket.DifficultySetting)r.ReadVarInt()
    };
}
