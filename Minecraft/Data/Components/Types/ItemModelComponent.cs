using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record ItemModelComponent(Identifier Value) : IDataComponent<Identifier> {
    public static ItemModelComponent Default => new("");
    public Identifier Identifier => "minecraft:item_model";
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(Value);
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        return new ItemModelComponent(reader.ReadString());
    }
}
