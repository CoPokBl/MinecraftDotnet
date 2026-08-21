using Minecraft.Data.CatVariant;
using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record CatVariantComponent() : IDataComponent<ICatVariant> {
    public override Identifier Identifier => "minecraft:cat/variant";

    public override NbtCodec<ICatVariant>? Codec => Persistent;
    private static readonly NbtCodec<ICatVariant> Persistent = NbtCodecs.Holder<ICatVariant>("minecraft:cat/variant", reg => reg.CatVariants);

    public override DataWriter WriteData(ICatVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.CatVariants.GetProtocolId(val));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return registry.CatVariants[reader.ReadVarInt()];
    }

    public override bool ValuesEqual(ICatVariant val1, ICatVariant val2) {
        return val1.Identifier == val2.Identifier;
    }
}
