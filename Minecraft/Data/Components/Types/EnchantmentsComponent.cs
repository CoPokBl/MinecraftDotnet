using Minecraft.Data.Enchantments;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record EnchantmentsComponent(int ProtocolId) : IDataComponent<(IEnchantment, int)[]> {
    public override Identifier Identifier => "minecraft:enchantments";

    public override DataWriter WriteData((IEnchantment, int)[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, (tuple, w) => w
            .WriteVarInt(tuple.Item1.ProtocolId)
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
            if (val1[i].Item1.ProtocolId != val2[i].Item1.ProtocolId || val1[i].Item2 != val2[i].Item2) {
                return false;
            }
        }
        return true;
    }
}
