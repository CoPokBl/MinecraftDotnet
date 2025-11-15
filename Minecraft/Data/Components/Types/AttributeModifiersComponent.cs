using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record AttributeModifiersComponent(int ProtocolId) : IDataComponent<ItemAttributeModifier[]> {
    public override Identifier Identifier => "minecraft:attribute_modifiers";
    
    public override DataWriter WriteData(ItemAttributeModifier[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, registry);
    }

    public override ItemAttributeModifier[] ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadPrefixedArray<ItemAttributeModifier>(registry);
    }

    public override bool ValuesEqual(ItemAttributeModifier[] val1, ItemAttributeModifier[] val2) {
        return val1.SequenceEqual(val2);
    }
}
