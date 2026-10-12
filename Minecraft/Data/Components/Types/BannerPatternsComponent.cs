using Minecraft.Data.BannerPattern;
using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// The layers a loom put on a banner or shield, bottom first. The banner's own colour is
/// <see cref="BaseColorComponent"/> and is not one of these.
/// </summary>
public record BannerPatternsComponent() : IDataComponent<BannerPatternsComponent.Layer[]> {
    public override Identifier Identifier => "minecraft:banner_patterns";

    public override NbtCodec<Layer[]>? Codec => Persistent;
    private static readonly NbtCodec<Layer[]> Persistent = new(
        (val, _) => new ListTag(val
            .Select(layer => (INbtTag)new CompoundBuilder()
                .Holder("pattern", layer.Pattern)
                .Enum("color", layer.Color)
                .Build())
            .ToArray()),
        (tag, registry) => tag.AsList()
            .Select(entry => {
                NbtNode node = NbtNode.Of(entry, "minecraft:banner_patterns");
                Layer layer = new(
                    node.Holder("pattern", registry.BannerPatterns),
                    node.Enum<DyeColor>("color"));
                node.AssertRead();
                return layer;
            })
            .ToArray());

    public override DataWriter WriteData(Layer[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, (layer, w) => w
            .WriteHolder(layer.Pattern, registry.BannerPatterns, (inline, wr) => wr.Write(inline, registry))
            .WriteVarInt((int)layer.Color));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadPrefixedArray(r => new Layer(
            r.ReadHolder(id => registry.BannerPatterns[id], re => IBannerPattern.ReadData(re, registry)),
            (DyeColor)r.ReadVarInt()));
    }

    public override bool ValuesEqual(Layer[] val1, Layer[] val2) {
        if (val1.Length != val2.Length) return false;
        for (int i = 0; i < val1.Length; i++) {
            if (val1[i].Pattern.Identifier != val2[i].Pattern.Identifier || val1[i].Color != val2[i].Color) {
                return false;
            }
        }
        return true;
    }

    public record Layer(IBannerPattern Pattern, DyeColor Color);
}
