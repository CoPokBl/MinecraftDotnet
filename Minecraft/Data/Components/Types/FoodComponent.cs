using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record FoodComponent(FoodComponent.Info Value) : IDataComponent<FoodComponent.Info> {
    public Identifier Identifier => "minecraft:food";
    public static FoodComponent Default => new(new Info(0, 0.0f, false));
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        writer.WriteVarInt(Value.Nutrition);
        writer.WriteFloat(Value.SaturationModifier);
        writer.WriteBoolean(Value.CanAlwaysEat);
        return writer;
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        int nutrition = reader.ReadVarInt();
        float saturationModifier = reader.ReadFloat();
        bool canAlwaysEat = reader.ReadBoolean();
        return new FoodComponent(new Info(nutrition, saturationModifier, canAlwaysEat));
    }
    
    public record Info(int Nutrition, float SaturationModifier, bool CanAlwaysEat);
}
