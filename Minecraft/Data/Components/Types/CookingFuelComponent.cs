using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Components.Types;

/// <summary>How long the item burns in a furnace, and how fast it cooks while it does.</summary>
public record CookingFuelComponent() : IDataComponent<CookingFuelComponent.Data> {
    public override Identifier Identifier => "minecraft:cooking_fuel";

    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, _) => new CompoundBuilder()
            .Tag("burn_time", val.BurnTime.ToNbt())
            .Tag("speed_multiplier", val.SpeedMultiplier.ToNbt())
            .Build(),
        (tag, _) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:cooking_fuel");
            Data data = new(ResolvableInt.FromNbt(node.Require("burn_time")), ResolvableFloat.FromNbt(node.Require("speed_multiplier")));
            node.AssertRead();
            return data;
        });

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return val.SpeedMultiplier.WriteData(val.BurnTime.WriteData(writer));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(ResolvableInt.ReadData(reader), ResolvableFloat.ReadData(reader));
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1 == val2;
    }

    public record Data(ResolvableInt BurnTime, ResolvableFloat SpeedMultiplier);
}
