using ManagedServer.Terrain.Density;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Material;

/// <summary>A rule compiled against one chunk's context, vanilla's <c>RuleEvaluator</c>.</summary>
public interface IRuleEvaluator {
    /// <summary>The state to write, or null to fall through to the next rule.</summary>
    uint? TryApply(int blockX, int blockY, int blockZ);
}

/// <summary>A condition compiled against one chunk's context, vanilla's <c>ConditionEvaluator</c>.</summary>
public interface IConditionEvaluator {
    bool Test();
}

/// <summary>
/// What block the surface pass puts at a position, vanilla's <c>MaterialRule</c>.
/// </summary>
/// <remarks>
/// Compiling binds the rule to a chunk's context, so lazy conditions hold their last answer and
/// recompute only when the context moves. A referenced rule is compiled afresh at each use, as
/// upstream, so its conditions are per occurrence exactly as if the reference were written inline.
/// </remarks>
public interface IMaterialRule {
    IRuleEvaluator Compile(MaterialRuleContext context);
}

/// <summary>A test a material rule is guarded by, vanilla's <c>MaterialCondition</c>.</summary>
public interface IMaterialCondition {
    IConditionEvaluator Compile(MaterialRuleContext context);
}

/// <summary>A reference into <c>worldgen/material_rule</c>, resolved on first use.</summary>
public sealed class MaterialRuleReference(Identifier id, Func<Identifier, IMaterialRule> resolve) : IMaterialRule {
    private IMaterialRule? _value;

    public Identifier Id => id;

    public IMaterialRule Value => _value ??= resolve(id);

    public IRuleEvaluator Compile(MaterialRuleContext context) => Value.Compile(context);
}

/// <summary>A reference into <c>worldgen/material_condition</c>, resolved on first use.</summary>
public sealed class MaterialConditionReference(Identifier id, Func<Identifier, IMaterialCondition> resolve) : IMaterialCondition {
    private IMaterialCondition? _value;

    public Identifier Id => id;

    public IMaterialCondition Value => _value ??= resolve(id);

    public IConditionEvaluator Compile(MaterialRuleContext context) => Value.Compile(context);
}

/// <summary>Every rule type, vanilla's <c>material/rule</c> package.</summary>
public static class MaterialRules {
    /// <summary><c>BlockRule</c>: one fixed state.</summary>
    public sealed record Block(uint ResultState) : IMaterialRule, IRuleEvaluator {
        public IRuleEvaluator Compile(MaterialRuleContext context) => this;

        public uint? TryApply(int blockX, int blockY, int blockZ) => ResultState;
    }

    /// <summary><c>SequenceRule</c>: the first rule with an answer wins.</summary>
    public sealed record Sequence(IReadOnlyList<IMaterialRule> Rules) : IMaterialRule {
        public IRuleEvaluator Compile(MaterialRuleContext context) {
            if (Rules.Count == 1) {
                return Rules[0].Compile(context);
            }

            IRuleEvaluator[] sequence = new IRuleEvaluator[Rules.Count];
            for (int i = 0; i < sequence.Length; i++) {
                sequence[i] = Rules[i].Compile(context);
            }

            return new Evaluator(sequence);
        }

        private sealed class Evaluator(IRuleEvaluator[] sequence) : IRuleEvaluator {
            public uint? TryApply(int blockX, int blockY, int blockZ) {
                foreach (IRuleEvaluator rule in sequence) {
                    if (rule.TryApply(blockX, blockY, blockZ) is { } state) {
                        return state;
                    }
                }

                return null;
            }
        }
    }

    /// <summary><c>ConditionRule</c>: a rule guarded by a condition.</summary>
    public sealed record Condition(IMaterialCondition IfTrue, IMaterialRule ThenRun) : IMaterialRule {
        public IRuleEvaluator Compile(MaterialRuleContext context) {
            return new Evaluator(IfTrue.Compile(context), ThenRun.Compile(context));
        }

        private sealed class Evaluator(IConditionEvaluator ifTrue, IRuleEvaluator thenRun) : IRuleEvaluator {
            public uint? TryApply(int blockX, int blockY, int blockZ) {
                return !ifTrue.Test() ? null : thenRun.TryApply(blockX, blockY, blockZ);
            }
        }
    }

    /// <summary><c>BandlandsRule</c>: the badlands terracotta bands.</summary>
    public sealed class Bandlands : IMaterialRule {
        public static readonly Bandlands Instance = new();

        public IRuleEvaluator Compile(MaterialRuleContext context) => new Evaluator(context);

        private sealed class Evaluator(MaterialRuleContext context) : IRuleEvaluator {
            public uint? TryApply(int blockX, int blockY, int blockZ) => context.GetBand(blockX, blockY, blockZ);
        }
    }

