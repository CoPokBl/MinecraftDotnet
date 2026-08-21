using Minecraft.Data.Components.Codecs;
using Minecraft.Data.WolfSoundVariant;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record WolfSoundVariantComponent() : IDataComponent<IWolfSoundVariant> {
    public override Identifier Identifier => "minecraft:wolf/sound_variant";

    public override NbtCodec<IWolfSoundVariant>? Codec => Persistent;
    private static readonly NbtCodec<IWolfSoundVariant> Persistent = NbtCodecs.Holder<IWolfSoundVariant>("minecraft:wolf/sound_variant", reg => reg.WolfSoundVariants);

    public override DataWriter WriteData(IWolfSoundVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.WolfSoundVariants.GetProtocolId(val));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return registry.WolfSoundVariants[reader.ReadVarInt()];
    }

    public override bool ValuesEqual(IWolfSoundVariant val1, IWolfSoundVariant val2) {
        return val1.Identifier == val2.Identifier;
    }
}
