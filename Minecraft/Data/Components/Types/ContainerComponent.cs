using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// What a shulker box or other container item is holding, by slot. The array runs to the last
/// occupied slot only, and an empty slot inside it is <see cref="ItemStack.Air"/>.
/// </summary>
public record ContainerComponent() : IDataComponent<ItemStack[]> {
    public override Identifier Identifier => "minecraft:container";

    public override NbtCodec<ItemStack[]>? Codec => Persistent;
    private static readonly NbtCodec<ItemStack[]> Persistent = new(
        (val, registry) => new ListTag(val.Select(stack => (INbtTag)stack.ToNbt(registry)).ToArray()),
        (tag, registry) => tag.AsList()
            .Select(stack => ItemStack.FromNbt(stack, registry))
            .ToArray());

    public override DataWriter WriteData(ItemStack[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, (stack, w) => w.WritePrefixedOptional(
            stack.IsAir() ? null : stack, (s, wr) => s.WriteTemplateData(wr, registry)));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadPrefixedArray(r =>
            r.ReadPrefixedOptional(re => ItemStack.ReadTemplateData(re, registry)) ?? ItemStack.Air);
    }

    public override bool ValuesEqual(ItemStack[] val1, ItemStack[] val2) {
        return val1.SequenceEqual(val2);
    }
}
