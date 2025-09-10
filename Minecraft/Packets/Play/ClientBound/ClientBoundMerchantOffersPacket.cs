using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundMerchantOffersPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:merchant_offers";
    
    public required int WindowId { get; init; }
    public required Trade[] Trades { get; init; }
    public required MerchantLevel VillagerLevel { get; init; }
    public required int Experience { get; init; }
    public required bool IsRegularVillager { get; init; }
    public required bool CanRestock { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry registry) {
        return w
            .WriteVarInt(WindowId)
            .WritePrefixedArray(Trades, registry)
            .WriteVarInt((int)VillagerLevel)
            .WriteVarInt(Experience)
            .WriteBoolean(IsRegularVillager)
            .WriteBoolean(CanRestock);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundMerchantOffersPacket {
        WindowId = r.ReadVarInt(),
        Trades = r.ReadPrefixedArray<Trade>(reg),
        VillagerLevel = (MerchantLevel)r.ReadVarInt(),
        Experience = r.ReadVarInt(),
        IsRegularVillager = r.ReadBoolean(),
        CanRestock = r.ReadBoolean()
    };
}
