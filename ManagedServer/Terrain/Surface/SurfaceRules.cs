using Minecraft.Data.Biomes;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Surface;

/// <summary>
/// A height named relative to the world rather than absolutely, vanilla's <c>VerticalAnchor</c>.
/// </summary>
/// <remarks>
/// The bedrock rules are written against the bottom of the world, so a dimension that is not 384 tall
/// still gets its floor in the right place.
/// </remarks>
public readonly record struct VerticalAnchor(VerticalAnchor.Kind Anchor, int Offset) {
    public enum Kind {
        Absolute,
        AboveBottom,
        BelowTop
    }

    public static VerticalAnchor Absolute(int y) => new(Kind.Absolute, y);
    public static VerticalAnchor AboveBottom(int offset) => new(Kind.AboveBottom, offset);
    public static VerticalAnchor BelowTop(int offset) => new(Kind.BelowTop, offset);

    public int ResolveY(int minY, int height) {
        return Anchor switch {
            Kind.Absolute => Offset,
            Kind.AboveBottom => minY + Offset,
            Kind.BelowTop => height - 1 + minY - Offset,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

/// <summary>
/// A rule bound to a column, vanilla's <c>SurfaceRule</c>: what block goes at a position, or nothing
/// if this rule has no opinion.
/// </summary>
public interface ISurfaceRule {
    /// <summary>The state to write, or null to fall through to the next rule.</summary>
    uint? TryApply(int blockX, int blockY, int blockZ);
}

/// <summary>An unbound rule, vanilla's <c>RuleSource</c>. Binding it to a context produces the rule.</summary>
public interface ISurfaceRuleSource {
    ISurfaceRule Apply(SurfaceContext context);
}

/// <summary>A test bound to a column, vanilla's <c>Condition</c>.</summary>
public interface ISurfaceCondition {
    bool Test();
}

/// <summary>An unbound test, vanilla's <c>ConditionSource</c>.</summary>
public interface ISurfaceConditionSource {
    ISurfaceCondition Apply(SurfaceContext context);
}

/// <summary>
/// Every rule and condition type of vanilla's <c>SurfaceRules</c>.
/// </summary>
/// <remarks>
/// The split between a source and a bound instance is what makes the caching work: a source is parsed
/// once for the whole world, and binding it to a column produces conditions that hold their last
/// answer and recompute only when the column moves. That is why a condition is an object rather than a
/// function of a position.
/// </remarks>
public static class SurfaceRules {
    /// <summary>Writes one fixed state.</summary>
    public sealed class BlockRuleSource(uint stateId) : ISurfaceRuleSource, ISurfaceRule {
        public ISurfaceRule Apply(SurfaceContext context) => this;

        public uint? TryApply(int blockX, int blockY, int blockZ) => stateId;
    }

    /// <summary>The first rule in the list with an opinion wins.</summary>
    public sealed class SequenceRuleSource(IReadOnlyList<ISurfaceRuleSource> sequence) : ISurfaceRuleSource {
        public ISurfaceRule Apply(SurfaceContext context) {
            if (sequence.Count == 1) {
                return sequence[0].Apply(context);
            }

            ISurfaceRule[] rules = new ISurfaceRule[sequence.Count];
            for (int i = 0; i < rules.Length; i++) {
                rules[i] = sequence[i].Apply(context);
            }

            return new SequenceRule(rules);
        }

        private sealed class SequenceRule(ISurfaceRule[] rules) : ISurfaceRule {
            public uint? TryApply(int blockX, int blockY, int blockZ) {
                foreach (ISurfaceRule rule in rules) {
                    uint? state = rule.TryApply(blockX, blockY, blockZ);
                    if (state != null) {
                        return state;
                    }
                }

                return null;
            }
        }
    }

    /// <summary>A rule guarded by a condition.</summary>
    public sealed class TestRuleSource(ISurfaceConditionSource ifTrue, ISurfaceRuleSource thenRun)
        : ISurfaceRuleSource {

        public ISurfaceRule Apply(SurfaceContext context) {
            return new TestRule(ifTrue.Apply(context), thenRun.Apply(context));
        }

        private sealed class TestRule(ISurfaceCondition condition, ISurfaceRule followup) : ISurfaceRule {
            public uint? TryApply(int blockX, int blockY, int blockZ) {
                return condition.Test() ? followup.TryApply(blockX, blockY, blockZ) : null;
            }
        }
    }

    /// <summary>The badlands terracotta bands, read off the surface system's generated table.</summary>
    public sealed class BandlandsRuleSource : ISurfaceRuleSource {
        public static readonly BandlandsRuleSource Instance = new();

        // Bound per world rather than being a shared singleton rule, because the band table is
        // generated from the world seed.
        public ISurfaceRule Apply(SurfaceContext context) => new BandlandsRule(context.System);

        private sealed class BandlandsRule(SurfaceSystem system) : ISurfaceRule {
            public uint? TryApply(int blockX, int blockY, int blockZ) {
                return system.GetBand(blockX, blockY, blockZ);
            }
        }
    }

    /// <summary>
    /// A condition that holds its answer until the column moves, vanilla's <c>LazyCondition</c>.
    /// </summary>
    /// <remarks>
    /// A surface rule tree tests the same conditions repeatedly down a column, and the expensive ones
    /// (a noise sample, a biome lookup) do not change within one. The counter is compared rather than
    /// the position, so a condition never has to know which coordinates it depended on.
    /// </remarks>
    private abstract class LazyCondition(SurfaceContext context) : ISurfaceCondition {
        protected readonly SurfaceContext Context = context;

        private long _lastUpdate = long.MinValue;
        private bool _result;

        public bool Test() {
            long update = ContextLastUpdate;
            if (update != _lastUpdate) {
                _lastUpdate = update;
                _result = Compute();
            }

            return _result;
        }

        protected abstract long ContextLastUpdate { get; }

        protected abstract bool Compute();
    }

    /// <summary>Recomputed when the column moves.</summary>
    private abstract class LazyXzCondition(SurfaceContext context) : LazyCondition(context) {
        protected override long ContextLastUpdate => Context.LastUpdateXz;
    }

    /// <summary>Recomputed when the position within the column moves.</summary>
    private abstract class LazyYCondition(SurfaceContext context) : LazyCondition(context) {
        protected override long ContextLastUpdate => Context.LastUpdateY;
    }

    /// <summary>Negates another condition.</summary>
    public sealed class NotConditionSource(ISurfaceConditionSource target) : ISurfaceConditionSource {
        public ISurfaceCondition Apply(SurfaceContext context) => new NotCondition(target.Apply(context));

        private sealed class NotCondition(ISurfaceCondition target) : ISurfaceCondition {
            public bool Test() => !target.Test();
        }
    }

    /// <summary>Whether the column's biome is one of a set.</summary>
    public sealed class BiomeConditionSource(IReadOnlySet<Identifier> biomes) : ISurfaceConditionSource {
        public ISurfaceCondition Apply(SurfaceContext context) => new BiomeCondition(context, biomes);

        private sealed class BiomeCondition(SurfaceContext context, IReadOnlySet<Identifier> biomes)
            : LazyYCondition(context) {

            protected override bool Compute() => biomes.Contains(Context.GetBiome().Identifier);
        }
    }

    /// <summary>
    /// Whether a named noise is within a range at this position, either as a plane or in three
    /// dimensions.
    /// </summary>
    public sealed class NoiseThresholdConditionSource(Identifier noise, double minThreshold,
        double maxThreshold, bool is3D) : ISurfaceConditionSource {

        public ISurfaceCondition Apply(SurfaceContext context) {
            return new NoiseThresholdCondition(context.GetNoiseSampler(noise, is3D), minThreshold, maxThreshold);
        }

        private sealed class NoiseThresholdCondition(Func<double> noise, double min, double max)
            : ISurfaceCondition {

            public bool Test() {
                double value = noise();

                // Both ends inclusive, unlike almost every other range in worldgen.
                return value >= min && value <= max;
            }
        }
    }

    /// <summary>
    /// How deep into stone this position is, measured from the floor or the ceiling of whatever cavity
    /// is above or below it. This is what makes a surface rule apply to the top few blocks of ground
    /// rather than to a whole column.
    /// </summary>
    public sealed class StoneDepthCheck(int offset, bool addSurfaceDepth, int secondaryDepthRange,
        bool ceiling) : ISurfaceConditionSource {

        public ISurfaceCondition Apply(SurfaceContext context) {
            return new StoneDepthCondition(context, offset, addSurfaceDepth, secondaryDepthRange, ceiling);
        }

        private sealed class StoneDepthCondition(SurfaceContext context, int offset, bool addSurfaceDepth,
            int secondaryDepthRange, bool ceiling) : LazyYCondition(context) {

            protected override bool Compute() {
                int stoneDepth = ceiling ? Context.StoneDepthBelow : Context.StoneDepthAbove;
                int surfaceDepth = addSurfaceDepth ? Context.SurfaceDepth : 0;
                int secondary = secondaryDepthRange == 0
                    ? 0
                    : (int)Mth.Map(Context.GetSurfaceSecondary(), -1.0, 1.0, 0.0, secondaryDepthRange);

                return stoneDepth <= 1 + offset + surfaceDepth + secondary;
            }
        }
    }

    /// <summary>At or above a height, optionally scaled by how deep the surface is here.</summary>
    public sealed class YConditionSource(VerticalAnchor anchor, int surfaceDepthMultiplier, bool addStoneDepth)
        : ISurfaceConditionSource {

        public ISurfaceCondition Apply(SurfaceContext context) {
            return new YCondition(context, anchor.ResolveY(context.MinGenY, context.GenDepth),
                surfaceDepthMultiplier, addStoneDepth);
        }

        private sealed class YCondition(SurfaceContext context, int anchorY, int surfaceDepthMultiplier,
            bool addStoneDepth) : LazyYCondition(context) {

            protected override bool Compute() {
                return Context.BlockY + (addStoneDepth ? Context.StoneDepthAbove : 0)
                    >= anchorY + Context.SurfaceDepth * surfaceDepthMultiplier;
            }
        }
    }

    /// <summary>At or above the water surface of this column, which is what puts sand under a lake.</summary>
    public sealed class WaterConditionSource(int offset, int surfaceDepthMultiplier, bool addStoneDepth)
        : ISurfaceConditionSource {

        public ISurfaceCondition Apply(SurfaceContext context) {
            return new WaterCondition(context, offset, surfaceDepthMultiplier, addStoneDepth);
        }

        private sealed class WaterCondition(SurfaceContext context, int offset, int surfaceDepthMultiplier,
            bool addStoneDepth) : LazyYCondition(context) {

            protected override bool Compute() {
                // No water above at all reads as true, so a dry column takes the same branch as one
                // far above its water line rather than none.
                return Context.WaterHeight == int.MinValue
                    || Context.BlockY + (addStoneDepth ? Context.StoneDepthAbove : 0)
                    >= Context.WaterHeight + offset + Context.SurfaceDepth * surfaceDepthMultiplier;
            }
        }
    }

    /// <summary>
    /// A probabilistic fade between two heights: certain below, impossible above, and randomly
    /// scattered in between. This is what makes the bedrock floor ragged.
    /// </summary>
    public sealed class VerticalGradientConditionSource(Identifier randomName, VerticalAnchor trueAtAndBelow,
        VerticalAnchor falseAtAndAbove) : ISurfaceConditionSource {

        public ISurfaceCondition Apply(SurfaceContext context) {
            return new VerticalGradientCondition(context,
                trueAtAndBelow.ResolveY(context.MinGenY, context.GenDepth),
                falseAtAndAbove.ResolveY(context.MinGenY, context.GenDepth),
                context.RandomState.GetOrCreateRandomFactory(randomName));
        }

        private sealed class VerticalGradientCondition(SurfaceContext context, int trueAtAndBelow,
            int falseAtAndAbove, IPositionalRandomFactory randomFactory) : LazyYCondition(context) {

            protected override bool Compute() {
                int blockY = Context.BlockY;
                if (blockY <= trueAtAndBelow) {
                    return true;
                }

                if (blockY >= falseAtAndAbove) {
                    return false;
                }

                double probability = Mth.Map(blockY, trueAtAndBelow, falseAtAndAbove, 1.0, 0.0);
                return randomFactory.At(Context.BlockX, blockY, Context.BlockZ).NextFloat() < probability;
            }
        }
    }

    /// <summary>Whether this column's ground is steep enough to be a cliff face rather than a slope.</summary>
    public sealed class SteepConditionSource : ISurfaceConditionSource {
        public static readonly SteepConditionSource Instance = new();

        public ISurfaceCondition Apply(SurfaceContext context) => context.Steep;
    }

    /// <summary>Whether the surface is thin enough here to be a gap in it, which exposes stone.</summary>
    public sealed class HoleConditionSource : ISurfaceConditionSource {
        public static readonly HoleConditionSource Instance = new();

        public ISurfaceCondition Apply(SurfaceContext context) => context.Hole;
    }

    /// <summary>
    /// Whether this is near the top of the terrain rather than the roof of a cave, which is what stops
    /// grass appearing on cave ceilings.
    /// </summary>
    public sealed class AbovePreliminarySurfaceConditionSource : ISurfaceConditionSource {
        public static readonly AbovePreliminarySurfaceConditionSource Instance = new();

        public ISurfaceCondition Apply(SurfaceContext context) => context.AbovePreliminarySurface;
    }

    /// <summary>Whether it is cold enough here to snow rather than rain. See <see cref="BiomeClimate"/>.</summary>
    public sealed class TemperatureConditionSource : ISurfaceConditionSource {
        public static readonly TemperatureConditionSource Instance = new();

        public ISurfaceCondition Apply(SurfaceContext context) => context.Temperature;
    }

    /// <summary>
    /// The mutable half of the lazy conditions: the four that read only the context, built once per
    /// column so their caches are shared by every rule that asks.
    /// </summary>
    internal static ISurfaceCondition MakeHole(SurfaceContext context) => new HoleCondition(context);

    internal static ISurfaceCondition MakeSteep(SurfaceContext context) => new SteepCondition(context);

    internal static ISurfaceCondition MakeTemperature(SurfaceContext context) => new TemperatureCondition(context);

    internal static ISurfaceCondition MakeAbovePreliminarySurface(SurfaceContext context) {
        return new AbovePreliminarySurfaceCondition(context);
    }

    private sealed class HoleCondition(SurfaceContext context) : LazyXzCondition(context) {
        protected override bool Compute() => Context.SurfaceDepth <= 0;
    }

    /// <summary>
    /// Compares the ground height a block either side, north against south then west against east.
    /// </summary>
    /// <remarks>
    /// The two comparisons are not symmetric: the first asks whether south is higher than north, and
    /// the second whether <b>west</b> is higher than east. That asymmetry is vanilla's and it makes
    /// the condition direction dependent, which is visible on which side of a mountain the stone
    /// shows through.
    /// </remarks>
    private sealed class SteepCondition(SurfaceContext context) : LazyXzCondition(context) {
        protected override bool Compute() {
            int chunkBlockX = Context.BlockX & 15;
            int chunkBlockZ = Context.BlockZ & 15;

            int zNorth = Math.Max(chunkBlockZ - 1, 0);
            int zSouth = Math.Min(chunkBlockZ + 1, 15);
            if (Context.Column.GetGenerationHeight(chunkBlockX, zSouth)
                >= Context.Column.GetGenerationHeight(chunkBlockX, zNorth) + 4) {
                return true;
            }

            int xWest = Math.Max(chunkBlockX - 1, 0);
            int xEast = Math.Min(chunkBlockX + 1, 15);
            return Context.Column.GetGenerationHeight(xWest, chunkBlockZ)
                >= Context.Column.GetGenerationHeight(xEast, chunkBlockZ) + 4;
        }
    }

    private sealed class TemperatureCondition(SurfaceContext context) : LazyYCondition(context) {
        protected override bool Compute() {
            IBiome biome = Context.GetBiome();
            return BiomeClimate.ColdEnoughToSnow(biome, Context.BlockX, Context.BlockY, Context.BlockZ,
                Context.System.SeaLevel);
        }
    }

    private sealed class AbovePreliminarySurfaceCondition(SurfaceContext context) : ISurfaceCondition {
        // Not lazy upstream either: it is one comparison against a value the context already caches.
        public bool Test() => context.BlockY >= context.GetMinSurfaceLevel();
    }
}
