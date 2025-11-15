using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;
using NBT;

namespace Minecraft.Data.Components.Types;

public record CustomNameComponent(int ProtocolId) : IDataComponent<TextComponent> {
    public override Identifier Identifier => "minecraft:custom_name";
    
    public override DataWriter WriteData(TextComponent val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteNbt(val);
    }

    public override TextComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadText();
    }

    public override bool ValuesEqual(TextComponent val1, TextComponent val2) {
        return val1.ToJsonString() == val2.ToJsonString();
    }
}
