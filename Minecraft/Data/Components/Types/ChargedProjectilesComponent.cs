using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Components.Types;

public record ChargedProjectilesComponent() : IDataComponent<ItemStack[]> {
    public override Identifier Identifier => "minecraft:charged_projectiles";
    
    public override DataWriter WriteData(ItemStack[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, registry);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadPrefixedArray<ItemStack>(registry);
    }

    public override bool ValuesEqual(ItemStack[] val1, ItemStack[] val2) {
        return val1.SequenceEqual(val2);
    }
}