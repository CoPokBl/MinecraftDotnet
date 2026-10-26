using Minecraft.Data.Components.Codecs;
using Minecraft.Schemas;

namespace Minecraft.Schemas.Items;

/// <summary><c>SwingAnimation</c>, which both the attack and the interact animation components carry.</summary>
/// <param name="Duration">Ticks the swing takes.</param>
public record SwingAnimation(SwingAnimationType Type = SwingAnimationType.Whack, int Duration = 6) {
    /// <summary>Vanilla's own defaults, which every item carries unless it says otherwise.</summary>
    public static SwingAnimation Default => new();

    internal static NbtCodec<SwingAnimation> CodecFor(Identifier component) => new(
        (val, _) => new CompoundBuilder()
            .Enum("type", val.Type, SwingAnimationType.Whack)
            .Int("duration", val.Duration, 6)
            .Build(),
        (tag, _) => {
            NbtNode node = NbtNode.Of(tag, component);
            SwingAnimation data = new(
                node.Enum("type", SwingAnimationType.Whack),
                node.Int("duration", 6));
            node.AssertRead();
            return data;
        });

    internal DataWriter WriteData(DataWriter writer) {
        return writer.WriteVarInt((int)Type).WriteVarInt(Duration);
    }

    internal static SwingAnimation ReadData(DataReader reader) {
        return new SwingAnimation((SwingAnimationType)reader.ReadVarInt(), reader.ReadVarInt());
    }
}
