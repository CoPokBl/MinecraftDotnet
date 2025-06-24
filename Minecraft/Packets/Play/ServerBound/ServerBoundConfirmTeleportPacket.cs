namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundConfirmTeleportPacket : ServerBoundPacket {
    public required int TeleportId;

    protected override byte[] GetData() {
        return new DataWriter().WriteVarInt(TeleportId).ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundConfirmTeleportPacket {
        TeleportId = r.ReadVarInt()
    };
}
