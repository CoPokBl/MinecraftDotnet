using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;

namespace Minecraft.Data.Components.Types;

public record RabbitVariantComponent() : IDataComponent<RabbitVariant> {
    public override Identifier Identifier => "minecraft:rabbit/variant";

    public override NbtCodec<RabbitVariant>? Codec => Persistent;
    private static readonly NbtCodec<RabbitVariant> Persistent = NbtCodecs.Enum<RabbitVariant>("minecraft:rabbit/variant");

    public override DataWriter WriteData(RabbitVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt((int)val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return (RabbitVariant)reader.ReadVarInt();
    }

    public override bool ValuesEqual(RabbitVariant val1, RabbitVariant val2) {
        return val1 == val2;
    }
}
