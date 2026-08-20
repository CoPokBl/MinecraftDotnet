using Minecraft.Data.Generated;
using Minecraft.Data.Inventories;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ManagedServer.Inventories;

public class TradeInventory(ManagedMinecraftServer server, Trade[] trades, MerchantLevel level, int experience, 
    bool canRestock, bool displayLevelInformation) : Inventory(server, 3, 3) {
    public override IInventoryType Type => InventoryType.Merchant;
    
    public const int InputSlot1 = 0;
    public const int InputSlot2 = 1;
    public const int OutputSlot = 2;

    /// <summary>
    /// Nothing. A shift click never moves a stack into a trade window: the input slots are filled by
    /// picking a trade, or by an ordinary click.
    /// </summary>
    public override bool AcceptsQuickMove(int slot, ItemStack item) {
        return false;
    }

    /// <summary>The output fills the player's inventory backwards; the two inputs forwards.</summary>
    public override bool QuickMoveFillsBackwards(int slot) {
        return slot == OutputSlot;
    }

    /// <summary>So a shift click from the player's side crosses their own two halves.</summary>
    public override bool QuickMoveFallsBackToPlayerSections => true;

    public Trade[] Trades { get; set; } = trades;
    public MerchantLevel Level { get; set; } = level;
    public int Experience { get; set; } = experience;
    public bool CanRestock { get; set; } = canRestock;
    public bool DisplayLevelInformation { get; set; } = displayLevelInformation;

    public override MinecraftPacket[] GenerateOpenPackets() {
        return base.GenerateOpenPackets().Append(new ClientBoundMerchantOffersPacket {
            WindowId = WindowId,
            Trades = Trades,
            VillagerLevel = Level,
            Experience = Experience,
            CanRestock = CanRestock,
            IsRegularVillager = DisplayLevelInformation
        }).ToArray();
    }
}
