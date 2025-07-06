using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.Components.Types;

public record ItemNameComponent(TextComponent Value) : IDataComponent<TextComponent> {
    public static ItemNameComponent Default => new(TextComponent.Empty());
    public Identifier Identifier => "minecraft:item_name";
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteNbt(Value);
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        return new ItemNameComponent(reader.ReadText());
    }
}
