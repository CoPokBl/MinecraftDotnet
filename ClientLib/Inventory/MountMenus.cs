using ClientLib.Entities;
using ClientLib.Player;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Text;

namespace ClientLib.Inventory;

/// <summary>
/// <c>ArmorSlot</c> as a mount's menu builds it over the mount's own equipment: one item, one that
/// equips there on this mount, shown only when <see cref="Active"/>, vanilla's <c>isActive</c>.
/// </summary>
public sealed class MountEquipmentSlot(Container container, int x, int y, bool active, Func<Stack, bool> mayEquip)
    : Slot(container, 0, x, y) {
    public bool Active { get; } = active;

    public override int MaxStackSize => 1;

    public override bool MayPlace(Stack stack) => mayEquip(stack);
}

/// <summary>
/// <c>AbstractMountInventoryMenu</c> with the slots of <c>HorseInventoryMenu</c> or
/// <c>NautilusInventoryMenu</c>: saddle, body armour, the chest columns a donkey, mule or llama carries,
/// then the player's inventory.
/// </summary>
public sealed class MountInventoryMenu : ContainerMenu {
    public int InventoryColumns { get; }

    /// <summary>Whether this is <c>NautilusInventoryMenu</c> rather than <c>HorseInventoryMenu</c>.</summary>
    public bool Nautilus { get; }

    /// <summary>The entity whose inventory this is, which the screen draws.</summary>
    public ClientEntity? Mount { get; init; }

    public MountEquipmentSlot SaddleSlot { get; }
    public MountEquipmentSlot ArmorSlot { get; }
    private readonly int _mountContainerSize;

    public MountInventoryMenu(int windowId, TextComponent title, PlayerInventory inventory, MenuData data, int inventoryColumns, bool nautilus,
        bool saddleActive, bool armorActive, Func<Stack, EquippableComponent.Slot, bool> mayEquip)
        : base(windowId, null, title, data) {
        InventoryColumns = inventoryColumns;
        Nautilus = nautilus;
        SaddleSlot = (MountEquipmentSlot)AddSlot(new MountEquipmentSlot(new SimpleContainer(1), 8, 18, saddleActive,
            stack => mayEquip(stack, EquippableComponent.Slot.Saddle)));
        ArmorSlot = (MountEquipmentSlot)AddSlot(new MountEquipmentSlot(new SimpleContainer(1), 8, 36, armorActive,
            stack => mayEquip(stack, EquippableComponent.Slot.Body)));
        _mountContainerSize = inventoryColumns * 3;
        if (inventoryColumns > 0) {
            AddSlotGrid(new SimpleContainer(_mountContainerSize), inventoryColumns, 3, 80, 18);
        }
        AddStandardInventorySlots(inventory, 8, 84);
    }

    protected override bool QuickMoveTakes => false;

    /// <summary><c>AbstractMountInventoryMenu.quickMoveStack</c>.</summary>
    protected override bool QuickMove(int slotIndex, Stack stack) {
        int playerContainerStart = 2 + _mountContainerSize;
        if (slotIndex < playerContainerStart) {
            return MoveItemStackTo(stack, playerContainerStart, Slots.Count, true);
        }
        if (Slots[1].MayPlace(stack) && !Slots[1].HasItem) {
            return MoveItemStackTo(stack, 1, 2, false);
        }
        if (Slots[0].MayPlace(stack) && !Slots[0].HasItem) {
            return MoveItemStackTo(stack, 0, 1, false);
        }
        if (_mountContainerSize != 0 && MoveItemStackTo(stack, 2, playerContainerStart, false)) {
            return true;
        }
        // Vanilla reports nothing moved here whether or not the stack moved.
        MoveWithinInventory(stack, slotIndex, playerContainerStart);
        return false;
    }
}
