using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundConfirmTeleportPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:accept_teleportation";
    
    public required int TeleportId;

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt(TeleportId);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundConfirmTeleportPacket {
        TeleportId = r.ReadVarInt()
    };
}
