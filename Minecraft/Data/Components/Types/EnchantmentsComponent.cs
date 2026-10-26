using Minecraft.Data.Components.Codecs;
using Minecraft.Data.Enchantments;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

public record EnchantmentsComponent() : IDataComponent<(IEnchantment, int)[]> {
    public override Identifier Identifier => "minecraft:enchantments";

    /// <summary>
    /// An object of level by enchantment name, not a list of pairs as the wire form is.
    /// </summary>
    public override NbtCodec<(IEnchantment, int)[]>? Codec => Persistent;
    private static readonly NbtCodec<(IEnchantment, int)[]> Persistent = new(
        (val, _) => new CompoundTag(val
            .Select(pair => (pair.Item1.Identifier.ToString(), (INbtTag)new IntegerTag(pair.Item2)))
            .ToArray()),
        (tag, registry) => tag.GetCompound().Children
            .Select(pair => (registry.Enchantments[(Identifier)pair.key], pair.child.AsInt()))
            .ToArray());

    public override DataWriter WriteData((IEnchantment, int)[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, (tuple, w) => w
            .WriteVarInt(registry.Enchantments.GetProtocolId(tuple.Item1))
            .WriteVarInt(tuple.Item2));
    }

    public override (IEnchantment, int)[] ReadData(DataReader reader, MinecraftRegistry registry) {
        (IEnchantment, int)[] enchantments = reader.ReadPrefixedArray(r => 
            (registry.Enchantments[r.ReadVarInt()], r.ReadVarInt()));
        return enchantments;
    }

    public override bool ValuesEqual((IEnchantment, int)[] val1, (IEnchantment, int)[] val2) {
        if (val1.Length != val2.Length) return false;
        for (int i = 0; i < val1.Length; i++) {
            if (val1[i].Item1.Identifier != val2[i].Item1.Identifier || val1[i].Item2 != val2[i].Item2) {
                return false;
            }
        }
        return true;
    }
}
