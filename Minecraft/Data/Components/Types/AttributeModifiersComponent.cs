using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record AttributeModifiersComponent(int ProtocolId) : IDataComponent<ItemAttributeModifier[]> {
    public override Identifier Identifier => "minecraft:attribute_modifiers";
    
    public override DataWriter WriteData(ItemAttributeModifier[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, (modifier, w) => w.Write(wr => modifier.WriteData(wr, registry)));
    }

    public override ItemAttributeModifier[] ReadData(DataReader reader, MinecraftRegistry registry) {
        ItemAttributeModifier[] modifiers = reader.ReadPrefixedArray<ItemAttributeModifier>(registry);
        return modifiers;
    }
}
