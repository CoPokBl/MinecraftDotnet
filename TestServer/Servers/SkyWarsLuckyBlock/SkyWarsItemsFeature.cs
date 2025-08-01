using ManagedServer;
using ManagedServer.Events;
using ManagedServer.Features;
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
        new OneUpItem(),
        new InstaboomTntItem(),
        new ExplosiveChestplateItem()
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
        
        AddEventListener<PlayerPacketReceiveEvent>(e => {
            if (e.Packet is not ServerBoundUseItemPacket && e.Packet is not ServerBoundUseItemOnPacket) {
                return;
            }
            
            Hand hand = e.Packet is ServerBoundUseItemPacket packet ? packet.UsedHand : ((ServerBoundUseItemOnPacket)e.Packet).ActiveHand;
            
            ItemStack item = hand == Hand.MainHand ? e.Player.HeldItem : e.Player.Inventory.Offhand;
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
                e.Cancelled = true;
                e.Player.HeldItem = e.Player.HeldItem.SubtractCount(1);
            }
        });
        
        AddEventListener<PlayerPlaceBlockEvent>(e => {
            string? id = e.UsedItem.GetTagOrNull(ItemTypeTag);
            
            if (id == null) {
                return;
            }
            
            SkyWarsItem? luckyItem = Items.FirstOrDefault(i => i.Id == id);
            if (luckyItem == null) {
                return;
            }
            
            // Use the lucky item
            bool consume = luckyItem.OnPlace(e.Player, e.Position);
            if (!consume) {
                e.Cancelled = true;
            }
        });
    }
    
    public static SkyWarsItem? GetItem(ItemStack stack) {
        string? id = stack.GetTagOrNull(ItemTypeTag);
        if (id == null) {
            return null;
        }
        
        return Items.FirstOrDefault(i => i.Id == id);
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
