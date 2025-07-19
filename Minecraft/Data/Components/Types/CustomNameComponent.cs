using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.Components.Types;

public record CustomNameComponent(int ProtocolId) : IDataComponent<TextComponent> {
    public override Identifier Identifier => "minecraft:custom_name";
    
    public override DataWriter WriteData(TextComponent val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteNbt(val);
    }

    public override TextComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadText();
    }
}
