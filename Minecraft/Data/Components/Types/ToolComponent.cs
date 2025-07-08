using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Components.Types;

public record ToolComponent(Tool Value) : IDataComponent<Tool> {
    public Identifier Identifier => "minecraft:tool";
    
    public static ToolComponent Default => new(new Tool([], 1f, 1, true));
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(Value);
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        return new ToolComponent(Tool.Read(reader));
    }
}
