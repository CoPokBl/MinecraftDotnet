using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;

namespace Minecraft.Data.Components.Types;

public record MooshroomVariantComponent() : IDataComponent<MooshroomVariant> {
    public override Identifier Identifier => "minecraft:mooshroom/variant";

    public override NbtCodec<MooshroomVariant>? Codec => Persistent;
    private static readonly NbtCodec<MooshroomVariant> Persistent = NbtCodecs.Enum<MooshroomVariant>("minecraft:mooshroom/variant");

    public override DataWriter WriteData(MooshroomVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt((int)val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return (MooshroomVariant)reader.ReadVarInt();
    }

    public override bool ValuesEqual(MooshroomVariant val1, MooshroomVariant val2) {
        return val1 == val2;
    }
}
