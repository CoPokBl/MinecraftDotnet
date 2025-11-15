using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Components.Types;

public record UseRemainderComponent(int ProtocolId) : IDataComponent<ItemStack> {
    public override Identifier Identifier => "minecraft:use_remainder";
    
    public override DataWriter WriteData(ItemStack val, DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(val, registry);
    }
    
    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.Read<ItemStack>(registry);
    }

    public override bool ValuesEqual(ItemStack val1, ItemStack val2) {
        return val1.CanStackWith(val2);
    }
}
