using ManagedServer.Entities.Types;
using Minecraft.Data.PotionEffectTypes;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;

namespace ManagedServer.Entities;

/// <summary>
/// The status effects on one entity, vanilla's <c>activeEffects</c> map on <c>LivingEntity</c>. Held
/// as state rather than behaviour: what an effect <i>does</i> is a feature's business, and with none
/// of those registered an effect is just a number on the entity and an icon on the client.
/// <p/>
/// <see cref="Features.Basic.EffectsFeature"/> is what counts the durations down. Without it nothing
/// does and every effect lasts forever.
/// </summary>
public class EntityEffects(LivingEntity entity) {
    /// <summary>
    /// What vanilla writes into a duration that never runs out, <c>MobEffectInstance.INFINITE_DURATION</c>.
    /// The client shows it as a duration of its own rather than counting down.
    /// </summary>
    public const int InfiniteDuration = -1;

    private readonly Dictionary<Identifier, PotionEffect> _effects = [];

    /// <summary>A copy, so an effect can be added or removed while iterating this.</summary>
    public PotionEffect[] All {
        get {
            lock (_effects) {
                return _effects.Values.ToArray();
            }
        }
    }

    public PotionEffect? Get(IPotionEffectType type) {
        lock (_effects) {
            return _effects.GetValueOrDefault(type.Identifier);
        }
    }

    public bool Has(IPotionEffectType type) {
        lock (_effects) {
            return _effects.ContainsKey(type.Identifier);
        }
    }

    /// <summary>
    /// The amplifier of an effect, or null without it. Note that vanilla amplifiers are zero based:
    /// Resistance I is an amplifier of zero.
    /// </summary>
    public int? AmplifierOf(IPotionEffectType type) {
        return Get(type)?.Amplifier;
    }

    /// <summary>
    /// Adds an effect, or merges it into one the entity already has the way
    /// <c>MobEffectInstance.update</c> does: a stronger effect replaces a weaker one outright, an
    /// equally strong one only extends the duration, and a weaker one is ignored entirely. Returns
    /// whether anything changed.
    /// </summary>
    public bool Add(PotionEffect effect) {
        lock (_effects) {
            if (_effects.TryGetValue(effect.Type.Identifier, out PotionEffect? existing)
                && !Improves(effect, existing)) {
                return false;
            }

            _effects[effect.Type.Identifier] = effect;
        }

        Send(effect);
        return true;
    }

    /// <summary>Convenience for the common case, an effect that shows its icon and particles.</summary>
    public bool Add(IPotionEffectType type, int amplifier, int duration) {
        return Add(new PotionEffect(type, amplifier, duration, false, true, true));
    }

    public bool Remove(IPotionEffectType type) {
        lock (_effects) {
            if (!_effects.Remove(type.Identifier)) {
                return false;
            }
        }

        SendRemove(type);
        return true;
    }

    public void Clear() {
        foreach (PotionEffect effect in All) {
            Remove(effect.Type);
        }
    }

    /// <summary>
    /// Counts every finite duration down by one and drops the ones that ran out, returning those so
    /// the caller can report them. <see cref="Features.Basic.EffectsFeature"/> calls this once a tick
    /// and is the only thing that should.
    /// <p/>
    /// No packet goes out for the countdown itself. The client runs the same clock, so telling it a
    /// duration it already worked out is twenty packets a second per effect for nothing.
    /// </summary>
    internal PotionEffect[] TickDurations() {
        List<PotionEffect> expired = [];
        lock (_effects) {
            foreach ((Identifier id, PotionEffect effect) in _effects.ToArray()) {
                if (effect.Duration == InfiniteDuration) {
                    continue;
                }

                int duration = effect.Duration - 1;
                if (duration <= 0) {
                    _effects.Remove(id);
                    expired.Add(effect);
                }
                else {
                    _effects[id] = effect with { Duration = duration };
                }
            }
        }

        foreach (PotionEffect effect in expired) {
            SendRemove(effect.Type);
        }

        return expired.ToArray();
    }

    private void SendRemove(IPotionEffectType type) {
        entity.SendToSelfAndViewers(new ClientBoundRemoveEntityEffectPacket {
            EntityId = entity.NetId,
            Effect = type
        });
    }

    private void Send(PotionEffect effect) {
        ClientBoundEntityEffectPacket.Flags flags = 0;
        if (effect.Ambient) {
            flags |= ClientBoundEntityEffectPacket.Flags.IsAmbient;
        }

        if (effect.ShowParticles) {
            flags |= ClientBoundEntityEffectPacket.Flags.ShowParticles;
        }

        if (effect.ShowIcon) {
            flags |= ClientBoundEntityEffectPacket.Flags.ShowIcon;
        }

        entity.SendToSelfAndViewers(new ClientBoundEntityEffectPacket {
            EntityId = entity.NetId,
            Effect = effect.Type,
            Amplifier = effect.Amplifier,
            Duration = effect.Duration,
            EffectFlags = flags
        });
    }

    /// <summary>
    /// <c>MobEffectInstance.update</c>, as the question of whether the new one wins. An infinite
    /// duration beats any finite one, which vanilla gets for free from -1 being special cased.
    /// </summary>
    private static bool Improves(PotionEffect incoming, PotionEffect existing) {
        if (incoming.Amplifier != existing.Amplifier) {
            return incoming.Amplifier > existing.Amplifier;
        }

        if (incoming.Duration == InfiniteDuration) {
            return true;
        }

        return existing.Duration != InfiniteDuration && incoming.Duration > existing.Duration;
    }
}
