using Minecraft.Data;
using Minecraft.Data.PotionEffectTypes;
using Minecraft.Registry;

namespace Minecraft.Schemas;

public record PotionEffect(
    IPotionEffectType Type,
    int Amplifier,
    int Duration,
    bool Ambient,
    bool ShowParticles,
    bool ShowIcon,
    PotionEffect.HiddenEffect? Hidden = null) : INetworkType<PotionEffect> {

    /// <summary>
    /// The effect an entity goes back to when this one runs out, vanilla's
    /// <c>MobEffectInstance.hiddenEffect</c>. It is the same effect type, so only the settings the
    /// stronger instance overrode travel.
    /// </summary>
    public record HiddenEffect(
        int Amplifier,
        int Duration,
        bool Ambient,
        bool ShowParticles,
        bool ShowIcon,
        HiddenEffect? Hidden = null) {

        public static HiddenEffect ReadData(DataReader reader) {
            return new HiddenEffect(
                reader.ReadVarInt(),
                reader.ReadVarInt(),
                reader.ReadBoolean(),
                reader.ReadBoolean(),
                reader.ReadBoolean(),
                reader.ReadPrefixedOptional(ReadData));
        }

        public DataWriter WriteData(DataWriter writer) {
            return writer
                .WriteVarInt(Amplifier)
                .WriteVarInt(Duration)
                .WriteBoolean(Ambient)
                .WriteBoolean(ShowParticles)
                .WriteBoolean(ShowIcon)
                .WritePrefixedOptional(Hidden, (h, w) => h.WriteData(w));
        }
    }

    public static PotionEffect ReadData(DataReader reader, MinecraftRegistry registry) {
        IPotionEffectType type = registry.PotionEffectTypes[reader.ReadVarInt()];
        int amplifier = reader.ReadVarInt();
        int duration = reader.ReadVarInt();
        bool ambient = reader.ReadBoolean();
        bool showParticles = reader.ReadBoolean();
        bool showIcon = reader.ReadBoolean();
        HiddenEffect? hidden = reader.ReadPrefixedOptional(HiddenEffect.ReadData);

        return new PotionEffect(type, amplifier, duration, ambient, showParticles, showIcon, hidden);
    }

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt(registry.PotionEffectTypes.GetProtocolId(Type))
            .WriteVarInt(Amplifier)
            .WriteVarInt(Duration)
            .WriteBoolean(Ambient)
            .WriteBoolean(ShowParticles)
            .WriteBoolean(ShowIcon)
            .WritePrefixedOptional(Hidden, (h, w) => h.WriteData(w));
    }
}
