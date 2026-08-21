using Minecraft.Data.ConsumeEffects;
using Minecraft.Data.ConsumeEffects.Types;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using NBT;

namespace Minecraft.Data.Components.Codecs;

/// <summary>
/// The two shapes that show up inside several components rather than as one: a potion effect, and
/// the effects an item applies when it is used up.
/// </summary>
public static class EffectCodecs {
    /// <summary>
    /// A potion effect, vanilla's <c>MobEffectInstance</c>.
    /// </summary>
    /// <remarks>
    /// The settings sit beside the id rather than nested, because vanilla flattens its
    /// <c>Details</c> map codec into the instance. <c>show_icon</c> falls back to
    /// <c>show_particles</c> rather than to a constant, which is why it is read in that order.
    /// </remarks>
    public static INbtTag WriteEffect(PotionEffect effect) {
        return Details(new CompoundBuilder().Holder("id", effect.Type), effect.Amplifier,
                effect.Duration, effect.Ambient, effect.ShowParticles, effect.ShowIcon)
            .Maybe("hidden_effect", effect.Hidden, hidden => Details(new CompoundBuilder(),
                hidden.Amplifier, hidden.Duration, hidden.Ambient, hidden.ShowParticles,
                hidden.ShowIcon).Build())
            .Build();
    }

    public static PotionEffect ReadEffect(INbtTag tag, MinecraftRegistry registry, Identifier component) {
        NbtNode node = NbtNode.Of(tag, component);

        int amplifier = node.Int("amplifier", 0);
        int duration = node.Int("duration", 0);
        bool ambient = node.Bool("ambient", false);
        bool particles = node.Bool("show_particles", true);

        PotionEffect effect = new(
            node.Holder("id", registry.PotionEffectTypes),
            amplifier, duration, ambient, particles,
            node.Bool("show_icon", particles),
            node.ObjectOrNull("hidden_effect", hidden => ReadHidden(hidden)));

        node.AssertRead();
        return effect;
    }

    /// <summary>
    /// One effect an item applies as it is consumed, chosen by its <c>type</c>.
    /// </summary>
    /// <remarks>
    /// <c>clear_all_effects</c> and the other bodyless kinds carry nothing but the type, which is
    /// why an unknown one is refused here rather than read as an empty one: an effect nothing
    /// applies is a silently weaker item.
    /// </remarks>
    public static INbtTag WriteConsumeEffect(IConsumeEffect effect, MinecraftRegistry registry) {
        CompoundBuilder builder = new CompoundBuilder().Id("type", effect.Identifier);

        switch (effect) {
            case ApplyEffectsConsumeEffect apply:
                builder.List("effects", apply.Effects ?? [], WriteEffect)
                    .Float("probability", apply.Probability, 1f);
                break;

            case RemoveEffectsConsumeEffect remove:
                builder.IdSet("effects", remove.Effects, registry.PotionEffectTypes);
                break;

            case PlaySoundConsumeEffect play:
                builder.Maybe("sound", play.Sound, sound => sound.ToNbt());
                break;

            case TeleportRandomlyConsumeEffect teleport:
                builder.Float("diameter", teleport.Diameter, 16f);
                break;
        }

        return builder.Build();
    }

    public static IConsumeEffect ReadConsumeEffect(INbtTag tag, MinecraftRegistry registry,
        Identifier component) {

        NbtNode node = NbtNode.Of(tag, component);
        Identifier type = node.Id("type");

        IConsumeEffect effect = type.ToString() switch {
            "minecraft:apply_effects" => new ApplyEffectsConsumeEffect(type,
                node.List("effects", entry => ReadEffect(entry, registry, component)),
                node.Float("probability", 1f)),

            "minecraft:remove_effects" => new RemoveEffectsConsumeEffect(type,
                node.IdSet("effects", registry.PotionEffectTypes)),

            "minecraft:play_sound" => new PlaySoundConsumeEffect(type,
                SoundEvent.FromNbt(node.Require("sound"), registry)),

            "minecraft:teleport_randomly" => new TeleportRandomlyConsumeEffect(type,
                node.Float("diameter", 16f)),

            _ when registry.ConsumeEffects.Contains(type) => new SimpleConsumeEffect(type),

            _ => throw new UnportedComponentException(component,
                $"consume effect {type} has no port.")
        };

        node.AssertRead();
        return effect;
    }

    private static CompoundBuilder Details(CompoundBuilder builder, int amplifier, int duration,
        bool ambient, bool particles, bool icon) {

        return builder
            .Int("amplifier", amplifier, 0)
            .Int("duration", duration, 0)
            .Bool("ambient", ambient, false)
            .Bool("show_particles", particles, true)
            // Always written, where the rest are left off at their defaults: vanilla holds this one
            // as an optional that its getter always fills, so an effect never leaves it out.
            .Bool("show_icon", icon);
    }

    private static PotionEffect.HiddenEffect ReadHidden(NbtNode node) {
        int amplifier = node.Int("amplifier", 0);
        int duration = node.Int("duration", 0);
        bool ambient = node.Bool("ambient", false);
        bool particles = node.Bool("show_particles", true);

        PotionEffect.HiddenEffect hidden = new(amplifier, duration, ambient, particles,
            node.Bool("show_icon", particles),
            node.ObjectOrNull("hidden_effect", ReadHidden));

        node.AssertRead();
        return hidden;
    }
}
