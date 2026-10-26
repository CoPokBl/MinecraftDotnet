using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Components.Types;

/// <summary>How many brews the item fuels in a brewing stand, and how fast.</summary>
public record BrewingFuelComponent() : IDataComponent<BrewingFuelComponent.Data> {
    public override Identifier Identifier => "minecraft:brewing_fuel";

    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, _) => new CompoundBuilder()
            .Tag("uses", val.Uses.ToNbt())
            .Tag("speed_multiplier", val.SpeedMultiplier.ToNbt())
            .Build(),
        (tag, _) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:brewing_fuel");
            Data data = new(ResolvableInt.FromNbt(node.Require("uses")), ResolvableFloat.FromNbt(node.Require("speed_multiplier")));
            node.AssertRead();
            return data;
        });

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return val.SpeedMultiplier.WriteData(val.Uses.WriteData(writer));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(ResolvableInt.ReadData(reader), ResolvableFloat.ReadData(reader));
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1 == val2;
    }

    public record Data(ResolvableInt Uses, ResolvableFloat SpeedMultiplier);
}
