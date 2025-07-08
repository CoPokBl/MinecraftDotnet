using ManagedServer.Entities.Types;
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
    private static readonly AtomicCounter IdCounter = new(1, sbyte.MaxValue-1);
    
    /// <summary>
    /// The amount of slots in the inventory.
    /// </summary>
    public readonly int Size;
    
    public abstract IInventoryType Type { get; }

    public virtual int WindowId { get; } = IdCounter.Next();
    
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

    protected Inventory(int size) {
        Size = size;
        Items = new ItemStack[size];
        for (int i = 0; i < size; i++) {
            Items[i] = ItemStack.Air;
        }

        Events = new EventNode<IServerEvent>();
    }

    public ItemStack this[int index] {
        get => Items[index];
        set {
            if (index < 0 || index >= Size) {
                throw new IndexOutOfRangeException($"Index {index} is out of range for inventory of size {Size}.");
            }
            Items[index] = value;
            SendSlotUpdate(index);
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

    public void SendUpdateTo(IAudience audience) {
        LastStateId = Random.Shared.Next();
        audience.SendPacket(new ClientBoundSetContainerContentPacket {
            CursorItem = ItemStack.Air,
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

    public PlayerEntity[] GetViewers() {
        return Viewers.ToArray();
    }
}
