using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Enchantments;

public interface IEnchantment : IProtocolType {
    Identifier SupportedItemsTag { get; }
    TextComponent Description { get; }
    int Weight { get; }
    int MaxLevel { get; }
    EnchantmentCost MinCost { get; }
    EnchantmentCost MaxCost { get; }
    int AnvilCost { get; }
    EquipmentSlotGroup[] Slots { get; }
    Identifier? ExclusiveSetTag { get; }
    Identifier? PrimaryItemsTag { get; }
    // TODO: Effects component, check Minestom

    public CompoundTag ToNbt() {
        List<INbtTag> tags = [
            new StringTag("supported_items", $"#{SupportedItemsTag}"),
            Description.SerialiseToTag().WithName("description"),
            new IntegerTag("weight", Weight),
            new IntegerTag("max_level", MaxLevel),
            MinCost.ToNbt("min_cost"),
            MaxCost.ToNbt("max_cost"),
            new IntegerTag("anvil_cost", AnvilCost),
            new ListTag("slots", Slots
                .Select(s => new StringTag(null, s.Name))
                .ToArray<INbtTag>())
        ];
        
        if (ExclusiveSetTag != null) {
            tags.Add(new StringTag("exclusive_set", $"#{ExclusiveSetTag}"));
        }
        
        if (PrimaryItemsTag != null) {
            tags.Add(new StringTag("primary_items", $"#{PrimaryItemsTag}"));
        }
        
        return new CompoundTag(null, tags.ToArray());
    }

    public static IEnchantment FromNbt(Identifier ident, int protocolId, CompoundTag tag) {
        string supportedItemsStr = tag["supported_items"].GetString();
        TextComponent description = TextComponent.FromTag(tag["description"]!);
        int weight = tag["weight"].GetInteger();
        int maxLevel = tag["max_level"].GetInteger();
        EnchantmentCost minCost = EnchantmentCost.FromNbt(tag["min_cost"].GetCompound());
        EnchantmentCost maxCost = EnchantmentCost.FromNbt(tag["max_cost"].GetCompound());
        int anvilCost = tag["anvil_cost"].GetInteger();
        ListTag slotsTag = tag["slots"].GetList();
        EquipmentSlotGroup[] slots = slotsTag.Tags
            .OfType<StringTag>()
            .Select(t => EquipmentSlotGroup.FromName(t.GetString()))
            .ToArray();
        
        Identifier? exclusiveSet = null;
        if (tag.Contains("exclusive_set")) {
            string str = tag["exclusive_set"].GetString();
            exclusiveSet = str[1..];
        }
        
        Identifier? primaryItems = null;
        if (tag.Contains("primary_items")) {
            string str = tag["primary_items"].GetString();
            primaryItems = str[1..];
        }

        return new SimpleEnchantment(ident, protocolId, supportedItemsStr[1..], description, weight, 
            maxLevel, minCost, maxCost, anvilCost, slots, exclusiveSet, primaryItems);
    }
}
