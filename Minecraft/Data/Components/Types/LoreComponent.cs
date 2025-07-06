using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.Components.Types;

public record LoreComponent(params TextComponent[] Value) : IDataComponent<TextComponent[]> {
    public static LoreComponent Default => new();
    public Identifier Identifier => "minecraft:lore";
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(Value, (t, w) => w.WriteNbt(t));
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        TextComponent[] lore = reader.ReadPrefixedArray(r => r.ReadText());
        return new LoreComponent(lore);
    }
}
