using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Packet to set the entity that the player renders their view from.
/// Set entity ID to the player's entity ID to reset it.
/// <p/>
/// This is used in spectator mode when a player clicks an entity.
/// </summary>
public class ClientBoundSetCameraPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_camera";
    
    public required int EntityId;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetCameraPacket {
        EntityId = r.ReadVarInt()
    };
}
