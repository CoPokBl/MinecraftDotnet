using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record AttributeModifiersComponent(params ItemAttributeModifier[] Value) : IDataComponent<ItemAttributeModifier[]> {
    public Identifier Identifier => "minecraft:attribute_modifiers";
    public static AttributeModifiersComponent Default => new();
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(Value, (modifier, w) => w.Write(wr => modifier.WriteData(wr, registry)));
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        ItemAttributeModifier[] modifiers = reader.ReadPrefixedArray(r => ItemAttributeModifier.ReadData(r, registry));
        return new AttributeModifiersComponent(modifiers);
    }
}
