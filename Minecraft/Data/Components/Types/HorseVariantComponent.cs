using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;

namespace Minecraft.Data.Components.Types;

public record HorseVariantComponent() : IDataComponent<HorseVariant> {
    public override Identifier Identifier => "minecraft:horse/variant";

    public override NbtCodec<HorseVariant>? Codec => Persistent;
    private static readonly NbtCodec<HorseVariant> Persistent = NbtCodecs.Enum<HorseVariant>("minecraft:horse/variant");

    public override DataWriter WriteData(HorseVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt((int)val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return (HorseVariant)reader.ReadVarInt();
    }

    public override bool ValuesEqual(HorseVariant val1, HorseVariant val2) {
        return val1 == val2;
    }
}
