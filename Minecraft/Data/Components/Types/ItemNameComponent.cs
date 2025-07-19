using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.Components.Types;

public record ItemNameComponent(int ProtocolId) : IDataComponent<TextComponent> {
    public override Identifier Identifier => "minecraft:item_name";
    
    public override DataWriter WriteData(TextComponent val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteNbt(val);
    }

    public override TextComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadText();
    }
}
