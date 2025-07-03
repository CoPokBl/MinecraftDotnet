using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundConfirmTeleportPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:accept_teleportation";
    
    public required int TeleportId;

    protected override byte[] GetData() {
        return new DataWriter().WriteVarInt(TeleportId).ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundConfirmTeleportPacket {
        TeleportId = r.ReadVarInt()
    };
}
