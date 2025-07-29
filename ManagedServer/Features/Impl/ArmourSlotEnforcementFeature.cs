using ManagedServer.Events;
using ManagedServer.Inventory;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;

namespace ManagedServer.Features.Impl;

/// <summary>
/// Enforces that only items that have the <see cref="Minecraft.Data.Components.Types.EquippableComponent"/> component
/// can be equipped in the armour slots of a player's inventory. And that the item type matches the slot type.
/// </summary>
/// <param name="includeVanillaItems">
/// Whether to allow vanilla armour items that don't have the <see cref="Minecraft.Data.Components.Types.EquippableComponent"/>
/// component to be equipped in their respective armour slots.
/// </param>
public class ArmourSlotEnforcementFeature(bool includeVanillaItems = true) : ScopedFeature {
    private static readonly int[] ArmourSlots = [
        PlayerInventory.HelmetSlot,
        PlayerInventory.ChestplateSlot,
        PlayerInventory.LeggingsSlot,
        PlayerInventory.BootsSlot
    ];
    
    public override void Register() {
        AddEventListener<InventoryClickEvent>(e => {
            if (e.Inventory is not PlayerInventory) {
                return;
            }
            
            if (!ArmourSlots.Contains(e.Slot)) {
                return;
            }
            
            if (e.CursorItem.IsAir()) {
                // they're not trying to equip anything, so we don't need to cancel the event
                return;
            }
            
            EquippableComponent.Slot? slot = e.CursorItem.Get(DataComponent.Equippable)?.Slot;
            bool validHelmet = slot == EquippableComponent.Slot.Head || (includeVanillaItems && VanillaTags.ItemHeadArmor.Contains(e.CursorItem.Type.Identifier));
            bool validChestplate = slot == EquippableComponent.Slot.Chest || (includeVanillaItems && VanillaTags.ItemChestArmor.Contains(e.CursorItem.Type.Identifier));
            bool validLeggings = slot == EquippableComponent.Slot.Legs || (includeVanillaItems && VanillaTags.ItemLegArmor.Contains(e.CursorItem.Type.Identifier));
            bool validBoots = slot == EquippableComponent.Slot.Feet || (includeVanillaItems && VanillaTags.ItemFootArmor.Contains(e.CursorItem.Type.Identifier));

            switch (e.Slot) {
                case PlayerInventory.HelmetSlot:
                    if (!validHelmet) {
                        e.Cancelled = true;
                    }
                    break;
                
                case PlayerInventory.ChestplateSlot:
                    if (!validChestplate) {
                        e.Cancelled = true;
                    }
                    break;
                
                case PlayerInventory.LeggingsSlot:
                    if (!validLeggings) {
                        e.Cancelled = true;
                    }
                    break;
                
                case PlayerInventory.BootsSlot:
                    if (!validBoots) {
                        e.Cancelled = true;
                    }
                    break;
            }
        });
    }
}
