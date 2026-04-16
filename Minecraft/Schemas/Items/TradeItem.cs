using Minecraft.Data;
using Minecraft.Data.Components;
using Minecraft.Registry;

namespace Minecraft.Schemas.Items;

public record TradeItem(ItemStack Item) : INetworkType<TradeItem> {
    public static implicit operator TradeItem(ItemStack item) => new(item);
    public static implicit operator ItemStack(TradeItem tradeItem) => tradeItem.Item;
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt(registry.Items.GetProtocolId(Item.Type))
            .WriteVarInt(Item.Count)
            .WritePrefixedArray(Item.Components.ToArray(), (comp, wr) => {
                wr.WriteVarInt(registry.DataComponents.GetProtocolId(comp.Key));
                comp.Key.WriteData(comp.Value, writer, registry);
            });
    }

    public static TradeItem ReadData(DataReader reader, MinecraftRegistry registry) {
        int itemId = reader.ReadVarInt();
        int count = reader.ReadVarInt();

        KeyValuePair<IDataComponent, object>[] components = reader.ReadPrefixedArray(r => {
            IDataComponent comp = registry.DataComponents[r.ReadVarInt()];
            object value = comp.ReadData(r, registry);
            return new KeyValuePair<IDataComponent, object>(comp, value);
        });

        return new TradeItem(new ItemStack(
            registry.Items[itemId], 
            count, 
            new Dictionary<IDataComponent, object>(components)));
    }
}
