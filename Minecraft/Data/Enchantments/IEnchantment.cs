using Minecraft.Data.EnchantmentEffects;
using Minecraft.Registry;
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
    IEnchantmentEffect[] Effects { get; }

    public CompoundTag ToNbt() {
        List<(string, INbtTag)> tags = [
            ("supported_items", new StringTag($"#{SupportedItemsTag}")),
            ("description", Description.SerialiseToTag()),
            ("weight", new IntegerTag(Weight)),
            ("max_level", new IntegerTag(MaxLevel)),
            ("min_cost", MinCost.ToNbt()),
            ("max_cost", MaxCost.ToNbt()),
            ("anvil_cost", new IntegerTag(AnvilCost)),
            ("slots", new ListTag(Slots.Select(s => (INbtTag)new StringTag(s.Name)).ToArray()))
        ];
        
        if (ExclusiveSetTag != null) {
            tags.Add(("exclusive_set", new StringTag($"#{ExclusiveSetTag}")));
        }
        
        if (PrimaryItemsTag != null) {
            tags.Add(("primary_items", new StringTag($"#{PrimaryItemsTag}")));
        }

        if (Effects.Length > 0) {
            CompoundTag effects = new(Effects.Select(e => (e.Id, e.SerialiseData())).ToArray()!);
            tags.Add(("effects", effects));
        }
        
        return new CompoundTag(tags.ToArray());
    }

    public static IEnchantment FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        string supportedItemsStr = tag["supported_items"].GetString();
        TextComponent description = TextComponent.FromTag(tag["description"]!);
        int weight = tag["weight"].GetInteger();
        int maxLevel = tag["max_level"].GetInteger();
        EnchantmentCost minCost = EnchantmentCost.FromNbt(tag["min_cost"].GetCompound());
        EnchantmentCost maxCost = EnchantmentCost.FromNbt(tag["max_cost"].GetCompound());
        int anvilCost = tag["anvil_cost"].GetInteger();
        ListTag slotsTag = tag["slots"].GetList();
        EquipmentSlotGroup[] slots = slotsTag.Tags
            .ToArray()
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
        
        List<IEnchantmentEffect> effectList = [];
        if (tag.Contains("effects")) {
            CompoundTag effects = tag["effects"].GetCompound();
            foreach ((string id, INbtTag child) in effects.Children) {
                try {
                    effectList.Add(IEnchantmentEffect.FromNbt(id, child, reg));
                }
                catch (ArgumentOutOfRangeException) {
                    // Just ignore for now
                }
            }
        }

        return new SimpleEnchantment(ident, supportedItemsStr[1..], description, weight, 
            maxLevel, minCost, maxCost, anvilCost, slots, exclusiveSet, primaryItems, effectList.ToArray());
    }
}
