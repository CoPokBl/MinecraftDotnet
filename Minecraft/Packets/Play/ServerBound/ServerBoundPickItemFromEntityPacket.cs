using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPickItemFromEntityPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:pick_item_from_entity";
    
    public required int EntityId { get; init; }
    public required bool IncludeData { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .WriteBoolean(IncludeData);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundPickItemFromEntityPacket {
        EntityId = r.ReadVarInt(),
        IncludeData = r.ReadBoolean()
    };
}