    /// <summary>
    /// <c>OreVeinRule</c>: the large copper and iron veins, which in 26.3 are a material rule rather than
    /// part of the noise fill.
    /// </summary>
    /// <remarks>
    /// Density and richness are sampled as one volume over the chunk up front, the gap only at points.
    /// The three random draws come from <c>minecraft:ore</c> at the position, so a vein is the same
    /// whatever order chunks are built in.
    /// </remarks>
    public sealed record OreVein(uint OreBlock, uint RawOreBlock, uint FillerBlock, float RawOreChance,
        IDensityFunction Density, IDensityFunction Richness, IDensityFunction FillerGap) : IMaterialRule {

        public static readonly Identifier OreRandom = "minecraft:ore";

        public IRuleEvaluator Compile(MaterialRuleContext context) {
            return new Evaluator(this, context.GetDensitiesInChunk(Density, true), context.GetDensitiesInChunk(Richness, true),
                context.GetDensitiesInChunk(FillerGap, false), context.GetOrCreateRandomFactory(OreRandom));
        }

        private sealed class Evaluator(OreVein rule, Func<float> density, Func<float> richness, Func<float> fillerGap,
            IPositionalRandomFactory randomFactory) : IRuleEvaluator {

            public uint? TryApply(int blockX, int blockY, int blockZ) {
                float value = density();
                if (value <= 0.0F) {
                    return null;
                }

                RandomSource random = randomFactory.At(blockX, blockY, blockZ);
                if (random.NextFloat() > value) {
                    return null;
                }

                float richnessValue = richness();
                if (random.NextFloat() < richnessValue && fillerGap() < 0.0F) {
                    return random.NextFloat() < rule.RawOreChance ? rule.RawOreBlock : rule.OreBlock;
                }

                return rule.FillerBlock;
            }
        }
    }
}

/// <summary>Which side of a cavity a stone depth is measured from, vanilla's <c>CaveSurface</c>.</summary>
public enum CaveSurface {
    Ceiling,
    Floor
}

/// <summary>Every condition type, vanilla's <c>material/condition</c> package.</summary>
public static class MaterialConditions {
    /// <summary><c>NotCondition</c>.</summary>
    public sealed record Not(IMaterialCondition Target) : IMaterialCondition {
        public IConditionEvaluator Compile(MaterialRuleContext context) => new Evaluator(Target.Compile(context));

        private sealed class Evaluator(IConditionEvaluator target) : IConditionEvaluator {
            public bool Test() => !target.Test();
        }
    }

    /// <summary>
    /// <c>BiomeCondition</c>. Folded at compile time against the biomes the chunk can contain, which
    /// only saves the lookup.
    /// </summary>
    public sealed record Biome(IReadOnlySet<Identifier> Biomes) : IMaterialCondition {
        public IConditionEvaluator Compile(MaterialRuleContext context) {
            if (context.PossibleBiomes is { } possible) {
                if (!Biomes.Any(possible.Contains)) {
                    return Constant.False;
                }

                if (possible.All(Biomes.Contains)) {
                    return Constant.True;
                }
            }

            return new Evaluator(context, Biomes);
        }

        private sealed class Evaluator(MaterialRuleContext context, IReadOnlySet<Identifier> biomes) : MaterialRuleContext.LazyYCondition(context) {
            protected override bool Compute() => biomes.Contains(Context.GetBiome().Identifier);
        }
    }

    /// <summary>
    /// <c>NoiseThresholdCondition</c>. Both ends inclusive. The noise is float, sampled once per column
    /// in two dimensions and once per position in three.
    /// </summary>
    public sealed record NoiseThreshold(Identifier Noise, double MinThreshold, double MaxThreshold, bool Is3D) : IMaterialCondition {
        public IConditionEvaluator Compile(MaterialRuleContext context) {
            return new Evaluator(context.GetNoiseSampler(Noise, Is3D), MinThreshold, MaxThreshold);
        }

        private sealed class Evaluator(Func<double> noise, double min, double max) : IConditionEvaluator {
            public bool Test() {
                double value = noise();
                return value >= min && value <= max;
            }
        }
    }

