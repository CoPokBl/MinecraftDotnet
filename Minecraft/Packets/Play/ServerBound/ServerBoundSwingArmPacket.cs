using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSwingArmPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:swing";
    
    public required Hand UsedHand;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt((int)UsedHand);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundSwingArmPacket {
        UsedHand = (Hand)r.ReadVarInt()
    };
}
