using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record ItemModelComponent(int ProtocolId) : IDataComponent<Identifier> {
    public override Identifier Identifier => "minecraft:item_model";
    
    public override DataWriter WriteData(Identifier val, DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(val);
    }

    public override string ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadString();
    }
}
