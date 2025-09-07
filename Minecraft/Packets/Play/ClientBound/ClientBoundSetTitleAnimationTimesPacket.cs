using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

// all fields are in ticks
public class ClientBoundSetTitleAnimationTimesPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_titles_animation";
    
    public required int FadeIn { get; init; }
    public required int Stay { get; init; }
    public required int FadeOut { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteInteger(FadeIn)
            .WriteInteger(Stay)
            .WriteInteger(FadeOut);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetTitleAnimationTimesPacket {
        FadeIn = r.ReadInteger(),
        Stay = r.ReadInteger(),
        FadeOut = r.ReadInteger()
    };
}
