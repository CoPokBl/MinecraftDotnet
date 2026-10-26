using ManagedServer.Terrain.Data;
using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Noise;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas;
using Minecraft.Placement;
using Minecraft.Schemas.Blocks.BlockEnums;
using NBT;
using NBT.Tags;

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
    /// <c>getOptionalState</c>: null where the provider declines. The rule based and random block
    /// providers are the ones that can.
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
    /// <c>RotatedBlockProvider</c>: the inner provider's state turned to face a direction, a drawn one
    /// unless the data names it.
    /// </summary>
    /// <remarks>
    /// The draw is <c>Direction.getRandom</c>, one <c>nextInt(6)</c> over <c>Direction.values()</c>,
    /// and it happens <b>before</b> the inner provider is asked, since vanilla evaluates the
    /// direction first. Each property is set only where the state has it: <c>axis</c> to the
    /// direction's axis, the six way <c>facing</c>, and for a horizontal direction the four way one.
    /// </remarks>
    public sealed record Rotated(BlockStateProvider State, BlockFace? Direction) : BlockStateProvider {
        public override IBlock GetState(IFeatureLevel level, RandomSource random, int x, int y, int z) {
            BlockFace direction = Direction ?? Directions.All[random.NextInt(Directions.All.Length)];
            IBlock state = State.GetState(level, random, x, y, z);

            if (state is IAxisAligned aligned) {
                state = aligned.WithAxis(AxisOf(direction));
            }

            if (state is IDirectional directional) {
                state = directional.WithFacing(direction.ToCardinal());
            }

            if (Directions.IsHorizontal(direction) && state is IHorizontalFacing horizontal) {
                state = horizontal.WithFacing(direction.ToDirection());
            }

            return state;
        }

        private static Axis AxisOf(BlockFace face) => face switch {
            BlockFace.NegX or BlockFace.PosX => Axis.X,
            BlockFace.NegY or BlockFace.PosY => Axis.Y,
            _ => Axis.Z
        };
    }

    /// <summary>
    /// <c>RandomizedIntStateProvider</c>: the source's state with an integer property redrawn.
    /// </summary>
    /// <remarks>
    /// The property is found by name on whatever state the source produced, and a state without an
    /// integer property of that name places unchanged, as vanilla's does. <c>age</c>, which is
    /// nearly every use, goes through <see cref="IAged"/>; any other name goes through the state's
    /// properties by string, which <see cref="StateParser.Apply"/> refuses rather than ignoring when
    /// the key is not there.
    /// </remarks>
    public sealed record RandomizedInt(BlockStateProvider Source, string Property, IIntProvider Values)
        : BlockStateProvider {

        public override IBlock GetState(IFeatureLevel level, RandomSource random, int x, int y, int z) {
            IBlock state = Source.GetState(level, random, x, y, z);

            if (Property == "age") {
                return state is IAged aged ? aged.WithAge(Values.Sample(random)) : state;
            }

            if (state.ToStateNbt()[Property] is not StringTag current || !int.TryParse(current.Value, out _)) {
                return state;
            }

            return StateParser.Apply(state,
                new CompoundTag((Property, new StringTag(Values.Sample(random).ToString()))));
        }
    }

    /// <summary>
    /// <c>RuleBasedStateProvider</c>: the first rule whose predicate holds and whose provider answers,
    /// else the fallback, else whatever is already there.
    /// </summary>
    /// <remarks>
    /// A rule's provider is asked for its <b>optional</b> state, and a decline moves on to the next
    /// rule rather than ending the search.
    /// </remarks>
    public sealed record RuleBased(BlockStateProvider? Fallback,
        IReadOnlyList<(BlockPredicate IfTrue, BlockStateProvider Then)> Rules) : BlockStateProvider {

        public override IBlock GetState(IFeatureLevel level, RandomSource random, int x, int y, int z) {
            return GetOptionalState(level, random, x, y, z)
                ?? level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));
        }

        public override IBlock? GetOptionalState(IFeatureLevel level, RandomSource random, int x, int y,
            int z) {

            foreach ((BlockPredicate ifTrue, BlockStateProvider then) in Rules) {
                if (ifTrue.Test(level, x, y, z)
                    && then.GetOptionalState(level, random, x, y, z) is { } state) {

                    return state;
                }
            }

            return Fallback?.GetOptionalState(level, random, x, y, z);
        }
    }

    /// <summary>
    /// <c>CopyPropertiesProvider</c>: the source's state with every property the block already at the
    /// position shares with it copied across.
    /// </summary>
    /// <remarks>
    /// <c>withPropertiesOf</c> matches properties by object identity, and two blocks share a property
    /// object exactly when they share the vanilla constant. This matches by name and copies only a
    /// value the target accepts, which is the same answer wherever two same named properties have the
    /// same values; where they do not (two <c>age</c> ranges) a value the target lacks is skipped
    /// rather than copied. No vanilla worldgen data uses this provider.
    /// </remarks>
    public sealed record CopyProperties(BlockStateProvider Source) : BlockStateProvider {
        public override IBlock GetState(IFeatureLevel level, RandomSource random, int x, int y, int z) {
            IBlock state = Source.GetState(level, random, x, y, z);
            IBlock there = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));

            CompoundTag own = state.ToStateNbt();
            foreach ((string name, INbtTag value) in there.ToStateNbt().Children) {
                if (!own.Contains(name)) {
                    continue;
                }

                IBlock changed = state.WithState(new CompoundTag((name, value)));
                if (changed.ToStateNbt()[name] is StringTag set && value is StringTag wanted
                    && set.Value == wanted.Value) {

                    state = changed;
                }
            }

            return state;
        }
    }

    /// <summary>
    /// <c>RandomBlockProvider</c>: the default state of a block drawn from a set, in the set's own
    /// order.
    /// </summary>
    /// <remarks>
    /// An empty set declines through <see cref="GetOptionalState"/> without drawing, and
    /// <see cref="GetState"/> then answers the block already there.
    /// </remarks>
    public sealed record RandomBlock(IReadOnlyList<IBlock> Blocks) : BlockStateProvider {
        public override IBlock GetState(IFeatureLevel level, RandomSource random, int x, int y, int z) {
            return GetOptionalState(level, random, x, y, z)
                ?? level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));
        }

        public override IBlock? GetOptionalState(IFeatureLevel level, RandomSource random, int x, int y,
            int z) {

            return Blocks.Count == 0 ? null : Blocks[random.NextInt(Blocks.Count)];
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

        private readonly INoise _noise = new NormalNoise(Parameters).Create(new LegacyRandomSource(Seed));

        protected float NoiseValue(int x, int y, int z, double scale) {
            return _noise.Get(x * scale, y * scale, z * scale);
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

        private readonly INoise _slowNoise = new NormalNoise(SlowParameters).Create(new LegacyRandomSource(Seed));

        public override IBlock GetState(IFeatureLevel level, RandomSource random, int x, int y, int z) {
            double variety = SlowNoiseValue(x, y, z);
            int localVariety = (int)Mth.ClampedMap(variety, -1.0, 1.0, MinVariety, MaxVariety + 1);

            List<IBlock> possible = new(localVariety);
            for (int i = 0; i < localVariety; i++) {
                possible.Add(StateFor(States, SlowNoiseValue(x + i * 54545, y, z + i * 34234)));
            }

            return StateAt(possible, x, y, z, Scale);
        }

        /// <summary>The scale is a float multiplied into an int, so the coordinate is a float before it widens.</summary>
        private float SlowNoiseValue(int x, int y, int z) {
            return _slowNoise.Get(x * SlowScale, y * SlowScale, z * SlowScale);
        }
    }
}
