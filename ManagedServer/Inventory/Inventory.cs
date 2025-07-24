using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Types;
using ManagedServer.Viewables;
using Minecraft.Data.Inventories;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Text;

namespace ManagedServer.Inventory;

public abstract class Inventory : IViewable {
    private const int DefaultMaxStackSize = 64;
    private static readonly AtomicCounter IdCounter = new(1, sbyte.MaxValue-1);
    
    /// <summary>
    /// The amount of slots in the inventory.
    /// </summary>
    public readonly int Size;
    public readonly int PlayerInventoryStartIndex;
    
    public abstract IInventoryType Type { get; }

    public virtual int WindowId { get; } = IdCounter.Next();
    public virtual int[] AddItemSearchOrder => Enumerable.Range(0, Size).ToArray();
    
    public EventNode<IServerEvent> Events { get; }
    
    /// <summary>
    /// Items in the inventory.
    /// <p/>
    /// DO NOT MODIFY THIS ARRAY DIRECTLY.
    /// </summary>
    public readonly ItemStack[] Items;

    public TextComponent Title = "Inventory";
    
    internal readonly List<PlayerEntity> Viewers = [];
    internal int LastStateId;

    protected Inventory(ManagedMinecraftServer server, int size, int playerInventoryStartIndex) {
        Size = size;
        PlayerInventoryStartIndex = playerInventoryStartIndex;
        Items = new ItemStack[size];
        for (int i = 0; i < size; i++) {
            Items[i] = ItemStack.Air;
        }

        Events = server.Events.CreateChild(e => e is IInventoryEvent ie && ie.Inventory == this);
    }

    public ItemStack this[int index] {
        get {
            if (index < 0 || index >= Size) {
                throw new IndexOutOfRangeException($"Index {index} is out of range for inventory of size {Size}.");
            }
            return Items[index];
        }
        set {
            if (index < 0 || index >= Size) {
                throw new IndexOutOfRangeException($"Index {index} is out of range for inventory of size {Size}.");
            }
            
            InventoryChangeEvent changeEvent = new() {
                Inventory = this,
                Slot = index,
                PreviousItem = Items[index],
                NewItem = value
            };
            Events.CallEvent(changeEvent);
            
            Items[index] = value;
            SendSlotUpdate(index);
            Refresh(); // Notify that the inventory has changed
        }
    }
    
    public void Clear() {
        for (int i = 0; i < Size; i++) {
            Items[i] = ItemStack.Air;
        }

        foreach (PlayerEntity p in Viewers) {
            SendUpdateTo(p);
        }
        
        Refresh(); // Notify that the inventory has changed
    }

    protected int GetBestSlotForItem(ItemStack item) {
        // Check for a similar item first
        foreach (int i in AddItemSearchOrder) {
            if (!this[i].CanStackWith(item)) continue;
            int maxStackSize = this[i].GetMaxStackSize(DefaultMaxStackSize);
            if (this[i].Count < maxStackSize) {
                return i; // Found a slot that can stack with the item
            }
        }
        
        // If no similar item found, return the first empty slot
        foreach (int i in AddItemSearchOrder) {
            if (this[i] == ItemStack.Air) {
                return i; // Found an empty slot
            }
        }
        
        // If no empty slot found, return -1 to indicate failure
        return -1;
    }

    /// <summary>
    /// Inserts the specified item into the first empty slot in the inventory.
    /// </summary>
    /// <param name="item">The item to add.</param>
    /// <param name="allOrNothing">Whether to only make changes if the item can be fully added.</param>
    /// <returns>The remainder of the item. If <see cref="allOrNothing"/> is true then this will either be null or <see cref="item"/></returns>
    public virtual ItemStack? AddItem(ItemStack item, bool allOrNothing = false) {
        ItemStack remainingItem = item;
        Dictionary<int, ItemStack> changedItems = new();

        while (true) {
            int bestSlot = GetBestSlotForItem(remainingItem);
            if (bestSlot == -1) {
                // No suitable slot found, return the remaining item
                if (allOrNothing) {
                    // Rollback changes if we couldn't add the item completely
                    foreach ((int index, ItemStack originalItem) in changedItems) {
                        this[index] = originalItem;
                    }
                    return item; // Return the original item if we couldn't add it
                }
                return remainingItem; // Return the remaining item if we couldn't add it
            }
            
            if (this[bestSlot] == ItemStack.Air) {
                // Found an empty slot, place the item here
                this[bestSlot] = remainingItem;
                return null; // Item added successfully
            }
            
            if (!this[bestSlot].CanStackWith(remainingItem)) {
                // The item cannot stack with the existing item, continue searching
                continue;
            }
            
            int maxStackSize = this[bestSlot].GetMaxStackSize(DefaultMaxStackSize);
            int newStackCount = Math.Min(this[bestSlot].Count + remainingItem.Count, maxStackSize);
            int remainingCount = remainingItem.Count - (newStackCount - this[bestSlot].Count);
            changedItems[bestSlot] = this[bestSlot];
            this[bestSlot] = this[bestSlot].WithCount(newStackCount);
            if (remainingCount <= 0) {
                // Successfully added the item, return null to indicate no remaining item
                return null;
            }
            // Update the remaining item with the count that was not added
            remainingItem = remainingItem.WithCount(remainingCount);
        }
    }

    public void SendSlotUpdate(int slot) {
        LastStateId = Random.Shared.Next();
        this.GetAudience().SendPacket(new ClientBoundSetContainerSlotPacket {
            WindowId = WindowId,
            StateId = LastStateId,
            SlotId = (short)slot,
            Data = Items[slot]
        });
    }

    public void SendUpdateTo(PlayerEntity audience) {
        LastStateId = Random.Shared.Next();
        audience.SendPacket(new ClientBoundSetContainerContentPacket {
            CursorItem = audience.CursorItem,
            SlotData = Items,
            StateId = LastStateId,
            WindowId = WindowId
        });
    }

    public ClientBoundOpenScreenPacket GenerateOpenPacket() {
        return new ClientBoundOpenScreenPacket {
            WindowId = WindowId,
            Type = Type,
            Title = Title
        };
    }

    /// <summary>
    /// Called whenever the inventory changes.
    /// </summary>
    public virtual void Refresh() {
        
    }

    public void AddViewer(PlayerEntity player) {
        Viewers.Add(player);
        player.SendPacket(GenerateOpenPacket());
        SendUpdateTo(player);
    }

    public PlayerEntity[] GetViewers() {
        return Viewers.ToArray();
    }
}
