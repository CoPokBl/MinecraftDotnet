using Minecraft.Data.PotionEffectTypes;
using Minecraft.Schemas;

namespace ClientLib.Entities;

/// <summary><c>MobEffectInstance</c>: an active effect, with the weaker or longer ones it hides behind it.</summary>
public sealed class MobEffectInstance : IComparable<MobEffectInstance> {
    public const int InfiniteDuration = -1;

    public IPotionEffectType Effect { get; }
    public int Duration { get; private set; }
    public int Amplifier { get; private set; }
    public bool IsAmbient { get; private set; }
    public bool IsVisible { get; private set; }
    public bool ShowIcon { get; private set; }

    /// <summary><c>hiddenEffect</c>: what this one goes back to when it runs out.</summary>
    public MobEffectInstance? HiddenEffect { get; private set; }

    private readonly BlendState _blendState = new();

    public MobEffectInstance(IPotionEffectType effect, int duration, int amplifier = 0, bool ambient = false, bool visible = true, bool? showIcon = null,
        MobEffectInstance? hiddenEffect = null) {
        Effect = effect;
        Duration = duration;
        Amplifier = Math.Clamp(amplifier, 0, 255);
        IsAmbient = ambient;
        IsVisible = visible;
        ShowIcon = showIcon ?? visible;
        HiddenEffect = hiddenEffect;
    }

    /// <summary>The copy constructor, which leaves the hidden chain behind.</summary>
    public MobEffectInstance(MobEffectInstance copy) {
        Effect = copy.Effect;
        SetDetailsFrom(copy);
    }

    /// <summary>The instance an item component or other codec describes, hidden chain included.</summary>
    public static MobEffectInstance From(PotionEffect effect) =>
        new(effect.Type, effect.Duration, effect.Amplifier, effect.Ambient, effect.ShowParticles, effect.ShowIcon, Hidden(effect.Type, effect.Hidden));

    private static MobEffectInstance? Hidden(IPotionEffectType type, PotionEffect.HiddenEffect? hidden) =>
        hidden == null ? null : new MobEffectInstance(type, hidden.Duration, hidden.Amplifier, hidden.Ambient, hidden.ShowParticles, hidden.ShowIcon, Hidden(type, hidden.Hidden));

    public bool IsInfiniteDuration => Duration == InfiniteDuration;

    public bool EndsWithin(int ticks) => !IsInfiniteDuration && Duration <= ticks;

    /// <summary><c>getBlendFactor</c>: how far the effect has faded in, for the effects that fade.</summary>
    public float BlendFactor(bool entityRemoved, float partialTick) => _blendState.Factor(entityRemoved, partialTick);

    public void CopyBlendState(MobEffectInstance instance) => _blendState.CopyFrom(instance._blendState);

    public void SkipBlending() => _blendState.SetImmediate(this);

    private void SetDetailsFrom(MobEffectInstance copy) {
        Duration = copy.Duration;
        Amplifier = copy.Amplifier;
        IsAmbient = copy.IsAmbient;
        IsVisible = copy.IsVisible;
        ShowIcon = copy.ShowIcon;
    }

    /// <summary><c>update</c>: folds a second instance of the same effect in, keeping the weaker one hidden while it outlasts this.</summary>
    public bool Update(MobEffectInstance takeOver) {
        bool changed = false;
        if (takeOver.Amplifier > Amplifier) {
            if (takeOver.IsShorterDurationThan(this)) {
                MobEffectInstance? prevHiddenEffect = HiddenEffect;
                HiddenEffect = new MobEffectInstance(this) { HiddenEffect = prevHiddenEffect };
            }
            Amplifier = takeOver.Amplifier;
            Duration = takeOver.Duration;
            changed = true;
        }
        else if (IsShorterDurationThan(takeOver)) {
            if (takeOver.Amplifier == Amplifier) {
                Duration = takeOver.Duration;
                changed = true;
            }
            else if (HiddenEffect == null) {
                HiddenEffect = new MobEffectInstance(takeOver);
            }
            else {
                HiddenEffect.Update(takeOver);
            }
        }

        if (!takeOver.IsAmbient && IsAmbient || changed) {
            IsAmbient = takeOver.IsAmbient;
            changed = true;
        }
        if (takeOver.IsVisible != IsVisible) {
            IsVisible = takeOver.IsVisible;
            changed = true;
        }
        if (takeOver.ShowIcon != ShowIcon) {
            ShowIcon = takeOver.ShowIcon;
            changed = true;
        }
        return changed;
    }

