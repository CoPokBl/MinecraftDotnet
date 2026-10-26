using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// The four sides of a decorated pot. A side with nothing on it is absent rather than a brick, though
/// a freshly crafted pot carries bricks on every side.
/// </summary>
public record PotDecorationsComponent() : IDataComponent<PotDecorationsComponent.Data> {
    public override Identifier Identifier => "minecraft:pot_decorations";

    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, registry) => new CompoundBuilder()
            .Maybe("back", val.Back, stack => stack.ToNbt(registry))
            .Maybe("left", val.Left, stack => stack.ToNbt(registry))
            .Maybe("right", val.Right, stack => stack.ToNbt(registry))
            .Maybe("front", val.Front, stack => stack.ToNbt(registry))
            .Build(),
        (tag, registry) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:pot_decorations");
            Data data = new(
                Side(node.Optional("back"), registry),
                Side(node.Optional("left"), registry),
                Side(node.Optional("right"), registry),
                Side(node.Optional("front"), registry));
            node.AssertRead();
            return data;
        });

    /// <summary><c>ItemStackTemplate.CODEC</c>, which also takes a bare item name for a stack of one.</summary>
    private static ItemStack? Side(INbtTag? tag, MinecraftRegistry registry) {
        return tag switch {
            null => null,
            StringTag name => new ItemStack(registry.Items[(Identifier)name.GetString()]),
            _ => ItemStack.FromNbt(tag, registry)
        };
    }

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        foreach (ItemStack? side in (ItemStack?[])[val.Back, val.Left, val.Right, val.Front]) {
            writer.WritePrefixedOptional(side, (stack, w) => stack.WriteTemplateData(w, registry));
        }

        return writer;
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(
            reader.ReadPrefixedOptional(r => ItemStack.ReadTemplateData(r, registry)),
            reader.ReadPrefixedOptional(r => ItemStack.ReadTemplateData(r, registry)),
            reader.ReadPrefixedOptional(r => ItemStack.ReadTemplateData(r, registry)),
            reader.ReadPrefixedOptional(r => ItemStack.ReadTemplateData(r, registry)));
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return Equals(val1.Back, val2.Back) && Equals(val1.Left, val2.Left)
            && Equals(val1.Right, val2.Right) && Equals(val1.Front, val2.Front);
    }

    public record Data(ItemStack? Back, ItemStack? Left, ItemStack? Right, ItemStack? Front);
}
