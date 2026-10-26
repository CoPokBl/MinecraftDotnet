using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Components.Types;

public record AttackAnimationComponent() : IDataComponent<SwingAnimation> {
    public override Identifier Identifier => "minecraft:attack_animation";

    public override NbtCodec<SwingAnimation>? Codec => Persistent;
    private static readonly NbtCodec<SwingAnimation> Persistent = SwingAnimation.CodecFor("minecraft:attack_animation");

    public override DataWriter WriteData(SwingAnimation val, DataWriter writer, MinecraftRegistry registry) {
        return val.WriteData(writer);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return SwingAnimation.ReadData(reader);
    }

    public override bool ValuesEqual(SwingAnimation val1, SwingAnimation val2) {
        return val1 == val2;
    }
}
