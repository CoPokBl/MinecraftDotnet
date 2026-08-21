using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;

namespace Minecraft.Data.Components.Types;

public record FoxVariantComponent() : IDataComponent<FoxVariant> {
    public override Identifier Identifier => "minecraft:fox/variant";

    public override NbtCodec<FoxVariant>? Codec => Persistent;
    private static readonly NbtCodec<FoxVariant> Persistent = NbtCodecs.Enum<FoxVariant>("minecraft:fox/variant");

    public override DataWriter WriteData(FoxVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt((int)val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return (FoxVariant)reader.ReadVarInt();
    }

    public override bool ValuesEqual(FoxVariant val1, FoxVariant val2) {
        return val1 == val2;
    }
}
