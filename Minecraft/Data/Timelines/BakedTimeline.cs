using System.Runtime.CompilerServices;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Timelines;

public readonly record struct Keyframe<T>(int Ticks, T Value);

/// <summary><c>KeyframeTrack</c>: keyframes in tick order, at most two on one tick, and how to ease between them.</summary>
public sealed class KeyframeTrack<T>(IReadOnlyList<Keyframe<T>> keyframes, EasingType easing) {
    public IReadOnlyList<Keyframe<T>> Keyframes => keyframes;
    public EasingType Easing => easing;

    public KeyframeTrackSampler<T> BakeSampler(int? periodTicks, LerpFunction<T> lerp) => new(this, periodTicks, lerp);
}

/// <summary>
/// <c>KeyframeTrackSampler</c>: the track as segments, with a periodic track's wrap from its last keyframe round to
/// its first added at both ends.
/// </summary>
public sealed class KeyframeTrackSampler<T> {
    private readonly int? _periodTicks;
    private readonly LerpFunction<T> _lerp;
    private readonly Segment[] _segments;

    public KeyframeTrackSampler(KeyframeTrack<T> track, int? periodTicks, LerpFunction<T> lerp) {
        _periodTicks = periodTicks;
        _lerp = lerp;
        _segments = BakeSegments(track, periodTicks);
    }

    private static Segment[] BakeSegments(KeyframeTrack<T> track, int? periodTicks) {
        IReadOnlyList<Keyframe<T>> keyframes = track.Keyframes;
        if (keyframes.Count == 1) {
            T value = keyframes[0].Value;
            return [new Segment(EasingType.Constant, value, 0, value, 0)];
        }
        List<Segment> segments = [];
        if (periodTicks is { } period) {
            Keyframe<T> firstKeyframe = keyframes[0];
            Keyframe<T> lastKeyframe = keyframes[^1];
            segments.Add(new Segment(track.Easing, lastKeyframe.Value, lastKeyframe.Ticks - period, firstKeyframe.Value, firstKeyframe.Ticks));
            AddSegmentsFromKeyframes(track, keyframes, segments);
            segments.Add(new Segment(track.Easing, lastKeyframe.Value, lastKeyframe.Ticks, firstKeyframe.Value, firstKeyframe.Ticks + period));
        }
        else {
            AddSegmentsFromKeyframes(track, keyframes, segments);
        }
        return segments.ToArray();
    }

    private static void AddSegmentsFromKeyframes(KeyframeTrack<T> track, IReadOnlyList<Keyframe<T>> keyframes, List<Segment> output) {
        for (int i = 0; i < keyframes.Count - 1; i++) {
            Keyframe<T> keyframe = keyframes[i];
            Keyframe<T> nextKeyframe = keyframes[i + 1];
            output.Add(new Segment(track.Easing, keyframe.Value, keyframe.Ticks, nextKeyframe.Value, nextKeyframe.Ticks));
        }
    }

    public T Sample(long ticks) {
        long sampleTicks = _periodTicks is { } period ? Mth.FloorMod(ticks, period) : ticks;
        Segment segment = GetSegmentAt(sampleTicks);
        if (sampleTicks <= segment.FromTicks) {
            return segment.FromValue;
        }
        if (sampleTicks >= segment.ToTicks) {
            return segment.ToValue;
        }
        float alpha = (float)(sampleTicks - segment.FromTicks) / (segment.ToTicks - segment.FromTicks);
        float easedAlpha = segment.Easing.Apply(alpha);
        return _lerp(easedAlpha, segment.FromValue, segment.ToValue);
    }

    private Segment GetSegmentAt(long currentTicks) {
        foreach (Segment segment in _segments) {
            if (currentTicks < segment.ToTicks) {
                return segment;
            }
        }
        return _segments[^1];
    }

    private readonly record struct Segment(EasingType Easing, T FromValue, int FromTicks, T ToValue, int ToTicks);
}

/// <summary><c>AttributeTrack</c>: a timeline's keyframes for one attribute, and the modifier their values are applied with.</summary>
public abstract class AttributeTrack<TValue> {
    public abstract AttributeTrackSampler<TValue> BakeSampler(EnvironmentAttribute<TValue> attribute, Identifier clock, int? periodTicks, IClockSource clocks);
}

public sealed class AttributeTrack<TValue, TArgument>(AttributeModifier<TValue, TArgument> modifier, KeyframeTrack<TArgument> argumentTrack)
    : AttributeTrack<TValue> {
    public override AttributeTrackSampler<TValue> BakeSampler(EnvironmentAttribute<TValue> attribute, Identifier clock, int? periodTicks, IClockSource clocks) =>
        new AttributeTrackSampler<TValue, TArgument>(clock, periodTicks, modifier, argumentTrack, modifier.ArgumentKeyframeLerp(attribute), clocks);
}

/// <summary><c>AttributeTrackSampler</c>: the track's argument, sampled once per tick id on the clock's whole ticks.</summary>
public abstract class AttributeTrackSampler<TValue> {
    public abstract TValue ApplyTimeBased(TValue baseValue, int cacheTickId);
}

