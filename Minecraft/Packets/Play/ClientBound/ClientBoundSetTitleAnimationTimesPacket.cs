namespace Minecraft.Packets.Play.ClientBound;

// all fields are in ticks
public class ClientBoundSetTitleAnimationTimesPacket : ClientBoundPacket {
    public required int FadeIn;
    public required int Stay;
    public required int FadeOut;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteInteger(FadeIn)
            .WriteInteger(Stay)
            .WriteInteger(FadeOut)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetTitleAnimationTimesPacket {
        FadeIn = r.ReadInteger(),
        Stay = r.ReadInteger(),
        FadeOut = r.ReadInteger()
    };
}
