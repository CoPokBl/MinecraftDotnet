using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSwingArmPacket(Hand hand) : MinecraftPacket {
    public Hand UsedHand = hand;

    public ServerBoundSwingArmPacket() : this(Hand.MainHand) { }

    public override int GetPacketId() {
        return 0x3B;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt((int)UsedHand)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        UsedHand = (Hand)new DataReader(data).ReadVarInt();
        return this;
    }
}