public sealed class AttributeTrackSampler<TValue, TArgument>(
    Identifier clock,
    int? periodTicks,
    AttributeModifier<TValue, TArgument> modifier,
    KeyframeTrack<TArgument> argumentTrack,
    LerpFunction<TArgument> argumentLerp,
    IClockSource clockManager) : AttributeTrackSampler<TValue> {
    private readonly KeyframeTrackSampler<TArgument> _argumentSampler = argumentTrack.BakeSampler(periodTicks, argumentLerp);
    private int _cachedTickId;
    private TArgument _cachedArgument = default!;
    private bool _hasCachedArgument;

    public override TValue ApplyTimeBased(TValue baseValue, int cacheTickId) {
        if (!_hasCachedArgument || cacheTickId != _cachedTickId) {
            _cachedTickId = cacheTickId;
            _cachedArgument = _argumentSampler.Sample(clockManager.TotalTicks(clock));
            _hasCachedArgument = true;
        }
        return modifier.Apply(baseValue, _cachedArgument);
    }
}

/// <summary>
/// <c>Timeline</c> read out of its registry entry: the clock it runs on, its period if it repeats, and a track per
/// attribute. Time markers are left out, being a command's business.
/// </summary>
public sealed class BakedTimeline {
    private static readonly ConditionalWeakTable<ITimeline, BakedTimeline> Parsed = new();

    private readonly Dictionary<IEnvironmentAttribute, object> _tracks;

    public Identifier Clock { get; }
    public int? PeriodTicks { get; }

    private BakedTimeline(Identifier clock, int? periodTicks, Dictionary<IEnvironmentAttribute, object> tracks) {
        Clock = clock;
        PeriodTicks = periodTicks;
        _tracks = tracks;
    }

    /// <summary>The attributes with a track, in the order the entry lists them.</summary>
    public IEnumerable<IEnvironmentAttribute> Attributes => _tracks.Keys;

    public AttributeTrack<T>? Track<T>(EnvironmentAttribute<T> attribute) => (AttributeTrack<T>?)_tracks.GetValueOrDefault(attribute);

    /// <summary>The registry entry read, once per entry.</summary>
    public static BakedTimeline Of(ITimeline timeline, MinecraftRegistry registry) => Parsed.GetValue(timeline, entry => FromNbt(entry.Data, registry));

    /// <summary>
    /// A dimension type's <c>timelines</c> holder set: one id, a list of them, or a tag, which
    /// <paramref name="tag"/> resolves to its entries in order.
    /// </summary>
    public static IEnumerable<ITimeline> HolderSet(INbtTag? timelines, MinecraftRegistry registry, Func<Identifier, IEnumerable<ITimeline>> tag) {
        IEnumerable<string> names = timelines switch {
            StringTag single => [single.Value],
            ListTag list => list.AsList().OfType<StringTag>().Select(s => s.Value),
            _ => []
        };
        foreach (string name in names) {
            if (name.StartsWith('#')) {
                foreach (ITimeline timeline in tag(name[1..])) {
                    yield return timeline;
                }
            }
            else if (registry.Timelines.Contains(name)) {
                yield return registry.Timelines[name];
            }
        }
    }

    /// <remarks>
    /// A track this build cannot read, naming an attribute or a modifier it does not know, is dropped where vanilla's
    /// codec would refuse the timeline.
    /// </remarks>
    public static BakedTimeline FromNbt(CompoundTag data, MinecraftRegistry registry) {
        Identifier clock = data["clock"]!.GetString();
        int? period = data.Contains("period_ticks") ? data["period_ticks"]!.AsInt() : null;
        Dictionary<IEnvironmentAttribute, object> tracks = new(ReferenceEqualityComparer.Instance);
        if (data["tracks"] is CompoundTag all) {
            foreach ((string key, INbtTag value) in all.Children) {
                if (!registry.EnvironmentAttributes.Contains(key) || registry.EnvironmentAttributes[key] is not ITypedEnvironmentAttribute typed
                    || value is not CompoundTag track) {
                    continue;
                }
                EnvironmentAttributeOperation operation = track["modifier"] is StringTag modifier
                    ? EnvironmentAttributeOperationExtensions.ParseEnvironmentAttributeOperation(modifier.Value)
                    : EnvironmentAttributeOperation.Override;
                EasingType easing = track.Contains("ease") ? EasingType.FromNbt(track["ease"]!) : EasingType.Linear;
                List<(int, INbtTag)> keyframes = track["keyframes"]!.AsList().OfType<CompoundTag>().Select(k => (k["ticks"]!.AsInt(), k["value"]!)).ToList();
                if (keyframes.Count > 0 && typed.ReadTrack(operation, keyframes, easing, registry) is { } read) {
                    tracks[(IEnvironmentAttribute)typed] = read;
                }
            }
        }
        return new BakedTimeline(clock, period, tracks);
    }
}
