using System.Numerics;

namespace GraphicalClient.Rendering.Entities;

// Vanilla's keyframe animations, net.minecraft.client.animation: per bone channels of keyframes that
// offset a part's pose from where setupAnim left it. Definitions transcribe as they are written.

/// <summary><c>Keyframe</c>: a target before and after the time, so a channel can jump.</summary>
public readonly record struct Keyframe(float Timestamp, Vector3 PreTarget, Vector3 PostTarget, AnimationInterpolation Interpolation) {
    public Keyframe(float timestamp, Vector3 target, AnimationInterpolation interpolation) : this(timestamp, target, target, interpolation) { }
}

public delegate Vector3 AnimationInterpolation(float alpha, Keyframe[] keyframes, int prev, int next, float targetScale);

public delegate void AnimationTarget(ModelPart part, Vector3 value);

/// <summary><c>AnimationChannel</c>.</summary>
public sealed record AnimationChannel(AnimationTarget Target, params Keyframe[] Keyframes) {
    public static class Interpolations {
        public static readonly AnimationInterpolation Linear = (alpha, keyframes, prev, next, scale) =>
            Vector3.Lerp(keyframes[prev].PostTarget, keyframes[next].PreTarget, alpha) * scale;

        public static readonly AnimationInterpolation CatmullRom = (alpha, keyframes, prev, next, scale) => {
            Vector3 p0 = keyframes[Math.Max(0, prev - 1)].PostTarget, p1 = keyframes[prev].PostTarget;
            Vector3 p2 = keyframes[next].PostTarget, p3 = keyframes[Math.Min(keyframes.Length - 1, next + 1)].PostTarget;
            return new Vector3(
                Mth.CatmullRom(alpha, p0.X, p1.X, p2.X, p3.X),
                Mth.CatmullRom(alpha, p0.Y, p1.Y, p2.Y, p3.Y),
                Mth.CatmullRom(alpha, p0.Z, p1.Z, p2.Z, p3.Z)) * scale;
        };
    }

    public static class Targets {
        public static readonly AnimationTarget Position = (part, v) => part.OffsetPos(v);
        public static readonly AnimationTarget Rotation = (part, v) => part.OffsetRotation(v);
        public static readonly AnimationTarget Scale = (part, v) => part.OffsetScale(v);
    }
}

/// <summary><c>KeyframeAnimations</c>: the units definitions are written in.</summary>
public static class KeyframeAnimations {
    public static Vector3 PosVec(float x, float y, float z) => new(x, -y, z);
    public static Vector3 DegreeVec(float x, float y, float z) => new(x * MathF.PI / 180.0F, y * MathF.PI / 180.0F, z * MathF.PI / 180.0F);
    public static Vector3 ScaleVec(double x, double y, double z) => new((float)(x - 1.0), (float)(y - 1.0), (float)(z - 1.0));
}

/// <summary><c>AnimationDefinition</c>.</summary>
public sealed class AnimationDefinition {
    public float LengthInSeconds { get; }
    public bool Looping { get; }
    public IReadOnlyList<(string Bone, AnimationChannel Channel)> Channels { get; }

    private AnimationDefinition(float length, bool looping, List<(string, AnimationChannel)> channels) {
        LengthInSeconds = length;
        Looping = looping;
        Channels = channels;
    }

    public KeyframeAnimation Bake(ModelPart root) => new(this, root);

    public sealed class Builder {
        private readonly float _length;
        private readonly List<(string, AnimationChannel)> _channels = [];
        private bool _looping;

        private Builder(float length) {
            _length = length;
        }

        public static Builder WithLength(float seconds) => new(seconds);

        public Builder Looping() {
            _looping = true;
            return this;
        }

        public Builder AddAnimation(string bone, AnimationChannel channel) {
            _channels.Add((bone, channel));
            return this;
        }

        public AnimationDefinition Build() => new(_length, _looping, _channels);
    }
}

/// <summary><c>KeyframeAnimation</c>: a definition bound to a model's parts.</summary>
public sealed class KeyframeAnimation {
    private readonly AnimationDefinition _definition;
    private readonly (ModelPart Part, AnimationTarget Target, Keyframe[] Keyframes)[] _entries;

    public KeyframeAnimation(AnimationDefinition definition, ModelPart root) {
        _definition = definition;
        Dictionary<string, ModelPart> parts = root.PartLookup();
        _entries = definition.Channels.Select(c => parts.TryGetValue(c.Bone, out ModelPart? part)
            ? (part, c.Channel.Target, c.Channel.Keyframes)
            : throw new ArgumentException($"Cannot animate {c.Bone}, which does not exist in model")).ToArray();
    }

    public void ApplyStatic() => Apply(0, 1.0F);

    public void ApplyWalk(float animationPos, float animationSpeed, float speedFactor, float scaleFactor) =>
        Apply((long)(animationPos * 50.0F * speedFactor), Math.Min(animationSpeed * scaleFactor, 1.0F));

    public void Apply(AnimationState state, float ageInTicks, float speedFactor = 1.0F) {
        if (state.IsStarted) {
            Apply((long)(state.TimeInMillis(ageInTicks) * speedFactor), 1.0F);
        }
    }

    public void Apply(long millisSinceStart, float targetScale) {
        float seconds = millisSinceStart / 1000.0F;
        if (_definition.Looping) {
            seconds %= _definition.LengthInSeconds;
        }
        foreach ((ModelPart part, AnimationTarget target, Keyframe[] keyframes) in _entries) {
            int prev = Math.Max(0, Mth.BinarySearch(0, keyframes.Length, i => seconds <= keyframes[i].Timestamp) - 1);
            int next = Math.Min(keyframes.Length - 1, prev + 1);
            float alpha = next != prev
                ? Math.Clamp((seconds - keyframes[prev].Timestamp) / (keyframes[next].Timestamp - keyframes[prev].Timestamp), 0.0F, 1.0F)
                : 0.0F;
            target(part, keyframes[next].Interpolation(alpha, keyframes, prev, next, targetScale));
        }
    }
}

/// <summary>
/// <c>AnimationState</c>: when an entity's animation started, in ticks. Vanilla keeps these on the
/// client's entity and starts them from entity data and events; here a renderer keeps them per entity.
/// </summary>
public sealed class AnimationState {
    private const int Stopped = int.MinValue;
    private int _startTick = Stopped;

    public bool IsStarted => _startTick != Stopped;

    public void Start(int tickCount) => _startTick = tickCount;

    public void StartIfStopped(int tickCount) {
        if (!IsStarted) {
            Start(tickCount);
        }
    }

    public void AnimateWhen(bool condition, int tickCount) {
        if (condition) {
            StartIfStopped(tickCount);
        }
        else {
            Stop();
        }
    }

    public void Stop() => _startTick = Stopped;

    public long TimeInMillis(float ageInTicks) => (long)((ageInTicks - _startTick) * 50.0F);
}
