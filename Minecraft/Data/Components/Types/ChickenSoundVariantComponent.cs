using Minecraft.Data.ChickenSoundVariant;
using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record ChickenSoundVariantComponent() : IDataComponent<IChickenSoundVariant> {
    public override Identifier Identifier => "minecraft:chicken/sound_variant";

    public override NbtCodec<IChickenSoundVariant>? Codec => Persistent;
    private static readonly NbtCodec<IChickenSoundVariant> Persistent = NbtCodecs.Holder<IChickenSoundVariant>("minecraft:chicken/sound_variant", reg => reg.ChickenSoundVariants);

    public override DataWriter WriteData(IChickenSoundVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.ChickenSoundVariants.GetProtocolId(val));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return registry.ChickenSoundVariants[reader.ReadVarInt()];
    }

    public override bool ValuesEqual(IChickenSoundVariant val1, IChickenSoundVariant val2) {
        return val1.Identifier == val2.Identifier;
    }
}
