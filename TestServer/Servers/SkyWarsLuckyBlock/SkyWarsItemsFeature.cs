using ManagedServer;
using ManagedServer.Events;
using ManagedServer.Viewables;
using Minecraft;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using TestServer.Servers.SkyWarsLuckyBlock.Items;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public class SkyWarsItemsFeature : ScopedFeature {
    private static readonly Tag<string> ItemTypeTag = new("skywars.item_type");
    
    public static readonly LuckyBlockItem[] Items = [
        new TestItem(),
        new KnockbackStickItem(),
        new GoldenAppleItem()
    ];
    
    public override void Register() {
        AddEventListener<PlayerConsumeItemEvent>(e => {
            string? id = e.Item.GetTagOrNull(ItemTypeTag);
            
            if (id == null) {
                return;
            }
            
            LuckyBlockItem? luckyItem = Items.FirstOrDefault(i => i.Id == id);
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
            
            LuckyBlockItem? luckyItem = Items.FirstOrDefault(i => i.Id == id);
            if (luckyItem == null) {
                return;
            }
            
            // Use the lucky item
            luckyItem.Use(e.Player);

            // ConsumableComponent.Data? food = item.Get(DataComponent.Consumable);
            // if (food != null) {  // it's an eat
            //     e.Player.SendMessage("Eating " + food.ConsumeSeconds);
            //     
            //     e.World.Server!.ScheduleTask(TimeSpan.FromSeconds(food.ConsumeSeconds), () => {
            //         luckyItem.OnEat(e.Player);
            //         e.Player.HeldItem = e.Player.HeldItem.SubtractCount(1);
            //     });
            // }
            // else {
            //     e.Player.SendMessage("Using non edible " + luckyItem.Id);
            // }
        });
    }

    public static ItemStack CreateItem(Type itemType) {
        if (!typeof(LuckyBlockItem).IsAssignableFrom(itemType)) {
            throw new ArgumentException("Item type must inherit from LuckyBlockItem", nameof(itemType));
        }

        LuckyBlockItem item = (LuckyBlockItem)Activator.CreateInstance(itemType)!;
        ItemStack stack = item.Item.WithTag(ItemTypeTag, item.Id);
        return stack;
    }
}
