using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Text;

namespace Minecraft.Data.Enchantments;

public record SimpleEnchantment(Identifier Identifier, int ProtocolId, Identifier SupportedItemsTag, 
    TextComponent Description, int Weight, int MaxLevel, EnchantmentCost MinCost, EnchantmentCost MaxCost, 
    int AnvilCost, EquipmentSlotGroup[] Slots, Identifier? ExclusiveSetTag = null, Identifier? PrimaryItemsTag = null) : IEnchantment;
