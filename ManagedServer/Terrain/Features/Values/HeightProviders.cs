using Minecraft.Schemas;

namespace ManagedServer.Terrain.Features.Values;

/// <summary>
/// <c>WorldGenerationContext</c>: the y range a <see cref="VerticalAnchor"/> resolves against.
/// </summary>
/// <remarks>
/// Upstream this is the smaller of the level's range and the generator's, which is what stops a
/// datapack aimed at a 384 tall overworld writing outside a shallower world.
/// </remarks>
public readonly record struct GenerationHeightContext(int MinGenY, int GenDepth) {
    /// <summary>One past the highest block, which is what a half open range wants.</summary>
    public int MaxGenY => MinGenY + GenDepth;
}

/// <summary>
/// <c>VerticalAnchor</c>: a height written either as a number or as a distance from an end of the
/// world.
/// </summary>
public abstract record VerticalAnchor {
    public abstract int ResolveY(GenerationHeightContext context);

    /// <summary><c>VerticalAnchor.Absolute</c>.</summary>
    public sealed record Absolute(int Y) : VerticalAnchor {
        public override int ResolveY(GenerationHeightContext context) => Y;
    }

    /// <summary><c>VerticalAnchor.AboveBottom</c>.</summary>
    public sealed record AboveBottom(int Offset) : VerticalAnchor {
        public override int ResolveY(GenerationHeightContext context) => context.MinGenY + Offset;
    }

    /// <summary>
    /// <c>VerticalAnchor.BelowTop</c>. The <c>- 1</c> is vanilla's: an offset of zero is the highest
    /// block of the world rather than the first position above it.
    /// </summary>
    public sealed record BelowTop(int Offset) : VerticalAnchor {
        public override int ResolveY(GenerationHeightContext context) {
            return context.GenDepth - 1 + context.MinGenY - Offset;
        }
    }
}

/// <summary><c>HeightProvider</c>: where up the world a feature is put.</summary>
public abstract record HeightProvider {
    public abstract int Sample(RandomSource random, GenerationHeightContext context);

    /// <summary><c>ConstantHeight</c>.</summary>
    public sealed record Constant(VerticalAnchor Value) : HeightProvider {
        public override int Sample(RandomSource random, GenerationHeightContext context) {
            return Value.ResolveY(context);
        }
    }

    /// <summary>
    /// <c>UniformHeight</c>. An inverted range answers its own minimum rather than throwing, which is
    /// vanilla's behaviour and is reachable whenever a datapack written for a taller world is loaded
    /// into a shallow one.
    /// </summary>
    public sealed record Uniform(VerticalAnchor MinInclusive, VerticalAnchor MaxInclusive) : HeightProvider {
        public override int Sample(RandomSource random, GenerationHeightContext context) {
            int min = MinInclusive.ResolveY(context);
            int max = MaxInclusive.ResolveY(context);
            return min > max ? min : random.NextIntBetweenInclusive(min, max);
        }
    }

    /// <summary><c>BiasedToBottomHeight</c>.</summary>
    public sealed record BiasedToBottom(VerticalAnchor MinInclusive, VerticalAnchor MaxInclusive, int Inner)
        : HeightProvider {

        public override int Sample(RandomSource random, GenerationHeightContext context) {
            int min = MinInclusive.ResolveY(context);
            int max = MaxInclusive.ResolveY(context);
            if (max - min - Inner + 1 <= 0) {
                return min;
            }

            int limit = random.NextInt(max - min - Inner + 1);
            return random.NextInt(limit + Inner) + min;
        }
    }

    /// <summary>
    /// <c>VeryBiasedToBottomHeight</c>: three nested draws, each narrowing the range the next one
    /// works over.
    /// </summary>
    public sealed record VeryBiasedToBottom(VerticalAnchor MinInclusive, VerticalAnchor MaxInclusive, int Inner)
        : HeightProvider {

        public override int Sample(RandomSource random, GenerationHeightContext context) {
            int min = MinInclusive.ResolveY(context);
            int max = MaxInclusive.ResolveY(context);
            if (max - min - Inner + 1 <= 0) {
                return min;
            }

            int upperInclusive = Mth.NextInt(random, min + Inner, max);
            int biasedUpperInclusive = Mth.NextInt(random, min, upperInclusive - 1);
            return Mth.NextInt(random, min, biasedUpperInclusive - 1 + Inner);
        }
    }

    /// <summary><c>TrapezoidHeight</c>.</summary>
    public sealed record Trapezoid(VerticalAnchor MinInclusive, VerticalAnchor MaxInclusive, int Plateau)
        : HeightProvider {

        public override int Sample(RandomSource random, GenerationHeightContext context) {
            int min = MinInclusive.ResolveY(context);
            int max = MaxInclusive.ResolveY(context);
            if (min > max) {
                return min;
            }

            int range = max - min;
            if (Plateau >= range) {
                return random.NextIntBetweenInclusive(min, max);
            }

            int plateauStart = (range - Plateau) / 2;
            int plateauEnd = range - plateauStart;
            return min + random.NextIntBetweenInclusive(0, plateauEnd)
                + random.NextIntBetweenInclusive(0, plateauStart);
        }
    }

    /// <summary><c>WeightedListHeight</c>.</summary>
    public sealed record WeightedList(WeightedList<HeightProvider> Distribution) : HeightProvider {
        public override int Sample(RandomSource random, GenerationHeightContext context) {
            return Distribution.GetRandomOrThrow(random).Sample(random, context);
        }
    }
}
