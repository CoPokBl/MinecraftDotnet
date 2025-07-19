using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record FoodComponent(int ProtocolId) : IDataComponent<FoodComponent.Info> {
    public override Identifier Identifier => "minecraft:food";
    
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
    
    public record Info(int Nutrition, float SaturationModifier, bool CanAlwaysEat);
}
