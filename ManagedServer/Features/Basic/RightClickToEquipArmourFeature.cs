using ManagedServer.Events;
using ManagedServer.Inventory;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;

namespace ManagedServer.Features.Basic;

public class RightClickToEquipArmourFeature : ScopedFeature {
    
    public override void Register() {
        AddEventListener<PlayerUseItemEvent>(e => {
            if (!e.Item.Has(DataComponent.Equippable)) {
                return;
            }
            
            EquippableComponent.Slot slot = e.Item.Get(DataComponent.Equippable)!.Slot;
            int targetSlot = slot switch {
                EquippableComponent.Slot.Head => PlayerInventory.HelmetSlot,
                EquippableComponent.Slot.Chest => PlayerInventory.ChestplateSlot,
                EquippableComponent.Slot.Legs => PlayerInventory.LeggingsSlot,
                EquippableComponent.Slot.Feet => PlayerInventory.BootsSlot,
                _ => -1
            };
            if (targetSlot == -1) {
                return; // not an armour slot
            }

            ItemStack existing = e.Player.Inventory[targetSlot];
            e.Player.Inventory[targetSlot] = e.Item;
            e.Player.SetItemInHand(e.Hand, existing);
            
            e.StopsBlockPlacement = true;
        });
    }
}
