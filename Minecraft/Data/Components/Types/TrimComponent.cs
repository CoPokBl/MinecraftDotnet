using Minecraft.Data.Components.Codecs;
using Minecraft.Data.TrimMaterial;
using Minecraft.Data.TrimPattern;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>The armour trim smithing applied, vanilla's <c>ArmorTrim</c>.</summary>
public record TrimComponent() : IDataComponent<TrimComponent.Data> {
    public override Identifier Identifier => "minecraft:trim";

    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, _) => new CompoundBuilder()
            .Holder("material", val.Material)
            .Holder("pattern", val.Pattern)
            .Build(),
        (tag, registry) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:trim");
            Data data = new(
                node.Holder("material", registry.TrimMaterials),
                node.Holder("pattern", registry.TrimPatterns));
            node.AssertRead();
            return data;
        });

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteHolder(val.Material, registry.TrimMaterials, (inline, w) => w.Write(inline, registry))
            .WriteHolder(val.Pattern, registry.TrimPatterns, (inline, w) => w.Write(inline, registry));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(
            reader.ReadHolder(id => registry.TrimMaterials[id], r => ITrimMaterial.ReadData(r, registry)),
            reader.ReadHolder(id => registry.TrimPatterns[id], r => ITrimPattern.ReadData(r, registry)));
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1.Material.Identifier == val2.Material.Identifier &&
               val1.Pattern.Identifier == val2.Pattern.Identifier;
    }

    public record Data(ITrimMaterial Material, ITrimPattern Pattern);
}
