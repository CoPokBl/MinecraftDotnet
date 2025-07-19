using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record UnbreakableComponent(int ProtocolId) : IDataComponent<None> {
    public static None Value => None.Value;
    public override Identifier Identifier => "minecraft:unbreakable";
    
    public override DataWriter WriteData(None _, DataWriter writer, MinecraftRegistry registry) {
        return writer;
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return Value;
    }
}
