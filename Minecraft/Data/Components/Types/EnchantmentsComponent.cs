using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record EnchantmentsComponent(params (int, int)[] Value) : IDataComponent<(int, int)[]> {
    public static EnchantmentsComponent Default => new();
    public Identifier Identifier => "minecraft:enchantments";

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(Value, (tuple, w) => w
            .WriteVarInt(tuple.Item1)
            .WriteVarInt(tuple.Item2));
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        (int, int)[] enchantments = reader.ReadPrefixedArray(r => 
            (r.ReadVarInt(), r.ReadVarInt()));
        return new EnchantmentsComponent(enchantments);
    }
}
