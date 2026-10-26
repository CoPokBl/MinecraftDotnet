using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSpectatorActionPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:spectator_action";

    /// <summary>
    /// The entity the player wants to spectate, or null to stop spectating.
    /// </summary>
    public int? SpectateEntityId { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        // Sent one higher than the real id so that zero can mean "no entity"
        return w
            .WriteVarInt(SpectateEntityId.HasValue ? SpectateEntityId.Value + 1 : 0);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        int rawEntityId = r.ReadVarInt();
        return new ServerBoundSpectatorActionPacket {
            SpectateEntityId = rawEntityId == 0 ? null : rawEntityId - 1
        };
    };
}
