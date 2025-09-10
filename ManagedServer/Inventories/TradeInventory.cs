using Minecraft.Data.Generated;
using Minecraft.Data.Inventories;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;

namespace ManagedServer.Inventories;

public class TradeInventory(ManagedMinecraftServer server, Trade[] trades, MerchantLevel level, int experience, 
    bool canRestock, bool displayLevelInformation) : Inventory(server, 3, 3) {
    public override IInventoryType Type => InventoryType.Merchant;
    
    public const int InputSlot1 = 0;
    public const int InputSlot2 = 1;
    public const int OutputSlot = 2;

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
