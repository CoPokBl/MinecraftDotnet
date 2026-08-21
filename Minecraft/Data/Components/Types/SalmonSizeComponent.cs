using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;

namespace Minecraft.Data.Components.Types;

public record SalmonSizeComponent() : IDataComponent<SalmonSize> {
    public override Identifier Identifier => "minecraft:salmon/size";

    public override NbtCodec<SalmonSize>? Codec => Persistent;
    private static readonly NbtCodec<SalmonSize> Persistent = NbtCodecs.Enum<SalmonSize>("minecraft:salmon/size");

    public override DataWriter WriteData(SalmonSize val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt((int)val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return (SalmonSize)reader.ReadVarInt();
    }

    public override bool ValuesEqual(SalmonSize val1, SalmonSize val2) {
        return val1 == val2;
    }
}
