using Minecraft.Data.Components.Codecs;
using Minecraft.Data.PigVariant;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record PigVariantComponent() : IDataComponent<IPigVariant> {
    public override Identifier Identifier => "minecraft:pig/variant";

    public override NbtCodec<IPigVariant>? Codec => Persistent;
    private static readonly NbtCodec<IPigVariant> Persistent = NbtCodecs.Holder<IPigVariant>("minecraft:pig/variant", reg => reg.PigVariants);

    public override DataWriter WriteData(IPigVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.PigVariants.GetProtocolId(val));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return registry.PigVariants[reader.ReadVarInt()];
    }

    public override bool ValuesEqual(IPigVariant val1, IPigVariant val2) {
        return val1.Identifier == val2.Identifier;
    }
}
