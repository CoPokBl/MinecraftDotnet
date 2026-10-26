using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Components.Types;

/// <summary>How many layers a composter gains from the item.</summary>
public record CompostableComponent() : IDataComponent<ResolvableInt> {
    public override Identifier Identifier => "minecraft:compostable";

    public override NbtCodec<ResolvableInt>? Codec => Persistent;
    private static readonly NbtCodec<ResolvableInt> Persistent = NbtCodecs.Wrapped<ResolvableInt>("minecraft:compostable", "layers",
        (val, _) => val.ToNbt(), (tag, _) => ResolvableInt.FromNbt(tag));

    public override DataWriter WriteData(ResolvableInt val, DataWriter writer, MinecraftRegistry registry) {
        return val.WriteData(writer);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return ResolvableInt.ReadData(reader);
    }

    public override bool ValuesEqual(ResolvableInt val1, ResolvableInt val2) {
        return val1 == val2;
    }
}
