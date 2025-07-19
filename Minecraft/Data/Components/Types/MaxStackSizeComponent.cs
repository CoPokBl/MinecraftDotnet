using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record MaxStackSizeComponent(int ProtocolId) : IDataComponent<int> {
    public override Identifier Identifier => "minecraft:max_stack_size";
    
    public override DataWriter WriteData(int val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new MaxStackSizeComponent(reader.ReadVarInt());
    }
}
