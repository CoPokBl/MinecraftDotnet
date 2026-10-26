using Minecraft.Data.EnchantmentEffects;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Tags;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Enchantments;

public interface IEnchantment : IProtocolType {
    HolderSet SupportedItems { get; }
    TextComponent Description { get; }
    int Weight { get; }
    int MaxLevel { get; }
    EnchantmentCost MinCost { get; }
    EnchantmentCost MaxCost { get; }
    int AnvilCost { get; }
    EquipmentSlotGroup[] Slots { get; }
    HolderSet? ExclusiveSet { get; }
    HolderSet? PrimaryItems { get; }
    IEnchantmentEffect[] Effects { get; }

    public CompoundTag ToNbt() {
        List<(string, INbtTag)> tags = [
            ("supported_items", SupportedItems.ToNbt()),
            ("description", Description.SerialiseToTag()),
            ("weight", new IntegerTag(Weight)),
            ("max_level", new IntegerTag(MaxLevel)),
            ("min_cost", MinCost.ToNbt()),
            ("max_cost", MaxCost.ToNbt()),
            ("anvil_cost", new IntegerTag(AnvilCost)),
            ("slots", new ListTag(Slots.Select(s => (INbtTag)new StringTag(s.Name)).ToArray()))
        ];
        
        if (ExclusiveSet != null) {
            tags.Add(("exclusive_set", ExclusiveSet.ToNbt()));
        }
        
        if (PrimaryItems != null) {
            tags.Add(("primary_items", PrimaryItems.ToNbt()));
        }

        if (Effects.Length > 0) {
            CompoundTag effects = new(Effects.Select(e => (e.Id, e.SerialiseData())).ToArray()!);
            tags.Add(("effects", effects));
        }
        
        return new CompoundTag(tags.ToArray());
    }

    public static IEnchantment FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        HolderSet supportedItems = HolderSet.FromNbt(tag["supported_items"]!);
        TextComponent description = TextComponent.FromTag(tag["description"]!);
        int weight = tag["weight"].AsInt();
        int maxLevel = tag["max_level"].AsInt();
        EnchantmentCost minCost = EnchantmentCost.FromNbt(tag["min_cost"].GetCompound());
        EnchantmentCost maxCost = EnchantmentCost.FromNbt(tag["max_cost"].GetCompound());
        int anvilCost = tag["anvil_cost"].AsInt();
        EquipmentSlotGroup[] slots = tag["slots"]!.AsList()
            .Select(t => EquipmentSlotGroup.FromName(t.GetString()))
            .ToArray();
        
        // An empty exclusive set is the default, which vanilla leaves off when it writes one.
        HolderSet? exclusiveSet = tag["exclusive_set"] is { } exclusive ? HolderSet.FromNbt(exclusive) : null;
        if (exclusiveSet is HolderSet.Direct { Entries.Length: 0 }) {
            exclusiveSet = null;
        }

        HolderSet? primaryItems = tag["primary_items"] is { } primary ? HolderSet.FromNbt(primary) : null;
        
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

        return new SimpleEnchantment(ident, supportedItems, description, weight, 
            maxLevel, minCost, maxCost, anvilCost, slots, exclusiveSet, primaryItems, effectList.ToArray());
    }
}
