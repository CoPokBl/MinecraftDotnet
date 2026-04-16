using Minecraft.Data.Enchantments;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Registry.SubRegistries;

public class EnchantmentRegistry : SequentialRegistry<EnchantmentRegistry, IEnchantment>, INbtSerialisableRegistry {
    public override Identifier RegistryId => "minecraft:enchantment";
    
    public void LoadNbt(Dictionary<string, INbtTag> entries, MinecraftRegistry reg) {
        Clear();
        
        foreach (KeyValuePair<string, INbtTag> entry in entries) {
            if (entry.Value is CompoundTag compoundTag) {
                IEnchantment enchantment = IEnchantment.FromNbt(entry.Key, compoundTag, reg);
                Add(enchantment);
            }
        }
    }

    public Dictionary<string, INbtTag> ToNbt() {
        Dictionary<string, INbtTag> nbtDict = new();
        foreach (IEnchantment entry in Entries) {
            nbtDict.Add(entry.Identifier.ToString(), entry.ToNbt());
        }
        return nbtDict;
    }
}
