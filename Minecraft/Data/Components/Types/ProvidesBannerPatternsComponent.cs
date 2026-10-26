using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>Banner patterns the item unlocks in a loom.</summary>
public record ProvidesBannerPatternsComponent() : IDataComponent<IdSet> {
    public override Identifier Identifier => "minecraft:provides_banner_patterns";

    public override NbtCodec<IdSet>? Codec => Persistent;
    private static readonly NbtCodec<IdSet> Persistent = NbtCodecs.IdSet("minecraft:provides_banner_patterns", reg => reg.BannerPatterns);

    public override DataWriter WriteData(IdSet val, DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(val, registry);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.Read<IdSet>(registry);
    }

    public override bool ValuesEqual(IdSet val1, IdSet val2) {
        return val1.Equals(val2);
    }
}
