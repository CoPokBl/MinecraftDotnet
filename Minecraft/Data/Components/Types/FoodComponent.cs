using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record FoodComponent() : IDataComponent<FoodComponent.Info> {
    public override Identifier Identifier => "minecraft:food";

    /// <summary>
    /// The key is <c>saturation</c> where the field is the modifier it is multiplied by, which is
    /// vanilla's naming. Both it and the nutrition are required.
    /// </summary>
    public override NbtCodec<Info>? Codec => Persistent;
    private static readonly NbtCodec<Info> Persistent = new(
        (val, _) => new CompoundBuilder()
            .Int("nutrition", val.Nutrition)
            .Float("saturation", val.SaturationModifier)
            .Bool("can_always_eat", val.CanAlwaysEat, false)
            .Build(),
        (tag, _) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:food");
            Info info = new(
                node.Int("nutrition"),
                node.Float("saturation"),
                node.Bool("can_always_eat", false));
            node.AssertRead();
            return info;
        });
    
    public override DataWriter WriteData(Info val, DataWriter writer, MinecraftRegistry registry) {
        writer.WriteVarInt(val.Nutrition);
        writer.WriteFloat(val.SaturationModifier);
        writer.WriteBoolean(val.CanAlwaysEat);
        return writer;
    }

    public override Info ReadData(DataReader reader, MinecraftRegistry registry) {
        int nutrition = reader.ReadVarInt();
        float saturationModifier = reader.ReadFloat();
        bool canAlwaysEat = reader.ReadBoolean();
        return new Info(nutrition, saturationModifier, canAlwaysEat);
    }

    public override bool ValuesEqual(Info val1, Info val2) {
        return val1 == val2;
    }

    public record Info(int Nutrition, float SaturationModifier, bool CanAlwaysEat);
}
