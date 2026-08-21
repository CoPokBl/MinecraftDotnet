using Minecraft.Data.Components.Codecs;
using Minecraft.Data.PigSoundVariant;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record PigSoundVariantComponent() : IDataComponent<IPigSoundVariant> {
    public override Identifier Identifier => "minecraft:pig/sound_variant";

    public override NbtCodec<IPigSoundVariant>? Codec => Persistent;
    private static readonly NbtCodec<IPigSoundVariant> Persistent = NbtCodecs.Holder<IPigSoundVariant>("minecraft:pig/sound_variant", reg => reg.PigSoundVariants);

    public override DataWriter WriteData(IPigSoundVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.PigSoundVariants.GetProtocolId(val));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return registry.PigSoundVariants[reader.ReadVarInt()];
    }

    public override bool ValuesEqual(IPigSoundVariant val1, IPigSoundVariant val2) {
        return val1.Identifier == val2.Identifier;
    }
}
