using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;

namespace Minecraft.Data.Components.Types;

public record CustomDataComponent(int ProtocolId) : IDataComponent<INbtTag> {
    public override Identifier Identifier => "minecraft:custom_data";
    
    public override DataWriter WriteData(INbtTag val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteNbt(val);
    }

    public override INbtTag ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadNbt();
    }

    public override bool ValuesEqual(INbtTag val1, INbtTag val2) {
        // Slow but simple way to compare NBT tags
        return val1.ToJsonString() == val2.ToJsonString();
    }
}
