using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Components.Types;

public record SwingAnimationComponent() : IDataComponent<SwingAnimationComponent.Data> {
    public override Identifier Identifier => "minecraft:swing_animation";

    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, _) => new CompoundBuilder()
            .Enum("type", val.Type, SwingAnimationType.Whack)
            .Int("duration", val.Duration, 6)
            .Build(),
        (tag, _) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:swing_animation");
            Data data = new(
                node.Enum("type", SwingAnimationType.Whack),
                node.Int("duration", 6));
            node.AssertRead();
            return data;
        });

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt((int)val.Type).WriteVarInt(val.Duration);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data((SwingAnimationType)reader.ReadVarInt(), reader.ReadVarInt());
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1 == val2;
    }

    /// <param name="Duration">Ticks the swing takes.</param>
    public record Data(SwingAnimationType Type = SwingAnimationType.Whack, int Duration = 6) {
        /// <summary>Vanilla's own defaults, which every item carries unless it says otherwise.</summary>
        public static Data Default => new();
    }
}
