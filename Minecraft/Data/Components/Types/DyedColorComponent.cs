using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

public record DyedColorComponent() : IDataComponent<TextColor> {
    public override Identifier Identifier => "minecraft:dyed_color";

    public override NbtCodec<TextColor>? Codec => Persistent;
    private static readonly NbtCodec<TextColor> Persistent = new(
        (val, _) => new IntegerTag(val.ToDecimal()),
        // TextColor has no alpha, which the vector form sets.
        (tag, _) => TextColor.FromDecimal(PackedColor.RgbFromNbt(tag) & 0xFFFFFF));
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
