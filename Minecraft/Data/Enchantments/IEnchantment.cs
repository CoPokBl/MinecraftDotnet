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

        if (Effects.Length > 0) {
            CompoundTag effects = new("effects", Effects
                .Select(e => e.SerialiseData().WithName(e.Id)).ToArray());
            tags.Add(effects);
        }
        
        return new CompoundTag(null, tags.ToArray());
    }

    public static IEnchantment FromNbt(Identifier ident, int protocolId, CompoundTag tag, MinecraftRegistry reg) {
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
        
        List<IEnchantmentEffect> effectList = [];
        if (tag.Contains("effects")) {
            CompoundTag effects = tag["effects"].GetCompound();
            foreach (INbtTag? child in effects.Children) {
                // each child is a map entry that represents an effect type
                if (child == null) {
                    throw new ArgumentException("Effect entry cannot be null");
                }
                string id = child.GetName().ThrowIfNull();
                
                try {
                    effectList.Add(IEnchantmentEffect.FromNbt(id, child, reg));
                }
                catch (ArgumentOutOfRangeException) {
                    // Just ignore for now
                }
            }
        }

        return new SimpleEnchantment(ident, protocolId, supportedItemsStr[1..], description, weight, 
            maxLevel, minCost, maxCost, anvilCost, slots, exclusiveSet, primaryItems, effectList.ToArray());
    }
}
