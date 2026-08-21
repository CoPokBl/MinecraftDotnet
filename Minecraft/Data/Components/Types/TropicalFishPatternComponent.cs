using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;

namespace Minecraft.Data.Components.Types;

public record TropicalFishPatternComponent() : IDataComponent<TropicalFishPattern> {
    public override Identifier Identifier => "minecraft:tropical_fish/pattern";

    public override NbtCodec<TropicalFishPattern>? Codec => Persistent;
    private static readonly NbtCodec<TropicalFishPattern> Persistent = NbtCodecs.Enum<TropicalFishPattern>("minecraft:tropical_fish/pattern");

    public override DataWriter WriteData(TropicalFishPattern val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt((int)val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return (TropicalFishPattern)reader.ReadVarInt();
    }

    public override bool ValuesEqual(TropicalFishPattern val1, TropicalFishPattern val2) {
        return val1 == val2;
    }
}
