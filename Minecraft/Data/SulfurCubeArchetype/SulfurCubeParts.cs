using Minecraft.Data.Attributes;
using Minecraft.Data.DamageType;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Attributes;
using Minecraft.Schemas.Sound;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.SulfurCubeArchetype;

/// <summary>One attribute a sulfur cube of this archetype has modified while it exists.</summary>
public record SulfurCubeAttributeEntry(IAttribute Attribute, AttributeModifier Modifier) {

    public INbtTag ToNbt() {
        // The modifier's own fields sit alongside the attribute rather than under it
        List<(string, INbtTag)> children = [("attribute", new StringTag(Attribute.Identifier.ToString()))];
        children.AddRange(((CompoundTag)Modifier.ToNbt()).Children);
        return new CompoundTag(children.ToArray());
    }

    public static SulfurCubeAttributeEntry FromNbt(INbtTag tag, MinecraftRegistry reg) {
        CompoundTag compound = (CompoundTag)tag;
        return new SulfurCubeAttributeEntry(
            reg.Attributes[compound["attribute"]!.GetString()],
            AttributeModifier.FromNbt(compound));
    }
}

/// <summary>The explosion a sulfur cube of this archetype goes off with.</summary>
public record SulfurCubeExplosion(int Power, bool CausesFire, int Fuse) {

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("power", new IntegerTag(Power)),
            ("causes_fire", new BooleanTag(CausesFire)),
            ("fuse", new IntegerTag(Fuse)));
    }

    public static SulfurCubeExplosion FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        return new SulfurCubeExplosion(
            compound["power"]!.AsInt(),
            compound["causes_fire"]!.AsBool(),
            compound["fuse"]!.AsInt());
    }
}

/// <summary>The damage touching a sulfur cube of this archetype deals.</summary>
/// <param name="AttributeToSource">
/// Whether whoever last pushed the cube is blamed for the damage instead of the cube itself.
/// </param>
public record SulfurCubeContactDamage(IDamageType DamageType, FloatProvider Amount, bool AttributeToSource) {

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("damage_type", new StringTag(DamageType.Identifier.ToString())),
            ("amount", Amount.ToNbt()),
            ("attribute_to_source", new BooleanTag(AttributeToSource)));
    }

    public static SulfurCubeContactDamage FromNbt(INbtTag tag, MinecraftRegistry reg) {
        CompoundTag compound = (CompoundTag)tag;
        return new SulfurCubeContactDamage(
            reg.DamageTypes[compound["damage_type"]!.GetString()],
            FloatProvider.FromNbt(compound["amount"]!),
            compound["attribute_to_source"]!.AsBool());
    }
}

/// <summary>How hard a sulfur cube of this archetype is thrown when something hits it.</summary>
public record SulfurCubeKnockbackModifiers(float HorizontalPower, float VerticalPower) {

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("horizontal_power", new FloatTag(HorizontalPower)),
            ("vertical_power", new FloatTag(VerticalPower)));
    }

    public static SulfurCubeKnockbackModifiers FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        return new SulfurCubeKnockbackModifiers(
            compound["horizontal_power"]!.AsFloat(),
            compound["vertical_power"]!.AsFloat());
    }
}

/// <param name="PushSoundImpulseThreshold">How hard a push has to be before it makes a sound.</param>
/// <param name="PushSoundCooldown">Seconds before the push sound may play again.</param>
public record SulfurCubeSoundSettings(
    SoundEvent HitSound,
    SoundEvent PushSound,
    float PushSoundImpulseThreshold,
    float PushSoundCooldown) {

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("hit_sound", HitSound.ToNbt()),
            ("push_sound", PushSound.ToNbt()),
            ("push_sound_impulse_threshold", new FloatTag(PushSoundImpulseThreshold)),
            ("push_sound_cooldown", new FloatTag(PushSoundCooldown)));
    }

    public static SulfurCubeSoundSettings FromNbt(INbtTag tag, MinecraftRegistry reg) {
        CompoundTag compound = (CompoundTag)tag;
        return new SulfurCubeSoundSettings(
            SoundEvent.FromNbt(compound["hit_sound"]!, reg),
            SoundEvent.FromNbt(compound["push_sound"]!, reg),
            compound["push_sound_impulse_threshold"]!.AsFloat(),
            compound["push_sound_cooldown"]!.AsFloat());
    }
}
