using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record RepairCostComponent(int Value) : IDataComponent<int> {
    public Identifier Identifier => "minecraft:repair_cost";
    public static RepairCostComponent Default => new(0);
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(Value);
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        return new RepairCostComponent(reader.ReadVarInt());
    }
}
