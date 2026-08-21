using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

public record ChargedProjectilesComponent() : IDataComponent<ItemStack[]> {
    public override Identifier Identifier => "minecraft:charged_projectiles";

    public override NbtCodec<ItemStack[]>? Codec => Persistent;
    private static readonly NbtCodec<ItemStack[]> Persistent = new(
        (val, registry) => new ListTag(val.Select(stack => (INbtTag)stack.ToNbt(registry)).ToArray()),
        (tag, registry) => tag.GetList().Tags.ToArray()
            .Select(stack => ItemStack.FromNbt(stack, registry))
            .ToArray());
    
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