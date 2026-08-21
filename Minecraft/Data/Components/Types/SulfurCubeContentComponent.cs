using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using NBT;

namespace Minecraft.Data.Components.Types;

/// <summary>The block item a sulfur cube has swallowed.</summary>
public record SulfurCubeContentComponent() : IDataComponent<ItemStack> {
    public override Identifier Identifier => "minecraft:sulfur_cube_content";

    public override NbtCodec<ItemStack>? Codec => Persistent;
    private static readonly NbtCodec<ItemStack> Persistent = new(
        (val, registry) => val.ToNbt(registry),
        ItemStack.FromNbt);

    public override DataWriter WriteData(ItemStack val, DataWriter writer, MinecraftRegistry registry) {
        return val.WriteTemplateData(writer, registry);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return ItemStack.ReadTemplateData(reader, registry);
    }

    public override bool ValuesEqual(ItemStack val1, ItemStack val2) {
        return val1.Equals(val2);
    }
}
