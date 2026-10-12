using Minecraft.Data.EnchantmentEffects;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Tags;
using Minecraft.Text;

namespace Minecraft.Data.Enchantments;

public record SimpleEnchantment(Identifier Identifier, HolderSet SupportedItems, 
    TextComponent Description, int Weight, int MaxLevel, EnchantmentCost MinCost, EnchantmentCost MaxCost, 
    int AnvilCost, EquipmentSlotGroup[] Slots, HolderSet? ExclusiveSet = null, HolderSet? PrimaryItems = null,
    params IEnchantmentEffect[] Effects) : IEnchantment;
