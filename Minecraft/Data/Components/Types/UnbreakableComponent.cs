using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record UnbreakableComponent : IDataComponent<None> {
    public None Value => None.Value;
    public static UnbreakableComponent Default => new();
    public Identifier Identifier => "minecraft:unbreakable";
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer;
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        return this;
    }
}
