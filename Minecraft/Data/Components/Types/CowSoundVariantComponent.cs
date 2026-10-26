using Minecraft.Data.Components.Codecs;
using Minecraft.Data.CowSoundVariant;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record CowSoundVariantComponent() : IDataComponent<ICowSoundVariant> {
    public override Identifier Identifier => "minecraft:cow/sound_variant";

    public override NbtCodec<ICowSoundVariant>? Codec => Persistent;
    private static readonly NbtCodec<ICowSoundVariant> Persistent = NbtCodecs.Holder<ICowSoundVariant>("minecraft:cow/sound_variant", reg => reg.CowSoundVariants);

    public override DataWriter WriteData(ICowSoundVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.CowSoundVariants.GetProtocolId(val));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return registry.CowSoundVariants[reader.ReadVarInt()];
    }

    public override bool ValuesEqual(ICowSoundVariant val1, ICowSoundVariant val2) {
        return val1.Identifier == val2.Identifier;
    }
}
