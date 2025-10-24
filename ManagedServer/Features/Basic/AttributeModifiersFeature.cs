using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Inventories;
using Minecraft.Data.Attributes;
using Minecraft.Data.EnchantmentEffects;
using Minecraft.Data.EnchantmentEffects.Types;
using Minecraft.Data.Enchantments;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;

namespace ManagedServer.Features.Basic;

public class AttributeModifiersFeature(bool includeEnchantments) : ScopedFeature {
    private static readonly Tag<(IAttribute, Identifier)[]> ActiveItemModifiersTag = new("managedserver:basic:attributemodfeat:active_item_modifiers");

    private ItemAttributeModifier[] GetModifiers(ItemStack item) {
        if (!includeEnchantments) {
            return item.GetOrDefault(DataComponent.AttributeModifiers, []);
        }
        
        List<ItemAttributeModifier> mods = item.GetOrDefault(DataComponent.AttributeModifiers, []).ToList();

        foreach ((IEnchantment, int) ench in item.GetOrDefault(DataComponent.Enchantments, [])) {
            foreach (IEnchantmentEffect effect in ench.Item1.Effects) {
                if (effect is not AttributeEnchantmentEffect attrEff) continue;
                foreach (AttributeEnchantmentEffect.Effect attrEffEffect in attrEff.Effects) {
                    mods.Add(new ItemAttributeModifier(
                        attrEffEffect.Attribute, 
                        attrEffEffect.ModifierId, 
                        attrEffEffect.Amount.Calculate(ench.Item2), 
                        attrEffEffect.Operation, 
                        ench.Item1.Slots[0], 
                        ItemAttributeModifier.Display.HiddenMode()));
                }
            }
        }
        
        return mods.ToArray();
    }
    
    public override void Register() {
        AddEventHandler<InventoryChangeEvent>(e => {
            if (e.Inventory is not PlayerInventory inventory) {
                return;
            }
            
            UpdatePlayerAttributes(inventory.Owner);
        });
        
        AddEventHandler<PlayerSwitchHotbarSlotEvent>(e => {
            UpdatePlayerAttributes(e.Player);
        });
    }

    private static bool IsCorrectSlot(int slot, EquipmentSlotGroup group, PlayerEntity player) {
        if (group.ContainsSlot(EquipmentSlot.Body)) {
            return true;
        }
        
        if (group.ContainsSlot(EquipmentSlot.MainHand) && slot == PlayerInventory.HotbarSlot1 + player.ActiveHotbarSlot) {
            return true;
        }

        if (group.ContainsSlot(EquipmentSlot.OffHand) && slot == PlayerInventory.OffhandSlot) {
            return true;
        }
        
        if (group.ContainsSlot(EquipmentSlot.Helmet) && slot == PlayerInventory.HelmetSlot) {
            return true;
        }
        
        if (group.ContainsSlot(EquipmentSlot.Chestplate) && slot == PlayerInventory.ChestplateSlot) {
            return true;
        }
        
        if (group.ContainsSlot(EquipmentSlot.Leggings) && slot == PlayerInventory.LeggingsSlot) {
            return true;
        }
        
        if (group.ContainsSlot(EquipmentSlot.Boots) && slot == PlayerInventory.BootsSlot) {
            return true;
        }

        return false;
    }

    public void UpdatePlayerAttributes(PlayerEntity player) {
        List<(IAttribute, Identifier)> activeMods = [];

        for (int i = 0; i < player.Inventory.Items.Length; i++) {
            ItemStack item = player.Inventory.Items[i];

            ItemAttributeModifier[] mods = GetModifiers(item);
            foreach (ItemAttributeModifier modifier in mods) {
                // check for right slot
                if (!IsCorrectSlot(i, modifier.Slot, player)) {
                    continue;
                }

                // add modifier
                activeMods.Add((modifier.Attribute, modifier.Id));

                // remove existing to avoid duplicates
                player.RemoveAttributeModifier(modifier.Attribute, modifier.Id);
                player.AddAttributeModifier(modifier.Attribute, modifier.ToAttributeModifier());
            }
        }

        // Remove existing modifiers that are no longer active
        if (player.HasTag(ActiveItemModifiersTag)) {
            (IAttribute, Identifier)[] previousMods = player.GetTag(ActiveItemModifiersTag);
            foreach ((IAttribute, Identifier) mod in previousMods) {
                if (activeMods.Any(am => 
                        am.Item1.Identifier == mod.Item1.Identifier && 
                        am.Item2 == mod.Item2)) {
                    continue;
                }
                
                // Remove it
                player.RemoveAttributeModifier(mod.Item1, mod.Item2);
            }
        }
        
        // Update tag
        (IAttribute, Identifier)[] currentMods = activeMods.ToArray();
        player.SetTag(ActiveItemModifiersTag, currentMods);
    }
}