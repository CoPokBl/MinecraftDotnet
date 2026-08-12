using Minecraft.Data.PotionEffectTypes;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Sent when the player confirms a beacon's effects.</summary>
public class ServerBoundSetBeaconEffectPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:set_beacon";

    /// <summary>The effect from the beacon's first column, or null when none was chosen.</summary>
    public IPotionEffectType? PrimaryEffect { get; init; }

    /// <summary>The effect from the beacon's second column, or null when none was chosen.</summary>
    public IPotionEffectType? SecondaryEffect { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WritePrefixedOptional(PrimaryEffect,
                (effect, writer) => writer.WriteVarInt(reg.PotionEffectTypes.GetProtocolId(effect)))
            .WritePrefixedOptional(SecondaryEffect,
                (effect, writer) => writer.WriteVarInt(reg.PotionEffectTypes.GetProtocolId(effect)));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ServerBoundSetBeaconEffectPacket {
        PrimaryEffect = r.ReadPrefixedOptional(reader => reg.PotionEffectTypes[reader.ReadVarInt()]),
        SecondaryEffect = r.ReadPrefixedOptional(reader => reg.PotionEffectTypes[reader.ReadVarInt()])
    };
}
