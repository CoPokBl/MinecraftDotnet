using Minecraft.Data.PotionEffectTypes;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundEntityEffectPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:update_mob_effect";

    public required int EntityId { get; init; }
    public required IPotionEffectType Effect { get; init; }
    public required int Amplifier { get; init; }
    public required int Duration { get; init; }
    public required Flags EffectFlags { get; init; }
    
    [Flags]
    public enum Flags {
        IsAmbient = 0x01,
        ShowParticles = 0x02,
        ShowIcon = 0x04,
        Blend = 0x08
    }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .WriteVarInt(Effect.ProtocolId)
            .WriteVarInt(Amplifier)
            .WriteVarInt(Duration)
            .WriteByte((sbyte)EffectFlags);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundEntityEffectPacket {
        EntityId = r.ReadVarInt(),
        Effect = reg.PotionEffectTypes[r.ReadVarInt()],
        Amplifier = r.ReadVarInt(),
        Duration = r.ReadVarInt(),
        EffectFlags = (Flags)r.ReadByte()
    };
}
