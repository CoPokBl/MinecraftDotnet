using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;

namespace Minecraft.Data.Components.Types;

public record ParrotVariantComponent() : IDataComponent<ParrotVariant> {
    public override Identifier Identifier => "minecraft:parrot/variant";

    public override NbtCodec<ParrotVariant>? Codec => Persistent;
    private static readonly NbtCodec<ParrotVariant> Persistent = NbtCodecs.Enum<ParrotVariant>("minecraft:parrot/variant");

    public override DataWriter WriteData(ParrotVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt((int)val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return (ParrotVariant)reader.ReadVarInt();
    }

    public override bool ValuesEqual(ParrotVariant val1, ParrotVariant val2) {
        return val1 == val2;
    }
}
