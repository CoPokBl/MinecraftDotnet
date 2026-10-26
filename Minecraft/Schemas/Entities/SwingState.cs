using Minecraft.Schemas.Items;

namespace Minecraft.Schemas.Entities;

/// <summary>
/// <c>LivingEntity.SwingState</c>: the arm swing a living entity is part way through, on both sides of
/// the connection. A new swing is refused while the current one is in its first half.
/// </summary>
public sealed class SwingState {
    /// <summary><c>LivingEntity.SwingDescription</c>.</summary>
    public sealed record Swing(Hand Hand, SwingAnimation Animation, int DurationTicks);

    public Swing? Current { get; private set; }

    public bool IsSwinging => Current != null;

    /// <summary>How far through the swing the last tick left it, from 0 to 1.</summary>
    public float Animation { get; private set; }

    private int _ticks;
    private float _oldAnimation;

    /// <summary><c>startIfAble</c>. The duration is the animation's own, already adjusted for haste and fatigue.</summary>
    public bool StartIfAble(Hand hand, SwingAnimation animation, int durationTicks) {
        if (Current != null && _ticks <= Current.DurationTicks / 2 && _ticks > 0) {
            return false;
        }

        Start(hand, animation, durationTicks);
        return true;
    }

    private void Start(Hand hand, SwingAnimation animation, int durationTicks) {
        Swing? old = Current;
        Current = new Swing(hand, animation, durationTicks);
        if (!Current.Equals(old)) {
            _oldAnimation = 0.0F;
            Animation = 0.0F;
        }

        _ticks = 0;
    }

    public void Tick() {
        _oldAnimation = Animation;
        if (Current != null) {
            if (Current.DurationTicks > 0) {
                Animation = Math.Min((float)_ticks / Current.DurationTicks, 1.0F);
            }

            if (_ticks++ > Current.DurationTicks) {
                Current = null;
                Animation = 0.0F;
            }
        }
        else {
            Animation = 0.0F;
        }
    }

    /// <summary><c>getAnimation</c>. A swing that restarted this tick runs on past one rather than back to zero.</summary>
    public float GetAnimation(float partialTicks) {
        return Animation >= _oldAnimation
            ? Mth.Lerp(partialTicks, _oldAnimation, Animation)
            : Mth.Lerp(partialTicks, _oldAnimation, Animation + 1.0F);
    }

    /// <summary>
    /// <c>LivingEntity.getModifiedSwingDuration</c>: haste or conduit power take the higher of their
    /// amplifiers plus one off, otherwise mining fatigue adds twice its amplifier plus one.
    /// </summary>
    public static int ModifiedDuration(SwingAnimation animation, int? hasteAmplifier, int? conduitAmplifier, int? fatigueAmplifier) {
        int duration = animation.Duration;
        if (hasteAmplifier != null || conduitAmplifier != null) {
            return duration - (1 + Math.Max(hasteAmplifier ?? 0, conduitAmplifier ?? 0));
        }

        return fatigueAmplifier is { } fatigue ? duration + (1 + fatigue) * 2 : duration;
    }
}
