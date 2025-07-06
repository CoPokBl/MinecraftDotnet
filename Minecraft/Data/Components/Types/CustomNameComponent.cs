using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.Components.Types;

public record CustomNameComponent(TextComponent Value) : IDataComponent<TextComponent> {
    public static CustomNameComponent Default => new(TextComponent.Empty());
    public Identifier Identifier => "minecraft:custom_name";
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteNbt(Value);
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        return new CustomNameComponent(reader.ReadText());
    }
}
