using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record MaxDamageComponent(int Value) : IDataComponent<int> {
    public static MaxDamageComponent Default => new(0);
    public Identifier Identifier => "minecraft:max_damage";
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(Value);
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        return new MaxDamageComponent(reader.ReadVarInt());
    }
}
