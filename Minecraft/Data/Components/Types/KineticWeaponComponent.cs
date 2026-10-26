using Minecraft.Data.Components.Codecs;
using Minecraft.Data.Sounds;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using NBT;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// A weapon that hurts by being carried into something, vanilla's <c>KineticWeapon</c>. Each of the
/// three outcomes has its own <see cref="Condition"/>, and damage is the holder's base attack damage
/// plus the closing speed times <see cref="Data.DamageMultiplier"/>.
/// </summary>
public record KineticWeaponComponent() : IDataComponent<KineticWeaponComponent.Data> {
    public override Identifier Identifier => "minecraft:kinetic_weapon";

    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, _) => new CompoundBuilder()
            .Int("contact_cooldown_ticks", val.ContactCooldownTicks, 10)
            .Int("delay_ticks", val.DelayTicks, 0)
            .Maybe("dismount_conditions", val.DismountConditions, WriteCondition)
            .Maybe("knockback_conditions", val.KnockbackConditions, WriteCondition)
            .Maybe("damage_conditions", val.DamageConditions, WriteCondition)
            .Float("forward_movement", val.ForwardMovement, 0f)
            .Float("damage_multiplier", val.DamageMultiplier, 1f)
            .Sound("sound", val.Sound)
            .Sound("hit_sound", val.HitSound)
            .Build(),
        (tag, registry) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:kinetic_weapon");
            Data data = new(
                node.Int("contact_cooldown_ticks", 10),
                node.Int("delay_ticks", 0),
                node.ObjectOrNull("dismount_conditions", ReadCondition),
                node.ObjectOrNull("knockback_conditions", ReadCondition),
                node.ObjectOrNull("damage_conditions", ReadCondition),
                node.Float("forward_movement", 0f),
                node.Float("damage_multiplier", 1f),
                node.Sound("sound", registry),
                node.Sound("hit_sound", registry));
            node.AssertRead();
            return data;
        });

    private static INbtTag WriteCondition(Condition condition) {
        return new CompoundBuilder()
            .Int("max_duration_ticks", condition.MaxDurationTicks)
            .Float("min_speed", condition.MinSpeed, 0f)
            .Float("min_relative_speed", condition.MinRelativeSpeed, 0f)
            .Build();
    }

    private static Condition ReadCondition(NbtNode node) {
        Condition condition = new(
            node.Int("max_duration_ticks"),
            node.Float("min_speed", 0f),
            node.Float("min_relative_speed", 0f));
        node.AssertRead();
        return condition;
    }

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt(val.ContactCooldownTicks)
            .WriteVarInt(val.DelayTicks)
            .WritePrefixedOptional(val.DismountConditions, WriteCondition)
            .WritePrefixedOptional(val.KnockbackConditions, WriteCondition)
            .WritePrefixedOptional(val.DamageConditions, WriteCondition)
            .WriteFloat(val.ForwardMovement)
            .WriteFloat(val.DamageMultiplier)
            .WritePrefixedOptional(val.Sound, WriteSound)
            .WritePrefixedOptional(val.HitSound, WriteSound);

        void WriteCondition(Condition condition, DataWriter w) {
            w.WriteVarInt(condition.MaxDurationTicks).WriteFloat(condition.MinSpeed).WriteFloat(condition.MinRelativeSpeed);
        }

        void WriteSound(Or<ISoundType, SoundEvent> sound, DataWriter w) {
            w.WriteIdOr(sound, registry.SoundTypes.GetProtocolId, (inline, wr) => wr.Write(inline, registry));
        }
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(
            reader.ReadVarInt(),
            reader.ReadVarInt(),
            reader.ReadPrefixedOptional(ReadCondition),
            reader.ReadPrefixedOptional(ReadCondition),
            reader.ReadPrefixedOptional(ReadCondition),
            reader.ReadFloat(),
            reader.ReadFloat(),
            reader.ReadPrefixedOptional(ReadSound),
            reader.ReadPrefixedOptional(ReadSound));

        Condition ReadCondition(DataReader r) {
            return new Condition(r.ReadVarInt(), r.ReadFloat(), r.ReadFloat());
        }

        Or<ISoundType, SoundEvent> ReadSound(DataReader r) {
            return r.ReadIdOr(id => registry.SoundTypes[id], re => re.Read<SoundEvent>(registry));
        }
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1 == val2;
    }

    /// <param name="ContactCooldownTicks">How long the same target is skipped for after being hit.</param>
    /// <param name="DelayTicks">Ticks of use that pass before the weapon starts hitting anything.</param>
    /// <param name="ForwardMovement">Speed the user is pushed along their look while using it.</param>
    public record Data(
        int ContactCooldownTicks = 10,
        int DelayTicks = 0,
        Condition? DismountConditions = null,
        Condition? KnockbackConditions = null,
        Condition? DamageConditions = null,
        float ForwardMovement = 0f,
        float DamageMultiplier = 1f,
        Or<ISoundType, SoundEvent>? Sound = null,
        Or<ISoundType, SoundEvent>? HitSound = null);

    /// <summary>
    /// One outcome's threshold. A mob's speeds are compared against a fifth of these, so the same
    /// component reads differently for a player and a ridden animal.
    /// </summary>
    /// <param name="MaxDurationTicks">Ticks after the delay within which the outcome can still happen.</param>
    /// <param name="MinSpeed">The user's own speed along their look, in blocks a second.</param>
    /// <param name="MinRelativeSpeed">How much faster than the target the user is closing.</param>
    public record Condition(int MaxDurationTicks, float MinSpeed = 0f, float MinRelativeSpeed = 0f);
}
