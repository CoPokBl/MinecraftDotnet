using Minecraft.Data;
using Minecraft.Data.PotionEffectTypes;
using Minecraft.Registry;

namespace Minecraft.Schemas;

// todo: work out what hidden effects are, if has hidden effect is true then one must be present
public record PotionEffect(
    IPotionEffectType Type,
    int Amplifier,
    int Duration,
    bool Ambient,
    bool ShowParticles,
    bool ShowIcon,
    bool HasHiddenEffect) : INetworkType<PotionEffect> {
    
    public static PotionEffect ReadData(DataReader reader, MinecraftRegistry registry) {
        IPotionEffectType type = registry.PotionEffectTypes[reader.ReadVarInt()];
        int amplifier = reader.ReadVarInt();
        int duration = reader.ReadVarInt();
        bool ambient = reader.ReadBoolean();
        bool showParticles = reader.ReadBoolean();
        bool showIcon = reader.ReadBoolean();
        bool hasHiddenEffect = reader.ReadBoolean();

        return new PotionEffect(type, amplifier, duration, ambient, showParticles, showIcon, hasHiddenEffect);
    }

    public DataWriter WriteData(PotionEffect val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt(val.Type.ProtocolId)
            .WriteVarInt(val.Amplifier)
            .WriteVarInt(val.Duration)
            .WriteBoolean(val.Ambient)
            .WriteBoolean(val.ShowParticles)
            .WriteBoolean(val.ShowIcon)
            .WriteBoolean(val.HasHiddenEffect);
    }
}
