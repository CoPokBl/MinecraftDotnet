using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;

namespace Minecraft.Data.Components.Types;

public record AxolotlVariantComponent() : IDataComponent<AxolotlVariant> {
    public override Identifier Identifier => "minecraft:axolotl/variant";

    public override NbtCodec<AxolotlVariant>? Codec => Persistent;
    private static readonly NbtCodec<AxolotlVariant> Persistent = NbtCodecs.Enum<AxolotlVariant>("minecraft:axolotl/variant");

    public override DataWriter WriteData(AxolotlVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt((int)val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return (AxolotlVariant)reader.ReadVarInt();
    }

    public override bool ValuesEqual(AxolotlVariant val1, AxolotlVariant val2) {
        return val1 == val2;
    }
}
