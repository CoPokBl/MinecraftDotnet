using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.Components.Types;

public record DyedColorComponent(int ProtocolId) : IDataComponent<TextColor> {
    public override Identifier Identifier => "minecraft:dyed_color";
    public override DataWriter WriteData(TextColor val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteInteger(val.ToDecimal());
    }
    
    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return TextColor.FromDecimal(reader.ReadInteger());
    }

    public override bool ValuesEqual(TextColor val1, TextColor val2) {
        return val1 == val2;
    }
}
