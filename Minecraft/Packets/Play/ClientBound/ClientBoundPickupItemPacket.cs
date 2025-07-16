using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundPickupItemPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:take_item_entity";

    public required int CollectedEntityId;
    public required int CollectorEntityId;
    public required int PickupItemCount;
    
    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(CollectedEntityId)
            .WriteVarInt(CollectorEntityId)
            .WriteVarInt(PickupItemCount);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundPickupItemPacket {
        CollectedEntityId = r.ReadVarInt(),
        CollectorEntityId = r.ReadVarInt(),
        PickupItemCount = r.ReadVarInt()
    };
}
