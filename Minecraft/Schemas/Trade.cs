using Minecraft.Data;
using Minecraft.Registry;
using Minecraft.Schemas.Items;

namespace Minecraft.Schemas;

public record Trade(
    TradeItem InputItem1,
    ItemStack OutputItem,
    TradeItem? InputItem2,
    bool TradeDisabled,
    int TradeUses,
    int MaxTradeUses,
    int Xp,
    int SpecialPrice,
    float PriceMultiplier,
    int Demand) : INetworkType<Trade> {
        
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .Write(InputItem1, registry)
            .Write(OutputItem, registry)
            .WritePrefixedOptional(InputItem2, registry)
            .WriteBoolean(TradeDisabled)
            .WriteInteger(TradeUses)
            .WriteInteger(MaxTradeUses)
            .WriteInteger(Xp)
            .WriteInteger(SpecialPrice)
            .WriteFloat(PriceMultiplier)
            .WriteInteger(Demand);
    }

    public static Trade ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Trade(
            reader.Read<TradeItem>(registry),
            reader.Read<ItemStack>(registry),
            reader.ReadPrefixedOptional<TradeItem>(registry),
            reader.ReadBoolean(),
            reader.ReadInteger(),
            reader.ReadInteger(),
            reader.ReadInteger(),
            reader.ReadInteger(),
            reader.ReadFloat(),
            reader.ReadInteger());
    }
}
