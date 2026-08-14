using ManagedServer.Events;
using ManagedServer.Inventories;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;

namespace ManagedServer.Features.Basic;

public class RightClickToEquipArmourFeature : ScopedFeature {
    
    public override void Register() {
        AddEventHandler<PlayerUseItemEvent>(e => {
            if (!e.Item.Has(DataComponent.Equippable)) {
                return;
            }
            
            EquippableComponent.Slot slot = e.Item.GetOrNull(DataComponent.Equippable)!.Slot;
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

            // Nothing has to suppress block placement here, though it looks like it should. This is
            // ItemStack.use, which only ever runs for a click that hit no block: the client sends
            // use_item_on first and only falls through to use_item when that did not consume the
            // click. Armour has no corresponding block, so the placement stage passes anyway. A
            // carved pumpkin, the one item that is both placeable and equippable, therefore places
            // rather than equips, which is also what vanilla does.
        });
    }
}
