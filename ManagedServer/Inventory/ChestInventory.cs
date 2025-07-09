using Minecraft.Data.Generated;
using Minecraft.Data.Inventories;

namespace ManagedServer.Inventory;

public class ChestInventory(IInventoryType type, int size) : Inventory(size, size) {
    public override IInventoryType Type { get; } = type;

    public static ChestInventory Create(int rows) {
        IInventoryType type = rows switch {
            1 => InventoryType.Generic9x1,
            2 => InventoryType.Generic9x2,
            3 => InventoryType.Generic9x3,
            4 => InventoryType.Generic9x4,
            5 => InventoryType.Generic9x5,
            6 => InventoryType.Generic9x6,
            _ => throw new ArgumentOutOfRangeException(nameof(rows), "Rows must be between 1 and 6 inclusive.")
        };
        return new ChestInventory(type, rows * 9);
    }
}
