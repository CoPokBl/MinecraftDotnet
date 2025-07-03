using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSwingArmPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:swing";
    
    public required Hand UsedHand;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt((int)UsedHand)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundSwingArmPacket {
        UsedHand = (Hand)r.ReadVarInt()
    };
}
