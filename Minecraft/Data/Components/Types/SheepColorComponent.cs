using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record SheepColorComponent() : IDataComponent<DyeColor> {
    public override Identifier Identifier => "minecraft:sheep/color";

    public override NbtCodec<DyeColor>? Codec => Persistent;
    private static readonly NbtCodec<DyeColor> Persistent = NbtCodecs.Enum<DyeColor>("minecraft:sheep/color");

    public override DataWriter WriteData(DyeColor val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt((int)val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return (DyeColor)reader.ReadVarInt();
    }

    public override bool ValuesEqual(DyeColor val1, DyeColor val2) {
        return val1 == val2;
    }
}
