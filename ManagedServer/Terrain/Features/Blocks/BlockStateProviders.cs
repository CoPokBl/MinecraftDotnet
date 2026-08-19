using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Noise;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace ManagedServer.Terrain.Features.Blocks;

/// <summary>
/// <c>BlockStateProvider</c>: which state a feature puts down at a position.
/// </summary>
/// <remarks>
/// States are carried as <see cref="IBlock"/> rather than as raw ids: a provider has to be able to
/// change a property of what it was given, and a bare number cannot.
/// </remarks>
public abstract record BlockStateProvider {
    public abstract IBlock GetState(IFeatureLevel level, RandomSource random, int x, int y, int z);

    /// <summary>
    /// <c>getOptionalState</c>: null where the provider declines. Only the rule based provider ever
    /// does, and only that one overrides this.
    /// </summary>
    public virtual IBlock? GetOptionalState(IFeatureLevel level, RandomSource random, int x, int y, int z) {
        return GetState(level, random, x, y, z);
    }

    /// <summary><c>SimpleStateProvider</c>.</summary>
    public sealed record Simple(IBlock State) : BlockStateProvider {
        public override IBlock GetState(IFeatureLevel level, RandomSource random, int x, int y, int z) {
            return State;
        }
    }

    /// <summary><c>WeightedStateProvider</c>.</summary>
    public sealed record Weighted(WeightedList<IBlock> States) : BlockStateProvider {
        public override IBlock GetState(IFeatureLevel level, RandomSource random, int x, int y, int z) {
            return States.GetRandomOrThrow(random);
        }
    }

    /// <summary>
    /// <c>RotatedBlockProvider</c>: a pillar block on a random axis.
    /// </summary>
    /// <remarks>
    /// <c>Axis.getRandom</c> is a plain draw over the three values in their declaration order, so the
    /// axis order matters and is x, y, z.
    /// </remarks>
    public sealed record Rotated(IBlock Block) : BlockStateProvider {
        private static readonly Axis[] Axes = [Axis.X, Axis.Y, Axis.Z];

        public override IBlock GetState(IFeatureLevel level, RandomSource random, int x, int y, int z) {
            Axis axis = Axes[random.NextInt(Axes.Length)];
            return Block is IAxisAligned aligned ? aligned.WithAxis(axis) : Block;
        }
    }

    /// <summary>
    /// <c>RandomizedIntStateProvider</c>: the source's state with an integer property redrawn.
    /// </summary>
    /// <remarks>
    /// The property name comes out of the datapack as a string, and the only one the vanilla data
    /// names is <c>age</c>, so it resolves through <see cref="IAged"/> rather than through
    /// <c>WithState(CompoundTag)</c>. The parser is what rejects any other name: going through NBT
    /// would silently ignore a property the block does not have, which is a feature that quietly
    /// places its source state forever.
    /// <p/>
    /// A source state with no age still places, as vanilla's does when the property is missing.
    /// </remarks>
    public sealed record RandomizedAge(BlockStateProvider Source, IIntProvider Values) : BlockStateProvider {
        public override IBlock GetState(IFeatureLevel level, RandomSource random, int x, int y, int z) {
            IBlock state = Source.GetState(level, random, x, y, z);
            return state is IAged aged ? aged.WithAge(Values.Sample(random)) : state;
        }
    }

