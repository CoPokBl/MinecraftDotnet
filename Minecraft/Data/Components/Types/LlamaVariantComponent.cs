using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;

namespace Minecraft.Data.Components.Types;

public record LlamaVariantComponent() : IDataComponent<LlamaVariant> {
    public override Identifier Identifier => "minecraft:llama/variant";

    public override NbtCodec<LlamaVariant>? Codec => Persistent;
    private static readonly NbtCodec<LlamaVariant> Persistent = NbtCodecs.Enum<LlamaVariant>("minecraft:llama/variant");

    public override DataWriter WriteData(LlamaVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt((int)val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return (LlamaVariant)reader.ReadVarInt();
    }

    public override bool ValuesEqual(LlamaVariant val1, LlamaVariant val2) {
        return val1 == val2;
    }
}
