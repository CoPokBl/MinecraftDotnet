using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Unused by the vanilla client, which ignores it.</summary>
public class ClientBoundEndCombatPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:player_combat_end";

    /// <summary>Length of the combat in ticks.</summary>
    public required int Duration { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt(Duration);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundEndCombatPacket {
        Duration = r.ReadVarInt()
    };
}
