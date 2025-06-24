using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSwingArmPacket : ServerBoundPacket {
    public required Hand UsedHand;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt((int)UsedHand)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundSwingArmPacket {
        UsedHand = (Hand)r.ReadVarInt()
    };
}
