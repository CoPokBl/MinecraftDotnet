using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.DamageType;

public interface IDamageType : IProtocolType {
    public float Exhaustion { get; }
    public string MessageId { get; }
    public DamageScaling Scaling { get; }
    public DamageEffectType Effects { get; }
    public DeathMessageType DeathMessageType { get; }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [
            ("exhaustion", new FloatTag(Exhaustion)),
            ("message_id", new StringTag(MessageId)),
            ("scaling", new StringTag(Scaling.ToProtocolString()))
        ];

        if (Effects != DamageEffectType.Hurt) {
            children.Add(("effects", new StringTag(Effects.ToProtocolString())));
        }

        if (DeathMessageType != DeathMessageType.Default) {
            children.Add(("death_message_type", new StringTag(DeathMessageType.ToProtocolString())));
        }

        return new CompoundTag(children.ToArray());
    }

    public static IDamageType FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        float exhaustion = tag["exhaustion"].GetFloat();
        string messageId = tag["message_id"].GetString();
        DamageScaling scaling = DamageScalingExtensions.ParseDamageScaling(tag["scaling"].GetString());

        DamageEffectType effects = tag.Contains("effects")
            ? DamageEffectTypeExtensions.ParseDamageEffectType(tag["effects"].GetString())
            : DamageEffectType.Hurt;

        DeathMessageType deathMessageType = tag.Contains("death_message_type")
            ? DeathMessageTypeExtensions.ParseDeathMessageType(tag["death_message_type"].GetString())
            : DeathMessageType.Default;

        return new SimpleDamageType(ident, exhaustion, messageId, scaling, effects, deathMessageType);
    }
}