    /// <summary>
    /// <c>RuleBasedStateProvider</c>: the first rule whose predicate holds, else the fallback, else
    /// whatever is already there.
    /// </summary>
    public sealed record RuleBased(BlockStateProvider? Fallback,
        IReadOnlyList<(BlockPredicate IfTrue, BlockStateProvider Then)> Rules) : BlockStateProvider {

        public override IBlock GetState(IFeatureLevel level, RandomSource random, int x, int y, int z) {
            return GetOptionalState(level, random, x, y, z)
                ?? level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));
        }

        public override IBlock? GetOptionalState(IFeatureLevel level, RandomSource random, int x, int y,
            int z) {

            foreach ((BlockPredicate ifTrue, BlockStateProvider then) in Rules) {
                if (ifTrue.Test(level, x, y, z)) {
                    return then.GetState(level, random, x, y, z);
                }
            }

            return Fallback?.GetState(level, random, x, y, z);
        }
    }

    /// <summary>
    /// The shared half of the three noise driven providers: a noise seeded from a number in the
    /// datapack rather than from the world seed.
    /// </summary>
    /// <remarks>
    /// That is deliberate upstream and is why flowers form the same patches in every world: the seed
    /// is a literal in the configured feature. It also means one instance can be shared by every
    /// world, which is what makes building the noise at parse time rather than per chunk correct.
    /// </remarks>
    public abstract record NoiseBased(long Seed, NoiseParameters Parameters, float Scale)
        : BlockStateProvider {

        private readonly NormalNoise _noise = NormalNoise.Create(new LegacyRandomSource(Seed), Parameters);

        protected double NoiseValue(int x, int y, int z, double scale) {
            return _noise.GetValue(x * scale, y * scale, z * scale);
        }
    }

    /// <summary><c>NoiseThresholdProvider</c>: the two flower sets either side of a noise level.</summary>
    public sealed record NoiseThreshold(long Seed, NoiseParameters Parameters, float Scale, float Threshold,
        float HighChance, IBlock DefaultState, IReadOnlyList<IBlock> LowStates,
        IReadOnlyList<IBlock> HighStates) : NoiseBased(Seed, Parameters, Scale) {

        public override IBlock GetState(IFeatureLevel level, RandomSource random, int x, int y, int z) {
            double value = NoiseValue(x, y, z, Scale);
            if (value < Threshold) {
                return LowStates[random.NextInt(LowStates.Count)];
            }

            return random.NextFloat() < HighChance
                ? HighStates[random.NextInt(HighStates.Count)]
                : DefaultState;
        }
    }

    /// <summary><c>NoiseProvider</c>: one of a list, indexed by the noise at the position.</summary>
    public record Noise(long Seed, NoiseParameters Parameters, float Scale, IReadOnlyList<IBlock> States)
        : NoiseBased(Seed, Parameters, Scale) {

        public override IBlock GetState(IFeatureLevel level, RandomSource random, int x, int y, int z) {
            return StateAt(States, x, y, z, Scale);
        }

        protected IBlock StateAt(IReadOnlyList<IBlock> states, int x, int y, int z, double scale) {
            return StateFor(states, NoiseValue(x, y, z, scale));
        }

        /// <summary>
        /// The clamp's upper end is <c>0.9999</c> rather than one, which is what stops the index
        /// landing one past the last state.
        /// </summary>
        protected static IBlock StateFor(IReadOnlyList<IBlock> states, double noiseValue) {
            double placement = Mth.Clamp((1.0 + noiseValue) / 2.0, 0.0, 0.9999);
            return states[(int)(placement * states.Count)];
        }
    }

    /// <summary>
    /// <c>DualNoiseProvider</c>: a slow noise picks how many of the states are in play at all, then
    /// the fast one picks between those.
    /// </summary>
    /// <remarks>
    /// The offsets in the inner loop are vanilla's literals and are not a hash: sampling the same
    /// slow noise a long way off is how it gets a second uncorrelated draw out of one noise.
    /// </remarks>
    public sealed record DualNoise(int MinVariety, int MaxVariety, NoiseParameters SlowParameters,
        float SlowScale, long Seed, NoiseParameters Parameters, float Scale, IReadOnlyList<IBlock> States)
        : Noise(Seed, Parameters, Scale, States) {

        private readonly NormalNoise _slowNoise = NormalNoise.Create(new LegacyRandomSource(Seed), SlowParameters);

        public override IBlock GetState(IFeatureLevel level, RandomSource random, int x, int y, int z) {
            double variety = SlowNoiseValue(x, y, z);
            int localVariety = (int)Mth.ClampedMap(variety, -1.0, 1.0, MinVariety, MaxVariety + 1);

            List<IBlock> possible = new(localVariety);
            for (int i = 0; i < localVariety; i++) {
                possible.Add(StateFor(States, SlowNoiseValue(x + i * 54545, y, z + i * 34234)));
            }

            return StateAt(possible, x, y, z, Scale);
        }

        private double SlowNoiseValue(int x, int y, int z) {
            return _slowNoise.GetValue(x * SlowScale, y * SlowScale, z * SlowScale);
        }
    }
}
