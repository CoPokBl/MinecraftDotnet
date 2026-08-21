using Minecraft.Data.Components.Codecs;
using Minecraft.Data.CowVariant;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record CowVariantComponent() : IDataComponent<ICowVariant> {
    public override Identifier Identifier => "minecraft:cow/variant";

    public override NbtCodec<ICowVariant>? Codec => Persistent;
    private static readonly NbtCodec<ICowVariant> Persistent = NbtCodecs.Holder<ICowVariant>("minecraft:cow/variant", reg => reg.CowVariants);

    public override DataWriter WriteData(ICowVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.CowVariants.GetProtocolId(val));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return registry.CowVariants[reader.ReadVarInt()];
    }

    public override bool ValuesEqual(ICowVariant val1, ICowVariant val2) {
        return val1.Identifier == val2.Identifier;
    }
}