    private bool IsShorterDurationThan(MobEffectInstance other) => !IsInfiniteDuration && (Duration < other.Duration || other.IsInfiniteDuration);

    /// <summary><c>tickClient</c>.</summary>
    public void TickClient() {
        if (HasRemainingDuration) {
            TickDownDuration();
            DowngradeToHiddenEffect();
        }
        _blendState.Tick(this);
    }

    private bool HasRemainingDuration => IsInfiniteDuration || Duration > 0;

    private void TickDownDuration() {
        HiddenEffect?.TickDownDuration();
        if (!IsInfiniteDuration && Duration != 0) {
            Duration--;
        }
    }

    private void DowngradeToHiddenEffect() {
        if (Duration == 0 && HiddenEffect != null) {
            SetDetailsFrom(HiddenEffect);
            HiddenEffect = HiddenEffect.HiddenEffect;
        }
    }

    /// <summary>
    /// <c>compareTo</c>: shorter and non ambient first, then by colour. Two ambient effects, or two both past
    /// 32147 ticks, compare on ambience and colour alone.
    /// </summary>
    public int CompareTo(MobEffectInstance? o) {
        if (o == null) {
            return 1;
        }
        if ((Duration <= 32147 || o.Duration <= 32147) && (!IsAmbient || !o.IsAmbient)) {
            int result = IsAmbient.CompareTo(o.IsAmbient);
            if (result == 0) {
                result = IsInfiniteDuration.CompareTo(o.IsInfiniteDuration);
            }
            if (result == 0) {
                result = Duration.CompareTo(o.Duration);
            }
            return result != 0 ? result : MobEffects.Get(Effect).Color.CompareTo(MobEffects.Get(o.Effect).Color);
        }
        int ambient = IsAmbient.CompareTo(o.IsAmbient);
        return ambient != 0 ? ambient : MobEffects.Get(Effect).Color.CompareTo(MobEffects.Get(o.Effect).Color);
    }

    /// <summary><c>MobEffectInstance.BlendState</c>.</summary>
    private sealed class BlendState {
        private float _factor;
        private float _factorPreviousFrame;

        public void SetImmediate(MobEffectInstance instance) {
            _factor = HasEffect(instance) ? 1.0F : 0.0F;
            _factorPreviousFrame = _factor;
        }

        public void CopyFrom(BlendState other) {
            _factor = other._factor;
            _factorPreviousFrame = other._factorPreviousFrame;
        }

        public void Tick(MobEffectInstance instance) {
            _factorPreviousFrame = _factor;
            bool hasEffect = HasEffect(instance);
            float target = hasEffect ? 1.0F : 0.0F;
            if (_factor != target) {
                MobEffect effect = MobEffects.Get(instance.Effect);
                int blendDuration = hasEffect ? effect.BlendInDurationTicks : effect.BlendOutDurationTicks;
                if (blendDuration == 0) {
                    _factor = target;
                }
                else {
                    float maxDeltaPerTick = 1.0F / blendDuration;
                    _factor += Math.Clamp(target - _factor, -maxDeltaPerTick, maxDeltaPerTick);
                }
            }
        }

        private static bool HasEffect(MobEffectInstance instance) => !instance.EndsWithin(MobEffects.Get(instance.Effect).BlendOutAdvanceTicks);

        public float Factor(bool entityRemoved, float partialTick) {
            if (entityRemoved) {
                _factorPreviousFrame = _factor;
            }
            return _factorPreviousFrame + partialTick * (_factor - _factorPreviousFrame);
        }
    }
}
