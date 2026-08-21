using Minecraft.Data.Components.Codecs;
using Minecraft.Data.PaintingVariant;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>The picture a painting item hangs, fixed rather than rolled on placement.</summary>
public record PaintingVariantComponent() : IDataComponent<IPaintingVariant> {
    public override Identifier Identifier => "minecraft:painting/variant";

    public override NbtCodec<IPaintingVariant>? Codec => Persistent;
    private static readonly NbtCodec<IPaintingVariant> Persistent = NbtCodecs.Holder<IPaintingVariant>("minecraft:painting/variant", reg => reg.PaintingVariants);

    public override DataWriter WriteData(IPaintingVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteHolder(val, registry.PaintingVariants, (inline, w) => w.Write(inline, registry));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadHolder(id => registry.PaintingVariants[id], r => IPaintingVariant.ReadData(r, registry));
    }

    public override bool ValuesEqual(IPaintingVariant val1, IPaintingVariant val2) {
        return val1.Identifier == val2.Identifier;
    }
}
