using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Attributes;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateAttributesPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:update_attributes";
    
    public required int EntityId { get; init; }
    public required AttributeValue[] Attributes { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WriteVarInt(EntityId)
            .WritePrefixedArray(Attributes, reg);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundUpdateAttributesPacket {
        EntityId = r.ReadVarInt(),
        Attributes = r.ReadPrefixedArray<AttributeValue>(reg)
    };
}
