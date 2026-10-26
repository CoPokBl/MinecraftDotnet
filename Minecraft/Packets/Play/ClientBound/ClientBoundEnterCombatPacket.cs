using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Unused by the vanilla client, which ignores it.</summary>
public class ClientBoundEnterCombatPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:player_combat_enter";

    protected override DataWriter WriteData(DataWriter w) {
        return w;
    }

    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ClientBoundEnterCombatPacket();
}
