using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Components.Types;

public record ToolComponent(int ProtocolId) : IDataComponent<Tool> {
    public override Identifier Identifier => "minecraft:tool";
    
    public override DataWriter WriteData(Tool val, DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(val);
    }

    public override Tool ReadData(DataReader reader, MinecraftRegistry registry) {
        return Tool.Read(reader);
    }
}
