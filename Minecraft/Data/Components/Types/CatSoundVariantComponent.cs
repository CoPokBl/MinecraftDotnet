using Minecraft.Data.CatSoundVariant;
using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record CatSoundVariantComponent() : IDataComponent<ICatSoundVariant> {
    public override Identifier Identifier => "minecraft:cat/sound_variant";

    public override NbtCodec<ICatSoundVariant>? Codec => Persistent;
    private static readonly NbtCodec<ICatSoundVariant> Persistent = NbtCodecs.Holder<ICatSoundVariant>("minecraft:cat/sound_variant", reg => reg.CatSoundVariants);

    public override DataWriter WriteData(ICatSoundVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.CatSoundVariants.GetProtocolId(val));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return registry.CatSoundVariants[reader.ReadVarInt()];
    }

    public override bool ValuesEqual(ICatSoundVariant val1, ICatSoundVariant val2) {
        return val1.Identifier == val2.Identifier;
    }
}
