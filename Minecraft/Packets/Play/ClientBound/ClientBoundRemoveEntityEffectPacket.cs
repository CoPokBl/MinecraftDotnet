using Minecraft.Data.PotionEffectTypes;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundRemoveEntityEffectPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:remove_mob_effect";
    
    public required int EntityId { get; init; }
    public required IPotionEffectType Effect { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .WriteVarInt(Effect.ProtocolId);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundRemoveEntityEffectPacket {
        EntityId = r.ReadVarInt(),
        Effect = reg.PotionEffectTypes[r.ReadVarInt()]
    };
}
