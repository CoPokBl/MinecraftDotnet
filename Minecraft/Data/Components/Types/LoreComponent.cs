using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.Components.Types;

public record LoreComponent(int ProtocolId) : IDataComponent<TextComponent[]> {
    public override Identifier Identifier => "minecraft:lore";
    
    public override DataWriter WriteData(TextComponent[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, (t, w) => w.WriteNbt(t));
    }

    public override TextComponent[] ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadPrefixedArray(r => r.ReadText());
    }
}
