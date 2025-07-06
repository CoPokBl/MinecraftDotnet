using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record MaxStackSizeComponent(int Value) : IDataComponent<int> {
    public static MaxStackSizeComponent Default => new(0);
    public Identifier Identifier => "minecraft:max_stack_size";
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(Value);
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        return new MaxStackSizeComponent(reader.ReadVarInt());
    }
}
