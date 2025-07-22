using ManagedServer;
using ManagedServer.Events;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using TestServer.Servers.SkyWarsLuckyBlock.Items;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public class SkyWarsItemsFeature : ScopedFeature {
    private static readonly Tag<string> ItemTypeTag = new("skywars.item_type");
    
    public static readonly SkyWarsItem[] Items = [
        new TestItem(),
        new KnockbackStickItem(),
        new GoldenAppleItem(),
        new MagicToyStickItem(),
        new TeleportOrbItem(),
        new OneUpItem()
    ];
    
    public override void Register() {
        AddEventListener<PlayerConsumeItemEvent>(e => {
            string? id = e.Item.GetTagOrNull(ItemTypeTag);
            
            if (id == null) {
                return;
            }
            
            SkyWarsItem? luckyItem = Items.FirstOrDefault(i => i.Id == id);
            if (luckyItem == null) {
                return;
            }
            
            luckyItem.OnEat(e.Player);
        });
        
        AddEventListener<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundUseItemPacket packet) {
                return;
            }
            
            ItemStack item = packet.UsedHand == Hand.MainHand ? e.Player.HeldItem : e.Player.Inventory.Offhand;
            string? id = item.GetTagOrNull(ItemTypeTag);
            
            if (id == null) {
                return;
            }
            
            SkyWarsItem? luckyItem = Items.FirstOrDefault(i => i.Id == id);
            if (luckyItem == null) {
                return;
            }
            
            // Use the lucky item
            bool consume = luckyItem.Use(e.Player);
            if (consume) {
                e.Player.HeldItem = e.Player.HeldItem.SubtractCount(1);
            }
        });
    }

    public static ItemStack CreateItem(Type itemType) {
        if (!typeof(SkyWarsItem).IsAssignableFrom(itemType)) {
            throw new ArgumentException("Item type must inherit from LuckyBlockItem", nameof(itemType));
        }

        SkyWarsItem item = (SkyWarsItem)Activator.CreateInstance(itemType)!;
        ItemStack stack = item.Item.WithTag(ItemTypeTag, item.Id);
        return stack;
    }
}
