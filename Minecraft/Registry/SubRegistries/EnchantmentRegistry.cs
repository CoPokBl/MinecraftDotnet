using Minecraft.Data.Enchantments;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Registry.SubRegistries;

public class EnchantmentRegistry : ProtocolTypeRegistry<EnchantmentRegistry, IEnchantment>, INbtSerialisableRegistry {
    public override Identifier RegistryId => "minecraft:enchantment";
    
    public void LoadNbt(Dictionary<string, INbtTag> entries) {
        // Clear existing entries since it would break the protocol ID mapping
        Clear();
        
        int cId = 0;
        foreach (KeyValuePair<string, INbtTag> entry in entries) {
            if (entry.Value is CompoundTag compoundTag) {
                IEnchantment enchantment = IEnchantment.FromNbt(entry.Key, cId++, compoundTag);
                Add(enchantment);
            }
        }
    }

    public Dictionary<string, INbtTag> ToNbt() {
        Dictionary<string, INbtTag> nbtDict = new();
        foreach (KeyValuePair<Identifier, IEnchantment> pair in ById) {
            nbtDict.Add(pair.Key.ToString(), pair.Value.ToNbt());
        }
        return nbtDict;
    }
}
