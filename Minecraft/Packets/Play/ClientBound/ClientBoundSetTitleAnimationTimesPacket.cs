namespace Minecraft.Packets.Play.ClientBound;

// all fields are in ticks
public class ClientBoundSetTitleAnimationTimesPacket(int fadeIn, int stay, int fadeOut) : MinecraftPacket {
    public int FadeIn = fadeIn;
    public int Stay = stay;
    public int FadeOut = fadeOut;
    
    public ClientBoundSetTitleAnimationTimesPacket() : this(0, 0, 0) { }

    public override int GetPacketId() {
        return 0x6C;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteInteger(FadeIn)
            .WriteInteger(Stay)
            .WriteInteger(FadeOut)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        FadeIn = r.ReadInteger();
        Stay = r.ReadInteger();
        FadeOut = r.ReadInteger();
        return this;
    }
}