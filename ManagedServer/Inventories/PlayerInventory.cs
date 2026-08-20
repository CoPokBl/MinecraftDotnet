using ManagedServer.Entities.Types;
using Minecraft.Data.Generated;
using Minecraft.Data.Inventories;
using Minecraft.Schemas.Items;

namespace ManagedServer.Inventories;

public class PlayerInventory : Inventory {
    private const int InventorySize = 46;

    public override IInventoryType Type => InventoryType.Generic9x4;
    public override int WindowId => 0;
    public Player Owner;
    
    // We search the hotbar first, then the rest of the inventory. Ignoring armour and crafting slots.
    public override int[] AddItemSearchOrder => 
        Enumerable.Range(HotbarSlot1, 9)
            .Concat(Enumerable.Range(PlayerInventoryStartIndex, HotbarSlot1 - PlayerInventoryStartIndex))
            .ToArray();

    // Slot constants
    public const int RegularInventoryStartIndex = 9;
    public const int CraftingInput1Slot = 1;
    public const int CraftingInput2Slot = 2;
    public const int CraftingInput3Slot = 3;
    public const int CraftingInput4Slot = 4;
    public const int CraftingOutputSlot = 0;
    public const int HelmetSlot = 5;
    public const int ChestplateSlot = 6;
    public const int LeggingsSlot = 7;
    public const int BootsSlot = 8;
    public const int OffhandSlot = 45;
    public const int HotbarSlot1 = 36;
    public const int HotbarSlot2 = 37;
    public const int HotbarSlot3 = 38;
    public const int HotbarSlot4 = 39;
    public const int HotbarSlot5 = 40;
    public const int HotbarSlot6 = 41;
    public const int HotbarSlot7 = 42;
    public const int HotbarSlot8 = 43;
    public const int HotbarSlot9 = 44;

    /// <summary>The twenty seven main inventory slots, top left first.</summary>
    public static readonly int[] MainInventorySlots =
        Enumerable.Range(RegularInventoryStartIndex, HotbarSlot1 - RegularInventoryStartIndex).ToArray();

    /// <summary>The nine hotbar slots, left to right.</summary>
    public static readonly int[] HotbarSlots = Enumerable.Range(HotbarSlot1, 9).ToArray();

    /// <summary>
    /// Both of those, main inventory first: the thirty six slots a shift click can reach, in the
    /// order it fills them. Armour, the offhand and the two by two are not in it.
    /// </summary>
    public static readonly int[] QuickMoveSlots = [..MainInventorySlots, ..HotbarSlots];

    /// <summary>
    /// The same thirty six from the last hotbar slot backwards. <b>Everything a window hands the
    /// player arrives in this order</b>: a crafted result, a trade, a chest's stack.
    /// </summary>
    public static readonly int[] BackwardsQuickMoveSlots = QuickMoveSlots.Reverse().ToArray();

    public PlayerInventory(ManagedMinecraftServer server, Player owner) : 
        base(server, InventorySize, RegularInventoryStartIndex) {
        Viewers.Add(owner);
        Title = owner.Name + "'s Inventory";
        Owner = owner;
    }
    
    // Props for easy access
    public ItemStack Helmet {
        get => this[HelmetSlot];
        set => this[HelmetSlot] = value;
    }
    
    public ItemStack Chestplate {
        get => this[ChestplateSlot];
        set => this[ChestplateSlot] = value;
    }
    
    public ItemStack Leggings {
        get => this[LeggingsSlot];
        set => this[LeggingsSlot] = value;
    }
    
    public ItemStack Boots {
        get => this[BootsSlot];
        set => this[BootsSlot] = value;
    }
    
    public ItemStack Offhand {
        get => this[OffhandSlot];
        set => this[OffhandSlot] = value;
    }
    
    /// <summary>
    /// Sets specific hotbar item. Slot is 0 indexed, so slot 0 is the first hotbar slot.
    /// </summary>
    /// <param name="slot">Index between 1 and 8 inclusive.</param>
    /// <param name="item">The item.</param>
    /// <exception cref="ArgumentOutOfRangeException">The slot was invalid.</exception>
    public void SetHotbarItem(int slot, ItemStack item) {
        if (slot is < 0 or > 8) {
            throw new ArgumentOutOfRangeException(nameof(slot), "Hotbar slot must be between 1 and 9.");
        }
        this[HotbarSlot1 + slot] = item;
        SendSlotUpdate(HotbarSlot1 + slot);
    }
    
    /// <summary>
    /// Gets specific hotbar item. Slot is 0 indexed, so slot 0 is the first hotbar slot.
    /// </summary>
    /// <param name="slot">Index between 1 and 8 inclusive.</param>
    /// <returns>The item in the hotbar slot.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The slot was invalid.</exception>
    public ItemStack GetHotbarItem(int slot) {
        if (slot is < 0 or > 8) {
            throw new ArgumentOutOfRangeException(nameof(slot), "Hotbar slot must be between 1 and 9.");
        }
        return this[HotbarSlot1 + slot];
    }

    public override void Refresh() {
        Owner.RefreshEquipment();
    }
}
