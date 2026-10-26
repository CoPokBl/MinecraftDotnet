using Minecraft.Data.Components.Codecs;
using Minecraft.Data.TrimMaterial;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>The trim material a smithing table takes from the item.</summary>
public record ProvidesTrimMaterialComponent() : IDataComponent<ITrimMaterial> {
    public override Identifier Identifier => "minecraft:provides_trim_material";

    public override NbtCodec<ITrimMaterial>? Codec => Persistent;
    private static readonly NbtCodec<ITrimMaterial> Persistent = NbtCodecs.Holder<ITrimMaterial>("minecraft:provides_trim_material", reg => reg.TrimMaterials);

    public override DataWriter WriteData(ITrimMaterial val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteHolder(val, registry.TrimMaterials, (inline, w) => w.Write(inline, registry));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadHolder(id => registry.TrimMaterials[id], r => ITrimMaterial.ReadData(r, registry));
    }

    public override bool ValuesEqual(ITrimMaterial val1, ITrimMaterial val2) {
        return val1.Identifier == val2.Identifier;
    }
}