    /// <summary><c>VerticalGradientCondition</c>: certain below, impossible above, a positional draw between.</summary>
    public sealed record VerticalGradient(Identifier RandomName, VerticalAnchor TrueAtAndBelow, VerticalAnchor FalseAtAndAbove)
        : IMaterialCondition {

        public IConditionEvaluator Compile(MaterialRuleContext context) {
            return new Evaluator(context, context.ResolveAnchorY(TrueAtAndBelow), context.ResolveAnchorY(FalseAtAndAbove),
                context.GetOrCreateRandomFactory(RandomName));
        }

        private sealed class Evaluator(MaterialRuleContext context, int trueAtAndBelow, int falseAtAndAbove,
            IPositionalRandomFactory randomFactory) : MaterialRuleContext.LazyYCondition(context) {

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

    /// <summary><c>YCondition</c>: at or above an anchor, optionally shifted by the surface depth.</summary>
    public sealed record YAbove(VerticalAnchor Anchor, int SurfaceDepthMultiplier, bool AddStoneDepth) : IMaterialCondition {
        public IConditionEvaluator Compile(MaterialRuleContext context) => new Evaluator(context, this);

        private sealed class Evaluator(MaterialRuleContext context, YAbove condition) : MaterialRuleContext.LazyYCondition(context) {
            protected override bool Compute() {
                return Context.BlockY + (condition.AddStoneDepth ? Context.StoneDepthAbove : 0)
                    >= Context.ResolveAnchorY(condition.Anchor) + Context.SurfaceDepth * condition.SurfaceDepthMultiplier;
            }
        }
    }

    /// <summary>
    /// <c>WaterCondition</c>: at or above the water surface of this column. No water above at all reads
    /// as true.
    /// </summary>
    public sealed record Water(int Offset, int SurfaceDepthMultiplier, bool AddStoneDepth) : IMaterialCondition {
        public IConditionEvaluator Compile(MaterialRuleContext context) => new Evaluator(context, this);

        private sealed class Evaluator(MaterialRuleContext context, Water condition) : MaterialRuleContext.LazyYCondition(context) {
            protected override bool Compute() {
                return Context.WaterHeight == int.MinValue
                    || Context.BlockY + (condition.AddStoneDepth ? Context.StoneDepthAbove : 0)
                    >= Context.WaterHeight + condition.Offset + Context.SurfaceDepth * condition.SurfaceDepthMultiplier;
            }
        }
    }

    /// <summary><c>TemperatureCondition</c>: <c>coldEnoughToSnow</c> here. Evaluated on every test, as upstream.</summary>
    public sealed class Temperature : IMaterialCondition {
        public static readonly Temperature Instance = new();

        public IConditionEvaluator Compile(MaterialRuleContext context) => new Evaluator(context);

        private sealed class Evaluator(MaterialRuleContext context) : IConditionEvaluator {
            public bool Test() {
                return Surface.BiomeClimate.ColdEnoughToSnow(context.GetBiome(), context.BlockX, context.BlockY, context.BlockZ,
                    context.SeaLevel);
            }
        }
    }

    /// <summary>
    /// <c>SteepCondition</c>, from the surface gradients. The two comparisons point different ways,
    /// south higher than north or west higher than east, as upstream.
    /// </summary>
    public sealed class Steep : IMaterialCondition {
        public static readonly Steep Instance = new();

        public IConditionEvaluator Compile(MaterialRuleContext context) => new Evaluator(context);

        private sealed class Evaluator(MaterialRuleContext context) : MaterialRuleContext.LazyXzCondition(context) {
            protected override bool Compute() => Context.SurfaceGradientX <= -4 || Context.SurfaceGradientZ >= 4;
        }
    }

    /// <summary><c>HoleCondition</c>: the surface is too thin here to have any soil.</summary>
    public sealed class Hole : IMaterialCondition {
        public static readonly Hole Instance = new();

        public IConditionEvaluator Compile(MaterialRuleContext context) => new Evaluator(context);

        private sealed class Evaluator(MaterialRuleContext context) : MaterialRuleContext.LazyXzCondition(context) {
            protected override bool Compute() => Context.SurfaceDepth <= 0;
        }
    }

    /// <summary><c>AbovePreliminarySurfaceCondition</c>: near the top of the terrain rather than a cave roof.</summary>
    public sealed class AbovePreliminarySurface : IMaterialCondition {
        public static readonly AbovePreliminarySurface Instance = new();

        public IConditionEvaluator Compile(MaterialRuleContext context) => new Evaluator(context);

        private sealed class Evaluator(MaterialRuleContext context) : IConditionEvaluator {
            public bool Test() => context.BlockY >= context.GetMinSurfaceLevel();
        }
    }

    /// <summary><c>StoneDepthCondition</c>: how deep into stone this position is, from the floor or the ceiling.</summary>
    public sealed record StoneDepth(int Offset, bool AddSurfaceDepth, int SecondaryDepthRange, CaveSurface SurfaceType) : IMaterialCondition {
        public IConditionEvaluator Compile(MaterialRuleContext context) => new Evaluator(context, this);

        private sealed class Evaluator(MaterialRuleContext context, StoneDepth condition) : MaterialRuleContext.LazyYCondition(context) {
            protected override bool Compute() {
                int stoneDepth = condition.SurfaceType == CaveSurface.Ceiling ? Context.StoneDepthBelow : Context.StoneDepthAbove;
                int surfaceDepth = condition.AddSurfaceDepth ? Context.SurfaceDepth : 0;
                int secondary = condition.SecondaryDepthRange == 0
                    ? 0
                    : (int)Mth.Map(Context.GetSurfaceSecondary(), -1.0, 1.0, 0.0, condition.SecondaryDepthRange);
                return stoneDepth <= 1 + condition.Offset + surfaceDepth + secondary;
            }
        }
    }

    private sealed class Constant(bool value) : IConditionEvaluator {
        public static readonly Constant True = new(true);
        public static readonly Constant False = new(false);

        public bool Test() => value;
    }
}
