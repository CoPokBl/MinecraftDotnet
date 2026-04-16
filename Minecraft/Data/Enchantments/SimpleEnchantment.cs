using Minecraft.Data.EnchantmentEffects;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Text;

namespace Minecraft.Data.Enchantments;

public record SimpleEnchantment(Identifier Identifier, Identifier SupportedItemsTag, 
    TextComponent Description, int Weight, int MaxLevel, EnchantmentCost MinCost, EnchantmentCost MaxCost, 
    int AnvilCost, EquipmentSlotGroup[] Slots, Identifier? ExclusiveSetTag = null, Identifier? PrimaryItemsTag = null,
    params IEnchantmentEffect[] Effects) : IEnchantment;
